using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CraftRoutine : MonoBehaviour 
{
    public GameObject componentPrefab;

    private GameObject testObj;
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
    //private bool workshopFront = true;

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
    private GameObject craftingComponent; //eventually the game will programmatically instantiate the GameObject that you will use during the current crafting session, for now we will assign it a test object
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
    public GameObject[] swordShines;
    private bool[] swordShimmers;
    private int lastShine;
    private int polishCount;
    private int polishesNeeded;
    private GameObject polishStone1;

    //SHARPENING STAGE

    private GameObject file;
    private GameObject swordLeft;
    private GameObject swordRight;
    private float sharpenCycleQuality;
    private const int totalFilesNeeded = 12;
    private int currentFiles;
    private int sharpeningCycles;
    private int sharpeningCyclesNeeded;
    private bool spawnShimmersNeeded;
    private bool top;
    private bool firstCycle;
    private bool isSharpened;

    //OTHER STUFF

    private CreateInventory createInventory;
    private float bellowsPosition;
    private const float homeBellowsPosition = 6.0f;

    private SoundController soundController;

    //CRAFT STARTUP STUFF

    private GameObject startButton;
    private GameObject itemTypeButton;
    private GameObject materialTypeButton;
    private GameObject types;
    private GameObject materials;
    private GameObject[] itemTypeButtons;
    private GameObject[] materialTypeButtons;
    private const int itemTypes = 9;
    private const int materialTypes = 10;


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
        // Start Crafting Setup
        //private GameObject startButton;
        //private GameObject itemTypeButtons[];
        //private GameObject materialTypeButtons[];
        startButton = GameObject.Find("Canvas/Crafting Startup/Start Crafting");
        itemTypeButton = GameObject.Find("Canvas/Crafting Startup/Item Type Button");
        materialTypeButton = GameObject.Find("Canvas/Crafting Startup/Material Type Button");
        types = GameObject.Find("Canvas/Crafting Startup/Types");
        materials = GameObject.Find("Canvas/Crafting Startup/Materials");
        itemTypeButtons = new GameObject[itemTypes];
        materialTypeButtons = new GameObject[materialTypes];
        itemTypeButtons[0] = GameObject.Find("Canvas/Crafting Startup/Types/Sword Button");
        itemTypeButtons[1] = GameObject.Find("Canvas/Crafting Startup/Types/Shield Button");
        itemTypeButtons[2] = GameObject.Find("Canvas/Crafting Startup/Types/Breastplate Button");
        itemTypeButtons[3] = GameObject.Find("Canvas/Crafting Startup/Types/Greaves Button");
        itemTypeButtons[4] = GameObject.Find("Canvas/Crafting Startup/Types/Helm Button");
        itemTypeButtons[5] = GameObject.Find("Canvas/Crafting Startup/Types/Gloves Button");
        itemTypeButtons[6] = GameObject.Find("Canvas/Crafting Startup/Types/Boots Button");
        itemTypeButtons[7] = GameObject.Find("Canvas/Crafting Startup/Types/Bracers Button");
        itemTypeButtons[8] = GameObject.Find("Canvas/Crafting Startup/Types/Pauldrons Button");
        materialTypeButtons[0] = GameObject.Find("Canvas/Crafting Startup/Materials/Tin Button");
        materialTypeButtons[1] = GameObject.Find("Canvas/Crafting Startup/Materials/Copper Button");
        materialTypeButtons[2] = GameObject.Find("Canvas/Crafting Startup/Materials/Bronze Button");
        materialTypeButtons[3] = GameObject.Find("Canvas/Crafting Startup/Materials/Brass Button");
        materialTypeButtons[4] = GameObject.Find("Canvas/Crafting Startup/Materials/Iron Button");
        materialTypeButtons[5] = GameObject.Find("Canvas/Crafting Startup/Materials/Blackened Iron Button");
        materialTypeButtons[6] = GameObject.Find("Canvas/Crafting Startup/Materials/Steel Button");
        materialTypeButtons[7] = GameObject.Find("Canvas/Crafting Startup/Materials/Steel Alloy L1 Button");
        materialTypeButtons[8] = GameObject.Find("Canvas/Crafting Startup/Materials/Steel Alloy L2 Button");
        materialTypeButtons[9] = GameObject.Find("Canvas/Crafting Startup/Materials/Titanium Button");

        

        soundController = this.GetComponent<SoundController>();
        createInventory = GameObject.Find("Inventory/InventoryController").GetComponent<CreateInventory>();

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

        // POLISHING STAGE SETUP

        swordShines = new GameObject[12];
        swordShimmers = new bool[12];
        polishStone1 = GameObject.Find("Crafting/Polishing Stone 1");

        for (int i = 0; i < swordShines.Length; i++)
        {
            swordShines[i] = GameObject.Find("Shimmers/Sword/Shimmer " + (i + 1));
        }

        // SHARPENING STAGE SETUP

        file = GameObject.Find("Crafting/File");
        swordLeft = GameObject.Find("Sharpening/Sword Left");
        swordRight = GameObject.Find("Sharpening/Sword Right");
        spawnShimmersNeeded = true;
        top = true;
        sharpeningCycles = 0;
        sharpeningCyclesNeeded = 0;
        sharpenCycleQuality = 0;
        firstCycle = true;
        isSharpened = false;


        Random.seed = (int)System.DateTime.Now.Ticks;

        resetCrafting();
    }

    /*public void testCrafting()
    {
        startCrafting("Sword", "Tin");
    }*/

    public void startCrafting(string item, string material)
    {
        if (currentStage == -1)
        {
            itemType = item;
            materialType = material;
            stage.enabled = true;

            totalStages = timeMultiplier.getStageCount(itemType);

            instantiateComponent();

            nextStage();
        }
    }

	void nextStage()
	{
        Debug.Log("Total Item Quality: " + itemQuality + "/" + possibleItemQuality);


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
        //Debug.Log("Current stage abs val is:" + currentStageAbsVal);
		
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
        resetCrafting();
        Debug.Log("Total Item Quality: " + itemQuality + "/" + possibleItemQuality);
        switchScene("workshop front");
        CreateItem();
        CreateItem();
	}

    void Update()
    {
        if (bellowsSliderObject.activeSelf)
        {
            if (bellowsPosition < 2.0f)
            {
                bellowsPosition = bellowsSlider.value;

                if (bellowsPosition >= 2.0f && bellowsPosition < 4.0f)
                {
                    //Debug.Log("First Bellows Pump");
                    bellowsPump();
                    bellowsChange();
                }
                else if (bellowsPosition >= 4.0f)
                {
                    //Debug.Log("Two pumps at once");
                    bellowsPump();
                    bellowsChange();
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
                    //Debug.Log("Second Bellows Pump");
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
            // SHAPING STAGE
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
                    nextStage();
                }
            }
            // TEMPERING STAGE
            else if (currentStageAbsVal == 2)
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
                if (heatSlider.value > 70.0f)
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
                    nextStage();
                }
//                 if (!componentInBarrel)
//                 {
//                     heatSlider.value -= (Time.deltaTime * heatSliderChange);
//                 }
//                 else
//                 {
//                     if (barrelSlider.value > 80.0f)
//                     {
//                         heatSlider.value -= (Time.deltaTime * quenchingSliderChange);
//                     }
//                     else
//                     {
//                         heatSlider.value -= (Time.deltaTime * heatSliderChange);
//                     }
//                 }
            }
            // POLISHING STAGE
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
                            shineSpot = Random.Range(0, 11);
                        } while (shineSpot == lastShine);

                        lastShine = shineSpot;

                        destoryShimmers();

                        GameObject tempObj = Instantiate(swordShines[shineSpot]) as GameObject;
                        tempObj.SetActive(true);

                        swordShimmers[shineSpot] = true;
                        

                        if (shineSpot < 0 || shineSpot > 11)
                        {
                            Debug.Log("Shinespot out of range!");
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
            // SHARPENING STAGE
            else if (currentStageAbsVal == 4)
            {
                if (sharpeningCycles >= sharpeningCyclesNeeded)
                {
                    timerActive = false;
                    isSharpened = true;
                    setAnnouncement("Sharpening done!", 1.0f);
                    spawnShimmersNeeded = false;
                    nextStage();
                }
                else if (!timerActive && !timerSet)
                {
                    nextStage();
                }

                if (!isSharpened && timerActive)
                {
                    if (currentFiles <= 0)
                    {
                        resetCurrentFiles();
                        spawnShimmersNeeded = true;
                    }

                    if (spawnShimmersNeeded)
                    {
                        setSharpenSide(top);
                    }
                }
            }
            // GRINDING STAGE
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
                        grinderGauge.GetComponent<Slider>().value += step;
                    }
                    else
                    {
                        grinderGauge.transform.rotation = Quaternion.RotateTowards(grinderGauge.transform.rotation, tiltedLeft.rotation, step);
                        grinderGauge.GetComponent<Slider>().value -= step;
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
                        grinderGauge.GetComponent<Slider>().value += counterStep;
                    }
                    else if (playerRotation == 2)
                    {
                        grinderGauge.transform.rotation = Quaternion.RotateTowards(grinderGauge.transform.rotation, tiltedLeft.rotation, counterStep);
                        grinderGauge.GetComponent<Slider>().value -= counterStep;
                    }

                    if (timeQuality <= 0)
                    {
                        timeQuality = timeSync;
                        if (grinderGauge.GetComponent<Slider>().value > 25 && grinderGauge.GetComponent<Slider>().value < 35)
                        {
                            itemQuality += 1;
                        }
                        else if (grinderGauge.GetComponent<Slider>().value > 20 && grinderGauge.GetComponent<Slider>().value < 40)
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
        if (componentInBarrel)
        {
            toggleComponentInBarrel();
        }

        bellowsPosition = homeBellowsPosition;
        barrelSlider.value = 0.0f;

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
        switchScene("workshop front");
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
        switchScene("workshop front");
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
        switchScene("workshop front");

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
        switchScene("workshop back");

        useGrinder = true;

        grinderGauge.SetActive(true);
        timerSliderObject.SetActive(true);
        grinderGauge.GetComponent<Slider>().value = grinderGauge.GetComponent<Slider>().maxValue / 2;

        grinded = false;
        setTimer((float)timeMultiplier.getStageTime(currentStageAbsVal) * (float)timeMultiplier.getMult(itemType, materialType));
        timerSliderObject.GetComponent<Slider>().value = 0;

        possibleItemQuality += timerEndTime;

        setAnnouncement("Grind!", 3.0f);
    }

    void stageSharpening()
    {
        switchScene("workbench");
        polishStone1.SetActive(false);
        file.SetActive(true);
        SetSharpeningCycles(5);

        timerSliderObject.SetActive(true);

        setTimer((float)timeMultiplier.getStageTime(currentStageAbsVal) * (float)timeMultiplier.getMult(itemType, materialType));
        timerSliderObject.GetComponent<Slider>().value = 0;
        setAnnouncement("Sharpen!", 3.0f);

        startTimer();
    }

    void stagePolishing()
    {
        DestroyAllShimmer();
        switchScene("workbench");
        setPolishCount(1);
        setPolishesNeeded(30);
        polishStone1.SetActive(true);
        file.SetActive(false);


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
                soundController.PlayHammerHit();
                hammerSlider.value += hammerHitIncrease;
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
            craftingComponent.GetComponent<ComponentBehavior>().removeFromBarrel();
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

    public bool isComponentInbarrel()
    {
        return componentInBarrel;
    }

    public bool isCrafting()
    {
        if (currentStage == -1)
        {
            return false;
        }

        return true;
    }

    public void switchScene(string scene)
    {
        switch(scene)
        {
            case "workshop front":
                craftingCamera.transform.position = new Vector3(background1.transform.position.x, background1.transform.position.y, - 10);
                craftingComponent.GetComponent<ComponentBehavior>().switchRoom(true);
                break;
            case "workshop back":
                craftingCamera.transform.position = new Vector3(background2.transform.position.x, background2.transform.position.y, - 10);
                craftingComponent.GetComponent<ComponentBehavior>().switchRoom(false);
                break;
            case "workbench":
                craftingCamera.transform.position = new Vector3(background3.transform.position.x, background3.transform.position.y, -10);
                break;
            default:
                Debug.Log("Scene not found");
                break;
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

        for (int i = 0; i < swordShimmers.Length; i++)
        {
            swordShimmers[i] = false;
        }
    }

    private void destoryShimmers()
    {
        for (int i = 0; i < swordShimmers.Length; i++)
        {
            if (swordShimmers[i])
            {
                Destroy(GameObject.Find("Shimmer " + (i + 1) + "(Clone)"));
                swordShimmers[i] = false;
            }
        }
    }

    public void polishUpdateQuality()
    {
        polishCount--;

        if (polishCount <= 0)
        {
            itemQuality += 1;
            resetShimmerCycle();
            setPolishesNeeded(polishesNeeded - 1);
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

    public void updateFileStage(float point)
    {
        sharpenCycleQuality += point;
        currentFiles--;
    }

    public void resetCurrentFiles()
    {
        currentFiles = totalFilesNeeded;
    }

    public void setSharpenSide(bool right)
    {
        GameObject tempObj;

        if (!isSharpened)
        {
            if (right)
            {
                top = false;
                spawnShimmersNeeded = false;
                for (int i = 1; i <= 12; i++)
                {
                    tempObj = Instantiate(GameObject.Find("Sharpening/Sword Right/Shimmer " + i)) as GameObject;
                    tempObj.SetActive(true);
                }

                if (!firstCycle)
                {
                    sharpeningCycles++;
                    UpdateSharpenQuality();
                }

                if (firstCycle)
                {
                    firstCycle = false;
                    sharpeningCycles = 0;
                }
            }

            else
            {
                top = true;
                spawnShimmersNeeded = false;

                for (int i = 13; i <= 24; i++)
                {
                    tempObj = Instantiate(GameObject.Find("Sharpening/Sword Left/Shimmer " + i)) as GameObject;
                    tempObj.SetActive(true);
                }
            }
        }
    }

    public void SetSharpeningCycles(int cycles)
    {
        sharpeningCyclesNeeded = cycles;
    }

    private void UpdateSharpenQuality()
    {
        sharpenCycleQuality /= 24;
        itemQuality += 5 * sharpenCycleQuality;
        sharpenCycleQuality = 0;
        possibleItemQuality += 5;
    }

    private void DestroyAllShimmer()
    {
        for (int i = 1; i < 25; i++)
        {
            Destroy(GameObject.Find("Shimmer " + i + "(Clone)"));
        }

        Debug.Log("Destroy all called");
    }

    private void CreateItem()
    {
        GameObject tempObj = Instantiate(GameObject.Find("Equipment/Test Sword")) as GameObject;
        double powerLevel = timeMultiplier.getBasePowerLevel(itemType, materialType);
        double qualityPercentage = itemQuality / possibleItemQuality;
        if (qualityPercentage > 0.99f)
        {
            tempObj.GetComponent<ItemScript>().SetItemStats(materialType, itemType, "Ultimate", (int)(powerLevel * 2.0f));
        }
        else if (qualityPercentage > 0.95f && qualityPercentage <= 0.99f)
        {
            tempObj.GetComponent<ItemScript>().SetItemStats(materialType, itemType, "Exceptional", (int)(powerLevel * 1.6f));
        }
        else if(qualityPercentage > 0.80f && qualityPercentage <= 0.95f)
        {
            tempObj.GetComponent<ItemScript>().SetItemStats(materialType, itemType, "Good", (int)(powerLevel * 1.4f));
        }
        else if(qualityPercentage > 0.60f && qualityPercentage <= 0.80f)
        {
             tempObj.GetComponent<ItemScript>().SetItemStats(materialType, itemType, "Average", (int)(powerLevel * 1.2f));
        }
        else if(qualityPercentage > 0.40f && qualityPercentage <= 0.60f)
        {
             tempObj.GetComponent<ItemScript>().SetItemStats(materialType, itemType, "Crude", (int)(powerLevel));
        }
        else if (qualityPercentage <= 0.40f)
        {
            setAnnouncement("You failes.", 5.0f);
            return;
        }
        else
        {
            Debug.Log("Item generated does not exist, weird?");
        }

        createInventory.AddNewItem(tempObj);
    }

    public void ShowItemMaterialButtons()
    {
        itemTypeButton.SetActive(true);
        materialTypeButton.SetActive(true);
    }

    public void SelectItemType()
    {
        types.SetActive(true);
    }

    public void SelectMaterialType()
    {
        materials.SetActive(true);
    }



//REFERENCES TO IMAGES FOR INSTANTIATING THE CRAFTING COMPONENT

    public Sprite sword;
    public void instantiateComponent()
    {
        craftingComponent = Instantiate(componentPrefab);

        switch(itemType)
        {
            case "Sword":
                craftingComponent.GetComponent<ComponentBehavior>().setImage(sword);
                break;
            default:
                craftingComponent.GetComponent<ComponentBehavior>().setImage(sword);
                break;
        }

        
    }
}
