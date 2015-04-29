using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CraftRoutine : MonoBehaviour 
{
    //sprites to load various background difficulties into the hammer and heat bars
    public Sprite heatDiff1;
	public Sprite heatDiff2;
	public Sprite heatDiff3;

    public Sprite hardenDiff1;
    public Sprite hardenDiff2;
    public Sprite hardenDiff3;

    public Sprite temperDiff1;
    public Sprite temperDiff2;
    public Sprite temperDiff3;

	public Sprite hammerDiff1;
	public Sprite hammerDiff2;
	public Sprite hammerDiff3;

    public Sprite bellowsClosed;
    public Sprite bellowsMid;
    public Sprite bellowsOpen;

	public float heatSliderChange;
	public float hammerSliderChange;
	public float timeSliderChange;
	public float furnaceSliderChange;
	public float quenchingSliderChange;

    public GameObject craftingCamera;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    private bool workshopFront = true;

	public GameObject heatSliderObject;
	public GameObject hammerSliderObject;
	public GameObject timerSliderObject;
    public GameObject furnaceSliderObject;
    public GameObject barrelSliderObject;
    public GameObject bellowsSliderObject;
	private Slider heatSlider;
	private Slider hammerSlider;
	private Slider timerSlider;
	private Slider furnaceSlider;
    private Slider barrelSlider;
    private Slider bellowsSlider;

    private GameObject forge;
    private GameObject bellows;
    public GameObject craftingComponent; //eventually the game will programmatically instantiate the GameObject that you will use during the current crafting session, for now we will assign it a test object
    private GameObject coolingBarrel;
    private GameObject hammer;
    private GameObject anvil;

    private Image heatSliderBackground;
    private Image hammerSliderBackground;

    public StageTimeMatrix timeMultiplier;

    public Text stage;
    public Text popUpText;
    public Text results;

    //CRAFTING TOOL INTERACTION ALLOWANCES

    bool useAnvil;
    bool useForge;
    bool useHammer;
    bool useGrinder;
    bool useSharpener;
    bool usePolisher;
    bool useBarrel;

    //CRAFTING TOOL TRACKING/LEVELS

    int hammerLevel;
    int anvilLevel;
    int forgeLevel;
    int grinderLevel;
    int sharpeningLevel;
    int polishingLevel;
    int barrelLevel;

    //CRAFTING CONSTANTS

    private const float fullSlider = 60.0f;
    private const float emptySlider = 0.0f;
	private const float hammerHitIncrease = 10.0f;
	private const float bellowsHitIncrese = 2.0f;
	private const float heatToStart = 25.0f;
	private const float hammerToStart = 25.0f;

    //COMPONENT CONTROL

    private bool furnaceIsMelting;
    private bool componentOnAnvil;
    private bool componentInBarrel;
    private bool componentOnForge;
    private bool componentOnGrinder;

    //TIMER

    private float countDown = 3.0f;
    private float quality;
    private const float timeSync = 1.0f;
    private float timeQuality;

    //ITEM QUALITY TRACKING

    public float itemQuality;
    public float possibleItemQuality;
	private string itemType;
	private string materialType;
	
    //STAGE CONTROL

    private int currentStage;
    private int currentStageAbsVal; // gets the integer value of the stage itself, not the number of the stage in order of stages for the current item
    private int totalStages;
    private double currentStageTime;

    //ANNOUNCEMENT TIMER 

    private string annText;
    private bool annActive;
    private float annEndTime;
    private float annTimer;

    //STAGE TIMER

    private bool timerSet;
    private bool timerActive;
    private float timerEndTime;
    private float timerTimer;

    //HARDERNING STAGE

    private bool heated;
    private bool cooled;

    //GRINDING STAGE

    private bool grinded;
    public Transform tiltedRight;
    public Transform tiltedLeft;
    public GameObject grinderGauge;
    private const int speed = 3;
    private float step;
    private float counterStep;
    private bool grindCycle;
    private float grindTime;
    private bool rotateRight;
    private int playerRotation; // 0 for none, 1 for right, 2 for left

    //POlISHING STAGE

    private const int basePolishTime = 5;
    private float polishTimer;
    private bool polishCycle;
    private int shineSpot;
    public GameObject shine1;
    public GameObject shine2;
    public GameObject shine3;
    public GameObject shine4;
    public GameObject shine5;
    public GameObject shine6;
    public GameObject shine7;
    public GameObject shine8;
    public GameObject shine9;
    public GameObject shine10;
    public GameObject shine11;
    public GameObject shine12;
    private bool shimmer;
    private bool shimmer1;
    private bool shimmer2;
    private bool shimmer3;
    private bool shimmer4;
    private bool shimmer5;
    private bool shimmer6;
    private bool shimmer7;
    private bool shimmer8;
    private bool shimmer9;
    private bool shimmer10;
    private bool shimmer11;
    private bool shimmer12;
    private int lastShine;
    private int polishCount;
    private int polishesNeeded;

    private float bellowsPosition;
    private const float homeBellowsPosition = 6.0f;

    private SoundController soundController;


    void setTimer(float time)
    {
        timerTimer = 0.0f;
        timerEndTime = time;
        timerSlider.maxValue = timerEndTime;
        timerSet = true;
        //timerActive = true;
    }

    void startTimer()
    {
        timerSet = false;
        timerActive = true;
        Debug.Log("startTimer set timerActive true");
    }

    void resetTimer()
    {
        timerTimer = 0.0f;
        timerEndTime = 0.0f;
        timerSet = false;
        timerActive = false;
        Debug.Log("resettimer set timerActive false");
    }

    void setAnnouncement(string announcement, float time)
    {
        popUpText.enabled = true;
        popUpText.text = announcement;
        annEndTime = time;
        annTimer = 0.0f;
        annActive = true;
    }

    void resetAnnouncement()
    {
        popUpText.text = "";
        annEndTime = 0.0f;
        annTimer = 0.0f;
        annActive = false;
        popUpText.enabled = false;
    }

    void resetCrafting()
    {
        currentStage = -1;

        componentOnAnvil = false;
        componentOnForge = false;
        componentInBarrel = false;
        componentOnGrinder = false;

        resetBetweenStages();

        grinded = false;
        rotateRight = false;
        grindCycle = false;
        playerRotation = 0;

        stage.enabled = false;
        popUpText.enabled = false;
        resetTimer();
        resetAnnouncement();
        resetSliders();
    }

    void resetSliders()
    {
        heatSlider.value = 0.0f;
        hammerSlider.value = 0.0f;
        timerSlider.value = 0.0f;

        furnaceSlider.value = 0.0f; //REALLY need to figure out what scripting is going to manage the furnace and pass information into this object to manage the display slider
    }

	void Start () 
	{
        soundController = this.GetComponent<SoundController>();

        heatSliderBackground = GameObject.Find("/Canvas/Heat Gauge/Background").GetComponent<Image>();
        hammerSliderBackground = GameObject.Find("Canvas/Hammer Gauge/Background").GetComponent<Image>();

        anvil = GameObject.Find("Crafting/Anvil");
        forge = GameObject.Find("Crafting/Forge");
        bellows = GameObject.Find("Crafting/Bellows");
        coolingBarrel = GameObject.Find("Crafting/Barrel");
        hammer = GameObject.Find("Crafting/Hammer");

		heatSlider = heatSliderObject.GetComponent<Slider> ();
		hammerSlider = hammerSliderObject.GetComponent<Slider> ();
		timerSlider = timerSliderObject.GetComponent<Slider> ();
        furnaceSlider = furnaceSliderObject.GetComponent<Slider>();
        barrelSlider = barrelSliderObject.GetComponent<Slider>();
        bellowsSlider = GameObject.Find("Canvas/Bellows Slider").GetComponent<Slider>();

        hammerLevel = 1;
        anvilLevel = 1;
        forgeLevel = 1;
        grinderLevel = 1;
        sharpeningLevel = 1;
        polishingLevel = 1;
        barrelLevel = 1;

        bellowsPosition = homeBellowsPosition;

        Random.seed = (int)System.DateTime.Now.Ticks;

      resetCrafting();
    }

    public void testCrafting()
    {
        startCrafting("Sword", "Tin");
    }

    public void startCrafting(string item, string material)
    {
        itemType = item;
        materialType = material;
        stage.enabled = true;
        

        totalStages = timeMultiplier.getStageCount(itemType);

        nextStage();
    }

	void nextStage()
	{
		currentStage++;
		if (currentStage == totalStages)
		{
			endCrafting();
			return;
		}
        else
        {
            resetBetweenStages();
        }

        stage.text = "Stage: " + (currentStage+1) + "/" + totalStages;
		currentStageAbsVal = (timeMultiplier.getStage(itemType, currentStage));
        Debug.Log("Current stage abs val is:" + currentStageAbsVal);
		
		switch(currentStageAbsVal)
		{
			case 0:
				stageShaping();
				break;
			
			case 1:
				stageHardening();
				break;
			
			case 2:
				stageTempering();
				break;
				
			case 3:
				stagePolishing();
				break;
				
			case 4:
				stageSharpening();
				break;
				
			case 5:
				stageGrinding();
				break;
				
			default:
				Debug.Log("Error: currentStage is out of range for crafting process, current stage is " + currentStage);
                break;
		}
	}

	void endCrafting()
	{
        currentStage = -1;
        Debug.Log("lol endcrafting");
	}

    void Update()
    {
        if (bellowsSliderObject.activeSelf)
        {
            if (bellowsPosition < 2.0f)
            {
                bellowsPosition = bellowsSlider.value;

                if (bellowsPosition >= 2.0f)
                {
                    bellowsPump();
                    bellowsChange();
                }
            }
            else if (bellowsPosition >= 2.0f && bellowsPosition < 4.0f)
            {
                bellowsPosition = bellowsSlider.value;

                if (bellowsPosition < 2.0f)
                {
                    bellowsChange();
                }
                else if (bellowsPosition >= 4.0f)
                {
                    bellowsPump();
                    bellowsChange();
                }
            }
            else
            {
                bellowsPosition = bellowsSlider.value;
                if (bellowsPosition < 4.0f)
                {
                    bellowsChange();
                }
            }
        }
        if (barrelSliderObject.activeSelf)
        {
            if (barrelSlider.value > 80.0f)
            {
                heatSlider.value -= (Time.deltaTime * quenchingSliderChange);
            }
        }
        if (timerActive)
        {
            timerTimer += Time.deltaTime;
            timerSlider.value = timerTimer;
            if (timerTimer >= timerEndTime)
            {
                timerActive = false;
            }
        }
        if (annActive)
        {
            annTimer += Time.deltaTime;
            if (annTimer >= annEndTime)
            {
                resetAnnouncement();
            }
        }

        if (currentStage != -1)
        {
            if (currentStageAbsVal == 0)
            {
                if (!componentInBarrel)
                {
                    heatSlider.value -= (Time.deltaTime * heatSliderChange);
                }
                hammerSlider.value -= (Time.deltaTime * hammerSliderChange);
                if (timerSet && !timerActive && heatSlider.value > heatToStart && hammerSlider.value > hammerToStart)
                {
                    startTimer();
                    timeQuality = timeSync;
                }
                if (timerActive)
                {
                    if (timeQuality <= 0)
                    {
                        timeQuality = timeSync;
                        if (heatSlider.value > 25.0f && heatSlider.value < 75.0f)
                        {
                            itemQuality += 0.5f;
                        }
                        if (hammerSlider.value > 25.0f && hammerSlider.value < 75.0f)
                        {
                            itemQuality += 0.5f;
                        }
                    }

                    timeQuality -= Time.deltaTime;
                }
                if (!timerActive && !timerSet)
                {
                    nextStage();
                }
            }
            else if (currentStageAbsVal == 1)
            {
                if (!heated || !cooled)
                {
                    if (!componentInBarrel)
                    {
                        heatSlider.value -= (Time.deltaTime * heatSliderChange);
                    }
                    else
                    {
                        if (barrelSlider.value > 80.0f)
                        {
                            heatSlider.value -= (Time.deltaTime * quenchingSliderChange);
                        }
                        else
                        {
                            heatSlider.value -= (Time.deltaTime * heatSliderChange);
                        }
                    }
                    if (!timerActive)
                    {
                        timeQuality -= Time.deltaTime;
                        if (timeQuality <= 0)
                        {
                            timeQuality = timeSync;

                            itemQuality -= 1.0f;
                        }
                    }
                }
                if (heatSlider.value > 99.0f)
                {
                    heated = true;
                    setAnnouncement("Quench!", 3.0f);
                }
                if (heatSlider.value < 1.0f && heated)
                {
                    cooled = true;
                }
                if (heated && cooled)
                {
                    Debug.Log("Quality is: " + itemQuality);
                    craftingComponent.GetComponent<ComponentBehavior>().removeFromBarrel();
                    nextStage();
                }
            }
            else if (currentStageAbsVal == 2)
            {
                if (!componentInBarrel)
                {
                    heatSlider.value -= (Time.deltaTime * heatSliderChange);
                }
                else
                {
                    if (barrelSlider.value > 80.0f)
                    {
                        heatSlider.value -= (Time.deltaTime * quenchingSliderChange);
                    }
                    else
                    {
                        heatSlider.value -= (Time.deltaTime * heatSliderChange);
                    }
                }
            }
            else if (currentStageAbsVal == 3)
            {
                // polishing

                if (timerSet)
                {
                    startTimer();
                    polishTimer = 0;
                    resetShimmers();
                }

                if (timerActive && polishesNeeded > 0)
                {
                    polishTimer -= Time.deltaTime;

                    if (polishTimer <= 0)
                    {
                        do
                        {
                            shineSpot = Random.Range(1, 12);
                        } while (shineSpot == lastShine);

                        lastShine = shineSpot;

                        destoryShimmers();

                        switch (shineSpot)
                        {
                            case 1:
                                Instantiate(shine1);
                                shimmer1 = true;
                                break;
                            case 2:
                                Instantiate(shine2);
                                shimmer2 = true;
                                break;
                            case 3:
                                Instantiate(shine3);
                                shimmer3 = true;
                                break;
                            case 4:
                                Instantiate(shine4);
                                shimmer4 = true;
                                break;
                            case 5:
                                Instantiate(shine5);
                                shimmer5 = true;
                                break;
                            case 6:
                                Instantiate(shine6);
                                shimmer6 = true;
                                break;
                            case 7:
                                Instantiate(shine7);
                                shimmer7 = true;
                                break;
                            case 8:
                                Instantiate(shine8);
                                shimmer8 = true;
                                break;
                            case 9:
                                Instantiate(shine9);
                                shimmer9 = true;
                                break;
                            case 10:
                                Instantiate(shine10);
                                shimmer10 = true;
                                break;
                            case 11:
                                Instantiate(shine11);
                                shimmer11 = true;
                                break;
                            case 12:
                                Instantiate(shine12);
                                shimmer12 = true;
                                break;
                            default:
                                Debug.Log("Random shine integer outside of range");
                                break;
                        }

                        polishTimer = basePolishTime;
                    }
                }

                if (!timerActive && !timerSet)
                {
                    setAnnouncement("Polish Done", 3.0f);
                    destoryShimmers();
                    nextStage();
                }
                else if (polishesNeeded == 0)
                {
                    setAnnouncement("Polish Done", 3.0f);
                    timerActive = false;
                    destoryShimmers();
                    nextStage();
                }

            }
            else if (currentStageAbsVal == 4)
            {

            }
            else if (currentStageAbsVal == 5)
            {
                if (componentOnGrinder && timerSet)
                {
                    startTimer();
                    timeQuality = timeSync;
                }

                if (timerActive)
                {
                    // The first section is automated and creates imbalance on the component
                    if (grindCycle == false)
                    {
                        grindTime = Random.Range(2.0f, 5.0f);
                        grindCycle = true;
                        rotateRight = !rotateRight;
                    }

                    grindTime -= Time.deltaTime;
                    step = speed * Time.deltaTime;

                    if (rotateRight)
                    {
                        grinderGauge.transform.rotation = Quaternion.RotateTowards(grinderGauge.transform.rotation, tiltedRight.rotation, step);
                    }
                    else
                    {
                        grinderGauge.transform.rotation = Quaternion.RotateTowards(grinderGauge.transform.rotation, tiltedLeft.rotation, step);
                    }

                    if (grindTime <= 0.0f)
                    {
                        grindCycle = false;
                    }

                    // In this section the player controls the balance of the grinding process
                    counterStep = speed * 2 * Time.deltaTime;

                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        playerRotation = 0;
                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        playerRotation = 1;
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        playerRotation = 2;
                    }

                    if (playerRotation == 1)
                    {
                        grinderGauge.transform.rotation = Quaternion.RotateTowards(grinderGauge.transform.rotation, tiltedRight.rotation, counterStep);
                    }
                    else if (playerRotation == 2)
                    {
                        grinderGauge.transform.rotation = Quaternion.RotateTowards(grinderGauge.transform.rotation, tiltedLeft.rotation, counterStep);
                    }

                    if (timeQuality <= 0)
                    {
                        timeQuality = timeSync;
                        if (grinderGauge.GetComponent<RectTransform>().transform.rotation.z <= 0.04f && grinderGauge.GetComponent<RectTransform>().transform.rotation.z >= -0.04f)
                        {
                            Debug.Log(grinderGauge.GetComponent<RectTransform>().transform.rotation.z);
                            itemQuality += 1;
                        }
                        else if (grinderGauge.GetComponent<RectTransform>().transform.rotation.z <= 0.08f && grinderGauge.GetComponent<RectTransform>().transform.rotation.z >= -0.08f)
                        {
                            itemQuality += 0.5f;
                        }
                    }

                    timeQuality -= Time.deltaTime;
                }


                if (!timerActive && !timerSet)
                {
                    setAnnouncement("Grinding Done", 1.0f);
                    nextStage();
                }
            }
        }
    }
    void resetBetweenStages()
    {
        bellowsPosition = homeBellowsPosition;

        useAnvil = false;
        useForge = false;
        useHammer = false;
        useGrinder = false;
        useSharpener = false;
        usePolisher = false;
        useBarrel = false;

        bellowsSliderObject.SetActive(false);
        barrelSliderObject.SetActive(false);
        timerSliderObject.SetActive(false);
        hammerSliderObject.SetActive(false);
        heatSliderObject.SetActive(false);
        grinderGauge.SetActive(false);
        resetTimer();
    }

    void stageShaping()
    {
        soundController.PlayForgeAmbient();
        useAnvil = true;
        useForge = true;
        useBarrel = true;

        bellowsSliderObject.SetActive(true);
        timerSliderObject.SetActive(true);
        hammerSliderObject.SetActive(true);
        heatSliderObject.SetActive(true);

        hammerSliderBackground.sprite = hammerDiff1;
        heatSliderBackground.sprite = heatDiff1;

        setTimer((float)timeMultiplier.getStageTime(currentStageAbsVal) * (float)timeMultiplier.getMult(itemType, materialType));

        possibleItemQuality += timerEndTime;
    }


    void stageHardening()
    {
        useForge = true;
        useBarrel = true;

        bellowsSliderObject.SetActive(true);
        heatSliderObject.SetActive(true);
        heatSliderBackground.sprite = hardenDiff1;

        timerSliderObject.SetActive(true);

        heated = false;
        cooled = false;

        heatSliderBackground.sprite = heatDiff1;

        setTimer((float)timeMultiplier.getStageTime(currentStageAbsVal) * (float)timeMultiplier.getMult(itemType, materialType));
        startTimer();
        possibleItemQuality += timerEndTime;
        itemQuality += timerEndTime;
        timeQuality = timeSync;

        setAnnouncement("Heat!", 3.0f);
    }

    void stageTempering()
    {
        switchRoom();

        bellowsSliderObject.SetActive(true);
        useForge = true;
        useBarrel = true;
        heatSliderObject.SetActive(true);
        heatSliderBackground.sprite = temperDiff1;

        timerSliderObject.SetActive(true);

        heated = false;
        cooled = false;

        setTimer((float)timeMultiplier.getStageTime(currentStageAbsVal) * (float)timeMultiplier.getMult(itemType, materialType));
        startTimer();

        possibleItemQuality += timerEndTime;
        itemQuality += timerEndTime;
        timeQuality = timeSync;

        setAnnouncement("Heat!", 3.0f);
    }

    void stageGrinding()
    {
        switchRoom();

        useGrinder = true;

        grinderGauge.SetActive(true);
        timerSliderObject.SetActive(true);

        grinded = false;
        setTimer((float)timeMultiplier.getStageTime(currentStageAbsVal) * (float)timeMultiplier.getMult(itemType, materialType));
        timerSliderObject.GetComponent<Slider>().value = 0;

        possibleItemQuality += timerEndTime;

        setAnnouncement("Grind!", 3.0f);
    }

    void stageSharpening()
    {

    }

    void stagePolishing()
    {
        setPolishCount(1);
        setPolishesNeeded(30);

        craftingCamera.transform.position = new Vector3(background3.transform.position.x, background3.transform.position.y, background3.transform.position.z - 10);

        usePolisher = true;

        timerSliderObject.SetActive(true);

        setTimer((float)timeMultiplier.getStageTime(currentStageAbsVal) * (float)timeMultiplier.getMult(itemType, materialType));

        timerSliderObject.GetComponent<Slider>().value = 0;

        possibleItemQuality += polishesNeeded * 1;

        setAnnouncement("Polish!", 3.0f);
    }




    public void hammerHitOnAnvil()
    {
        if (currentStageAbsVal == 0)
        {
            if (componentOnAnvil)
            {
                hammerSlider.value += hammerHitIncrease;
                soundController.PlayHammerHit();
            }
        }
    }

    private void bellowsChange()
    {
        if (bellowsSlider.value >= 4.0f)
        {
            bellows.GetComponent<SpriteRenderer>().sprite = bellowsClosed;
            soundController.PlayBellowsDown();
        }
        else if (bellowsSlider.value >= 2.0f && bellowsSlider.value < 4.0f)
        {
            bellows.GetComponent<SpriteRenderer>().sprite = bellowsMid;
        }
        else
        {
            bellows.GetComponent<SpriteRenderer>().sprite = bellowsOpen;
        }
    }

    private void bellowsPump()
    {
        if (componentOnForge)
        {
            heatSlider.value += bellowsHitIncrese;
        }
    }

    public void toggleComponentOnForge()
    {
        componentOnForge = !componentOnForge;
    }

    public void toggleComponentOnAnvil()
    {
        componentOnAnvil = !componentOnAnvil;
    }

    public void toggleComponentInBarrel()
    {
        if (componentInBarrel)
        {
            barrelSliderObject.SetActive(false);
            craftingComponent.SetActive(true);
        }
        else if (!componentInBarrel)
        {
            barrelSlider.gameObject.SetActive(true);
            craftingComponent.SetActive(false);
        }
        componentInBarrel = !componentInBarrel;
    }

    public void toggleComponentOnGrinder()
    {
        componentOnGrinder = !componentOnGrinder;
    }

    public bool isCrafting()
    {
        if (currentStage == -1)
        {
            return false;
        }

        return true;
    }

    public void switchRoom()
    {
        craftingComponent.GetComponent<ComponentBehavior>().switchRoom();
        if (workshopFront == true)
        {
            craftingCamera.transform.position = new Vector3(background2.transform.position.x, background2.transform.position.y, background2.transform.position.z - 10);
            workshopFront = false;
        }
        else if (workshopFront == false)
        {
            craftingCamera.transform.position = new Vector3(background1.transform.position.x, background2.transform.position.y, background2.transform.position.z - 10);
            workshopFront = true;
        }
    }

    //PUBLIC METHODS TO FIND IF THE COMPONENT IS ALLOWED TO INTERACT WITH A CERTAIN CRAFTING TOOL

    public bool canUseAnvil()
    {
        return useAnvil;
    }

    public bool canUseForge()
    {
        return useForge;
    }

    public bool canUseBarrel()
    {
        return useBarrel;
    }

    public bool canUseGrinder()
    {
        return useGrinder;
    }

    public bool canUsePolisher()
    {
        return usePolisher;
    }

    public bool canUseSharpener()
    {
        return useSharpener;
    }

    private void resetShimmers()
    {
        shineSpot = 0;
        shimmer = false;
        shimmer1 = false;
        shimmer2 = false;
        shimmer3 = false;
        shimmer4 = false;
        shimmer5 = false;
        shimmer6 = false;
        shimmer7 = false;
        shimmer8 = false;
        shimmer9 = false;
        shimmer10 = false;
        shimmer11 = false;
        shimmer12 = false;
    }

    private void destoryShimmers()
    {
        if (shimmer1)
        {
            Destroy(GameObject.Find("Shimmer 1(Clone)"));
            shimmer1 = false;
        }
        else if (shimmer2)
        {
            Destroy(GameObject.Find("Shimmer 2(Clone)"));
            shimmer2 = false;
        }
        else if (shimmer3)
        {
            Destroy(GameObject.Find("Shimmer 3(Clone)"));
            shimmer3 = false;
        }
        else if (shimmer4)
        {
            Destroy(GameObject.Find("Shimmer 4(Clone)"));
            shimmer4 = false;
        }
        else if (shimmer5)
        {
            Destroy(GameObject.Find("Shimmer 5(Clone)"));
            shimmer5 = false;
        }
        else if (shimmer6)
        {
            Destroy(GameObject.Find("Shimmer 6(Clone)"));
            shimmer6 = false;
        }
        else if (shimmer7)
        {
            Destroy(GameObject.Find("Shimmer 7(Clone)"));
            shimmer7 = false;
        }
        else if (shimmer8)
        {
            Destroy(GameObject.Find("Shimmer 8(Clone)"));
            shimmer8 = false;
        }
        else if (shimmer9)
        {
            Destroy(GameObject.Find("Shimmer 9(Clone)"));
            shimmer9 = false;
        }
        else if (shimmer10)
        {
            Destroy(GameObject.Find("Shimmer 10(Clone)"));
            shimmer10 = false;
        }
        else if (shimmer11)
        {
            Destroy(GameObject.Find("Shimmer 11(Clone)"));
            shimmer11 = false;
        }
        else if (shimmer12)
        {
            Destroy(GameObject.Find("Shimmer 12(Clone)"));
            shimmer12 = false;
        }

    }

    public void polishUpdateQuality()
    {
        polishCount--;

        if (polishCount <= 0)
        {
            itemQuality += 5;
            resetShimmerCycle();
            setPolishesNeeded(polishesNeeded - 1);
            Debug.Log("Quality is: " + itemQuality);
        }
    }

    public void resetShimmerCycle()
    {
        polishTimer = 0;
        polishCount = 1;
    }
    
    public void setPolishCount(int polish)
    {
        polishCount = polish;
    }

    public void setPolishesNeeded (int polishes)
    {
        polishesNeeded = polishes;
    }
}
