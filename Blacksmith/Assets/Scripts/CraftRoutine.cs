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

    public Sprite hardenSliderGauge;

    public Sprite bellowsClosed;
    public Sprite bellowsMid;
    public Sprite bellowsOpen;

	public float heatSliderChange;
	public float hammerSliderChange;
	public float timeSliderChange;
	public float furnaceSliderChange;
	public float quenchingSliderChange;

    public Button townButton;
    public Button rearButton;
    public Button frontButton;
    public Button workshopButton;

    public Canvas overlayCanvas;
    public Canvas workshopCanvas;

    public GameObject townCamera;
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

    public DataScript dataScript;

    public Text stage;
    public Text popUpText;
    public Text results;
    public Text cycleScore;

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

    //SHAPING STAGE

    public ParticleSystem forgeOne;
    public ParticleSystem forgeTwo;
    public ParticleSystem forgeThree;
    public ParticleSystem forgeBurst;
    public ParticleSystem barrelSteam;
    public ParticleSystem barrelSplash;
    private bool dunk;

    //HARDERNING STAGE

    private bool heated;
    private bool cooled;

    //GRINDING STAGE

    public GameObject grinderGauge;
    public GameObject grinderSparksBase;
    public GameObject grinderSparks;
    private Text tempTxt;
    private const int speed = 70;
    private const float componentSpeed = 1.0f;
    private int grindCycles;
    private float step;
    private float componentStep;
    private bool slideRight;

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

    private FileBehavior fileBehavior;
    public GameObject excellentBurst;
    public GameObject goodBurst;
    public GameObject badBurst;
    private GameObject file;
    private GameObject swordLeft;
    private GameObject swordRight;
    private GameObject sharpeningComponent;
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
    private GameObject requiredMaterialsWindow;
    private GameObject[] itemTypeButtons;
    private GameObject[] materialTypeButtons;
    private Text[] requiredMaterialTexts;
    private Button cancelButton;
    private Button craftButton;
    private const int itemTypes = 9;
    private const int materialTypes = 10;
    private bool materialSet;
    private bool itemSet;
    private bool[] knownMaterials;
    private bool[] knownItems;
    private bool itemMaterials;
    private bool itemSub;
    private bool materialSub;
    private string[] requiredNames;
    private int[] requiredQuantites;

    //CRAFT RESULT STUFF
    private GameObject craftResultBG;
    private GameObject craftResultDesc;
    private GameObject craftResultInfo;
    private GameObject craftResultIcon;
    private const int resultEndTimer = 5;
    private float resultTimer;
    private bool resultTimerActive;

    //TUTORIAL STUFF
    public bool paused;
    public bool needUnPaused;
    public float pauseTimer;
    //private bool tutorial;
    private TutorialRoutine tutorialRoutine;
    public bool needSetAnnouncement;

    void Start()
    {
        // Start Crafting Setup
        paused = false;
        needUnPaused = false;
        pauseTimer = 0.0f;
        dunk = false;
        grindCycles = 0;

        fileBehavior = GameObject.Find("Crafting/File").GetComponent<FileBehavior>();
        needSetAnnouncement = false;
        tutorialRoutine = GameObject.Find("GameController").GetComponent<TutorialRoutine>();
        startButton = GameObject.Find("Canvas/Crafting Startup/Start Crafting");
        itemTypeButton = GameObject.Find("Canvas/Crafting Startup/Item Type Button");
        materialTypeButton = GameObject.Find("Canvas/Crafting Startup/Material Type Button");
        types = GameObject.Find("Canvas/Crafting Startup/Types");
        materials = GameObject.Find("Canvas/Crafting Startup/Materials");
        itemTypeButtons = new GameObject[itemTypes];
        materialTypeButtons = new GameObject[materialTypes];
        itemTypeButtons[0] = GameObject.Find("Canvas/Crafting Startup/Types/Sword Button");
        itemTypeButtons[1] = GameObject.Find("Canvas/Crafting Startup/Types/Shield Button");
        itemTypeButtons[1].GetComponent<Button>().interactable = false;
        itemTypeButtons[2] = GameObject.Find("Canvas/Crafting Startup/Types/Breastplate Button");
        itemTypeButtons[2].GetComponent<Button>().interactable = false;
        itemTypeButtons[3] = GameObject.Find("Canvas/Crafting Startup/Types/Greaves Button");
        itemTypeButtons[3].GetComponent<Button>().interactable = false;
        itemTypeButtons[4] = GameObject.Find("Canvas/Crafting Startup/Types/Helm Button");
        itemTypeButtons[4].GetComponent<Button>().interactable = false;
        itemTypeButtons[5] = GameObject.Find("Canvas/Crafting Startup/Types/Gloves Button");
        itemTypeButtons[5].GetComponent<Button>().interactable = false;
        itemTypeButtons[6] = GameObject.Find("Canvas/Crafting Startup/Types/Boots Button");
        itemTypeButtons[6].GetComponent<Button>().interactable = false;
        itemTypeButtons[7] = GameObject.Find("Canvas/Crafting Startup/Types/Bracers Button");
        itemTypeButtons[7].GetComponent<Button>().interactable = false;
        itemTypeButtons[8] = GameObject.Find("Canvas/Crafting Startup/Types/Pauldrons Button");
        itemTypeButtons[8].GetComponent<Button>().interactable = false;
        materialTypeButtons[0] = GameObject.Find("Canvas/Crafting Startup/Materials/Tin Button");
        materialTypeButtons[1] = GameObject.Find("Canvas/Crafting Startup/Materials/Copper Button");
        materialTypeButtons[1].GetComponent<Button>().interactable = false;
        materialTypeButtons[2] = GameObject.Find("Canvas/Crafting Startup/Materials/Bronze Button");
        materialTypeButtons[2].GetComponent<Button>().interactable = false;
        materialTypeButtons[3] = GameObject.Find("Canvas/Crafting Startup/Materials/Brass Button");
        materialTypeButtons[3].GetComponent<Button>().interactable = false;
        materialTypeButtons[4] = GameObject.Find("Canvas/Crafting Startup/Materials/Iron Button");
        materialTypeButtons[4].GetComponent<Button>().interactable = false;
        materialTypeButtons[5] = GameObject.Find("Canvas/Crafting Startup/Materials/Blackened Iron Button");
        materialTypeButtons[5].GetComponent<Button>().interactable = false;
        materialTypeButtons[6] = GameObject.Find("Canvas/Crafting Startup/Materials/Steel Button");
        materialTypeButtons[6].GetComponent<Button>().interactable = false;
        materialTypeButtons[7] = GameObject.Find("Canvas/Crafting Startup/Materials/Steel Alloy L1 Button");
        materialTypeButtons[7].GetComponent<Button>().interactable = false;
        materialTypeButtons[8] = GameObject.Find("Canvas/Crafting Startup/Materials/Steel Alloy L2 Button");
        materialTypeButtons[8].GetComponent<Button>().interactable = false;
        materialTypeButtons[9] = GameObject.Find("Canvas/Crafting Startup/Materials/Titanium Button");
        materialTypeButtons[9].GetComponent<Button>().interactable = false;
        materialSet = false;
        itemSet = false;
        knownMaterials = new bool[materialTypes];
        knownMaterials[0] = true;
        for (int i = 1; i < materialTypes; i++)
        {
            knownMaterials[i] = false;
        }
        knownItems = new bool[itemTypes];
        knownItems[0] = true;
        for (int i = 1; i < itemTypes; i++)
        {
            knownItems[i] = false;
        }

        craftResultBG = GameObject.Find("Crafting/Crafting Result/Crafting Result Background");
        craftResultIcon = GameObject.Find("Crafting/Crafting Result/Crafting Result Icons");
        craftResultDesc = GameObject.Find("Canvas/Crafting Result/Description");
        craftResultInfo = GameObject.Find("Canvas/Crafting Result/Info");
        resultTimerActive = false;

        soundController = GameObject.Find("GameController").GetComponent<SoundController>();
        createInventory = GameObject.Find("Inventory/InventoryController").GetComponent<CreateInventory>();

        heatSliderBackground = GameObject.Find("/Canvas/Heat Gauge/Background").GetComponent<Image>();
        hammerSliderBackground = GameObject.Find("Canvas/Hammer Gauge/Background").GetComponent<Image>();

        anvil = GameObject.Find("Crafting/Anvil");
        forge = GameObject.Find("Crafting/Forge");
        bellows = GameObject.Find("Crafting/Bellows");
        coolingBarrel = GameObject.Find("Crafting/Barrel");
        hammer = GameObject.Find("Crafting/Hammer");

        heatSlider = heatSliderObject.GetComponent<Slider>();
        hammerSlider = hammerSliderObject.GetComponent<Slider>();
        timerSlider = timerSliderObject.GetComponent<Slider>();
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

        swordShines = new GameObject[12];
        swordShimmers = new bool[12];
        polishStone1 = GameObject.Find("Crafting/Polishing Stone 1");

        for (int i = 0; i < swordShines.Length; i++)
        {
            swordShines[i] = GameObject.Find("Shimmers/Sword/Shimmer " + (i + 1));
        }

        file = GameObject.Find("Crafting/File");
        swordLeft = GameObject.Find("Sharpening/Sword Left");
        swordRight = GameObject.Find("Sharpening/Sword Right");
        sharpeningComponent = GameObject.Find("Crafting/Polishing Component");
        requiredMaterialsWindow = GameObject.Find("Canvas/Required Materials Background");
        requiredMaterialTexts = new Text[14];
        requiredMaterialTexts[0] = GameObject.Find("Canvas/Required Materials Background/Required Materials").GetComponent<Text>();
        requiredMaterialTexts[1] = GameObject.Find("Canvas/Required Materials Background/Craft Item").GetComponent<Text>();
        requiredMaterialTexts[2] = GameObject.Find("Canvas/Required Materials Background/Required Materials 1").GetComponent<Text>();
        requiredMaterialTexts[3] = GameObject.Find("Canvas/Required Materials Background/Total Materials 1").GetComponent<Text>();
        requiredMaterialTexts[4] = GameObject.Find("Canvas/Required Materials Background/Required Materials 2").GetComponent<Text>();
        requiredMaterialTexts[5] = GameObject.Find("Canvas/Required Materials Background/Total Materials 2").GetComponent<Text>();
        requiredMaterialTexts[6] = GameObject.Find("Canvas/Required Materials Background/Required Materials 3").GetComponent<Text>();
        requiredMaterialTexts[7] = GameObject.Find("Canvas/Required Materials Background/Total Materials 3").GetComponent<Text>();
        requiredMaterialTexts[8] = GameObject.Find("Canvas/Required Materials Background/Required Materials 4").GetComponent<Text>();
        requiredMaterialTexts[9] = GameObject.Find("Canvas/Required Materials Background/Total Materials 4").GetComponent<Text>();
        requiredMaterialTexts[10] = GameObject.Find("Canvas/Required Materials Background/Required Materials 5").GetComponent<Text>();
        requiredMaterialTexts[11] = GameObject.Find("Canvas/Required Materials Background/Total Materials 5").GetComponent<Text>();
        requiredMaterialTexts[12] = GameObject.Find("Canvas/Required Materials Background/Required Materials 6").GetComponent<Text>();
        requiredMaterialTexts[13] = GameObject.Find("Canvas/Required Materials Background/Total Materials 6").GetComponent<Text>();
        for (int i = 0; i < 14; i++)
        {
            requiredMaterialTexts[i].text = "";
        }
        cancelButton = GameObject.Find("Canvas/Required Materials Background/Cancel Button").GetComponent<Button>();
        craftButton = GameObject.Find("Canvas/Required Materials Background/Craft Button").GetComponent<Button>();
        requiredMaterialsWindow.SetActive(false);

        requiredMaterialsWindow.SetActive(false);
        itemMaterials = false;
        itemSub = false;
        materialSub = false;

        resetCrafting();
    }

    void resetSliders()
    {
        heatSlider.value = 0.0f;
        hammerSlider.value = 0.0f;
        timerSlider.value = 0.0f;
        furnaceSlider.value = 0.0f; //REALLY need to figure out what scripting is going to manage the furnace and pass information into this object to manage the display slider
    }

//***********************************************************************************************************************
//******************************************** TIMER AND ANNOUNCEMENT METHODS
//***********************************************************************************************************************
    
    void setTimer(float time)
    {
        timerTimer = 0.0f;
        timerEndTime = time;
        timerSlider.maxValue = timerEndTime;
        timerSet = true;
    }

    void startTimer()
    {
        timerSet = false;
        timerActive = true;
        Debug.Log("startTimer set timerActive true");
    }

    void timerManager()
    {
        timerTimer += Time.deltaTime;
        timerSlider.value = timerTimer;
        if (timerTimer >= timerEndTime)
        {
            timerActive = false;
        }
    }

    void resetTimer()
    {
        timerTimer = 0.0f;
        timerEndTime = 0.0f;
        timerSet = false;
        timerActive = false;
    }

    void setAnnouncement(string announcement, float time)
    {
        popUpText.enabled = true;
        popUpText.text = announcement;
        annEndTime = time;
        annTimer = 0.0f;
        annActive = true;
    }

    void annManager()
    {
        annTimer += Time.deltaTime;
        if (annTimer >= annEndTime)
        {
            resetAnnouncement();
        }
    }

    void craftResultManager()
    {
        resultTimer += Time.deltaTime;
        if (resultTimer >= resultEndTimer)
        {
            stopShowCraftResult();
        }
    }

    void resetAnnouncement()
    {
        popUpText.text = "";
        annEndTime = 0.0f;
        annTimer = 0.0f;
        annActive = false;
        popUpText.enabled = false;
    }

//************************************************************************************************************
//******************************************* CRAFTING MANAGEMENT METHODS
//************************************************************************************************************

    public void StartCrafting()
    {
        if (itemSet && materialSet && currentStage == -1)
        {
            soundController.stopAllMusic();
            soundController.PlayCraftingMusic();
            startButton.SetActive(false);
            materialTypeButton.SetActive(false);
            itemTypeButton.SetActive(false);
            townButton.gameObject.SetActive(false);
            rearButton.gameObject.SetActive(false);
            itemSet = false;
            materialSet = false;
            stage.enabled = true;

            totalStages = dataScript.getStageCount(itemType);

            instantiateComponent();
            Debug.Log(craftingComponent.name);
            nextStage();
        }
    }

    void endCrafting()
    {
        soundController.StopAllCrafingNoise();
        soundController.playWorkshopMusic();
        resetCrafting();
        Debug.Log("Total Item Quality: " + itemQuality + "/" + possibleItemQuality);
        switchScene("workshop front");
        CreateItem();
        Destroy(craftingComponent);
        startButton.SetActive(true);
        startButton.GetComponentInChildren<Text>().text = "Start Craft Process";
        startButton.GetComponent<Image>().color = new Vector4(255, 255, 255, 255);
        townButton.gameObject.SetActive(true);
        rearButton.gameObject.SetActive(true);
        fileBehavior.resetLocation();
    }

    void resetCrafting()
    {
        currentStage = -1;

        componentOnAnvil = false;
        componentOnForge = false;
        componentInBarrel = false;
        componentOnGrinder = false;

        resetBetweenStages();

        slideRight = true;
       
        spawnShimmersNeeded = true;
        top = true;
        sharpeningCycles = 0;
        sharpeningCyclesNeeded = 0;
        sharpenCycleQuality = 0;
        firstCycle = true;
        isSharpened = false;

        stage.enabled = false;
        popUpText.enabled = false;
        resetTimer();
        resetAnnouncement();
        resetSliders();
    }

	void nextStage()
	{
        //Debug.Log("Total Item Quality: " + itemQuality + "/" + possibleItemQuality);

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
		currentStageAbsVal = (dataScript.getStage(itemType, currentStage));
        Debug.Log("Current stage abs val is:" + currentStageAbsVal);
		
		switch(currentStageAbsVal)
		{
			case 0:
				stageShapingSetup();
				break;
			
			case 1:
                stageHardeningSetup();
				break;
			
			case 2:
                stageTemperingSetup();
				break;
				
			case 3:
                stagePolishingSetup();
				break;
				
			case 4:
                stageSharpeningSetup();
				break;
				
			case 5:
                stageGrindingSetup();
				break;
				
			default:
				Debug.Log("Error: currentStage is out of range for crafting process, current stage is " + currentStage);
                break;
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

    void Update()
    {

        if (pauseTimer > 0)
        {
            pauseTimer -= Time.deltaTime;
        }

        if (pauseTimer <= 0 && needUnPaused)
        {
            needUnPaused = false;
            paused = false;
            pauseTimer = 0.0f;
        }

        if (!paused)
        {
            if (bellowsSliderObject.activeSelf)
            {
                bellowsManager();
            }
            if (barrelSliderObject.activeSelf)
            {
                barrelManager();
            }
            if (timerActive)
            {
                timerManager();
            }
            if (annActive)
            {
                annManager();
            }
            if (resultTimerActive)
            {
                craftResultManager();
            }

            if (currentStage != -1)
            {
                // SHAPING STAGE
                if (currentStageAbsVal == 0)
                {
                    stageShapingManager();
                }
                // HARDENING STAGE
                else if (currentStageAbsVal == 1)
                {
                    stageHardeningManager();
                }
                // TEMPERING STAGE
                else if (currentStageAbsVal == 2)
                {
                    stageTemperingManager();
                }
                // POLISHING STAGE
                else if (currentStageAbsVal == 3)
                {
                    stagePolishingManager();
                }
                // SHARPENING STAGE
                else if (currentStageAbsVal == 4)
                {
                    stageSharpeningManager();
                }
                // GRINDING STAGE
                else if (currentStageAbsVal == 5)
                {
                    stageGrindingManager();
                }
            }
        }
    }

//********************************************************************************************************
//************************************** STAGE SETUP AND MANAGEMENT FUNCTIONS
//********************************************************************************************************
    void stageShapingSetup()
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

        setTimer((float)dataScript.getStageTime(currentStageAbsVal) * (float)dataScript.getMult(itemType, materialType));

        possibleItemQuality += timerEndTime;
    }

    void stageShapingManager()
    {
        //Tutorial steps
        tutorialHelper(6);
        if (!paused)
        {
            tutorialHelper(7);
        }
        if (!paused)
        {
            tutorialHelper(8);
        }
        if (!paused)
        {
            tutorialHelper(9);
        }
        if (!paused)
        {
            tutorialHelper(10);
        }
        if (heatSlider.value >= 70)
        {
            tutorialHelper(12);
        }
        //End tutorial steps
        if (heatSlider.value > 25.0f)
        {
            forgeOne.Play();
        }
        if (heatSlider.value < 25.0f && forgeOne.isPlaying)
        {
            forgeOne.Stop();
        }

        if (heatSlider.value > 75.0f)
        {
            forgeTwo.Play();
            forgeThree.Play();
        }
        if (heatSlider.value < 75.0f && (forgeTwo.isPlaying && forgeThree.isPlaying))
        {
            forgeTwo.Stop();
            forgeThree.Stop();
        }
        if (!componentInBarrel)
        {
            heatSlider.value -= (Time.deltaTime * heatSliderChange);
        }
        hammerSlider.value -= (Time.deltaTime * hammerSliderChange);
        if (timerSet && !timerActive && heatSlider.value > heatToStart && hammerSlider.value > hammerToStart)
        {
            startTimer();
            timeQuality = timeSync;
            tutorialHelper(14);
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
            tutorialHelper(15);
            nextStage();
            barrelSteam.Stop();
        }
    }

    void stageHardeningSetup()
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

        //heatSliderBackground.sprite = heatDiff1;

        setTimer((float)dataScript.getStageTime(currentStageAbsVal) * (float)dataScript.getMult(itemType, materialType));
        startTimer();
        possibleItemQuality += timerEndTime;
        itemQuality += timerEndTime;
        timeQuality = timeSync;

        setAnnouncement("Heat!", 3.0f);
    }

    void stageHardeningManager()
    {
        if (!paused)
        {
            tutorialHelper(16);
        }

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
                    soundController.playCooling();
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
            tutorialHelper(17);
        }
        if (heatSlider.value < 1.0f && heated)
        {
            cooled = true;
        }
        if (heated && cooled)
        {
            nextStage();
            tutorialHelper(19);
        }
    }

    void stageTemperingSetup()
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

        setTimer((float)dataScript.getStageTime(currentStageAbsVal) * (float)dataScript.getMult(itemType, materialType));
        startTimer();

        possibleItemQuality += timerEndTime;
        itemQuality += timerEndTime;
        timeQuality = timeSync;

        //setAnnouncement("Heat!", 3.0f);
        needSetAnnouncement = true;
    }

    void stageTemperingManager()
    {

        if (needSetAnnouncement && !paused)
        {
            setAnnouncement("Heat!", 2.0f);
            needSetAnnouncement = false;
        }

        if (!paused)
        {
            tutorialHelper(23);
        }
        if (!paused)
        {
            tutorialHelper(24);
        }

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
                     soundController.playCooling();
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
             tutorialHelper(25);
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

    void stagePolishingSetup()
    {
        DestroyAllShimmer();
        switchScene("workbench");
        setPolishCount(1);
        setPolishesNeeded(30);
        polishStone1.SetActive(true);
        file.SetActive(false);


        usePolisher = true;

        timerSliderObject.SetActive(true);

        setTimer((float)dataScript.getStageTime(currentStageAbsVal) * (float)dataScript.getMult(itemType, materialType));

        timerSliderObject.GetComponent<Slider>().value = 0;

        possibleItemQuality += polishesNeeded * 1;

        setAnnouncement("Polish!", 3.0f);
    }

    void stagePolishingManager()
    {
        tutorialHelper(29);
        if (!paused)
        {
            tutorialHelper(30);
        }
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

    void stageSharpeningSetup()
    {
        switchScene("workbench");
        polishStone1.SetActive(false);
        file.SetActive(true);
        SetSharpeningCycles(5);

        timerSliderObject.SetActive(true);

        setTimer((float)dataScript.getStageTime(currentStageAbsVal) * (float)dataScript.getMult(itemType, materialType));
        timerSliderObject.GetComponent<Slider>().value = 0;
        setAnnouncement("Sharpen!", 3.0f);

        startTimer();
    }

    void stageSharpeningManager()
    {
        tutorialHelper(26);
        if (!paused)
        {
            tutorialHelper(27);
        }
        if (file.GetComponent<FileBehavior>().getFileSet() == 24)
        {
            tutorialHelper(28);
        }

        if (sharpeningCycles >= sharpeningCyclesNeeded)
        {
            timerActive = false;
            isSharpened = true;
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

    void stageGrindingSetup()
    {
        switchScene("workshop back");

        useGrinder = true;
        timerSet = true;
        grinderGauge.SetActive(true);
        timerSliderObject.SetActive(true);
        grinderGauge.GetComponent<Slider>().value = grinderGauge.GetComponent<Slider>().maxValue / 2;

        grindCycles = 0;
        setTimer((float)dataScript.getStageTime(currentStageAbsVal) * (float)dataScript.getMult(itemType, materialType));
        timerSliderObject.GetComponent<Slider>().value = 0;

        possibleItemQuality += 50;

        setAnnouncement("Grind!", 3.0f);
    }

    void stageGrindingManager()
    {
        tutorialHelper(20);
        if (tutorialRoutine.tutorialComplete(21))
        {
            tutorialHelper(22);
        }

        if (componentOnGrinder && timerSet)
        {
            startTimer();
            timeQuality = timeSync;
        }

        if (timerActive)
        {
            step = speed * Time.deltaTime;
            componentStep = componentSpeed * Time.deltaTime;

            
            if (slideRight)
            {
                craftingComponent.transform.position = new Vector3(craftingComponent.transform.position.x + componentStep, craftingComponent.transform.position.y, craftingComponent.transform.position.z);
                grinderGauge.GetComponent<Slider>().value += step;
                if (Input.GetKeyDown(KeyCode.A))
                {
                    displayGrindCycleScore();
                    if (grinderGauge.GetComponent<Slider>().value >= 80 && grinderGauge.GetComponent<Slider>().value <= 85)
                    {
                        itemQuality += 2.5f;
                        tempTxt.text = "Excellent";
                    }
                    else if (grinderGauge.GetComponent<Slider>().value >= 75 && grinderGauge.GetComponent<Slider>().value <= 90)
                    {
                        itemQuality += 1;
                        tempTxt.text = "Good";
                    }
                    else
                    {
                        tempTxt.text = "Bad";
                    }
                    slideRight = !slideRight;
                    grindCycles++;
                    Debug.Log("Grind Cycles: " + grindCycles);
                }
                else if(grinderGauge.GetComponent<Slider>().value >= 99.9f)
                {
                    displayGrindCycleScore();
                    itemQuality -= 1;
                    tempTxt.text = "Terrible";
                    slideRight = !slideRight;
                    grindCycles++;
                    Debug.Log("Grind Cycles: " + grindCycles);
                }
            }
            else
            {
                craftingComponent.transform.position = new Vector3(craftingComponent.transform.position.x - componentStep, craftingComponent.transform.position.y, craftingComponent.transform.position.z);
                grinderGauge.GetComponent<Slider>().value -= step;
                if (Input.GetKeyDown(KeyCode.D))
                {
                    displayGrindCycleScore();
                    if (grinderGauge.GetComponent<Slider>().value >= 15 && grinderGauge.GetComponent<Slider>().value <= 20)
                    {
                        itemQuality += 2.5f;
                        tempTxt.text = "Excellent";
                    }
                    else if (grinderGauge.GetComponent<Slider>().value >= 10 && grinderGauge.GetComponent<Slider>().value <= 25)
                    {
                        itemQuality += 1;
                        tempTxt.text = "Good";
                    }
                    else
                    {
                        tempTxt.text = "Bad";
                    }
                    slideRight = !slideRight;
                    grindCycles++;
                    Debug.Log("Grind Cycles: " + grindCycles);
                }
                else if(grinderGauge.GetComponent<Slider>().value <= 0.1f)
                {
                    displayGrindCycleScore();
                    itemQuality -= 1;
                    tempTxt.text = "Terrible";
                    slideRight = !slideRight;
                    grindCycles++;
                    Debug.Log("Grind Cycles: " + grindCycles);
                }
            }
        }
        if (!timerActive && !timerSet)
        {
            nextStage();
        }
        else if (grindCycles >= 20)
        {
            timerActive = false;
            nextStage();
        }
    }

//*************************************************************************************************************************
//******************************************* CRAFTING TOOL MANAGEMENT FUNCTIONS
//*************************************************************************************************************************

    public void hammerHitOnAnvil(float magnitude)
    {
        if (currentStageAbsVal == 0)
        {
            if (componentOnAnvil)
            {
                soundController.PlayHammerHit();
                Debug.Log(magnitude);
                hammerSlider.value += hammerHitIncrease * magnitude;
            }
        }
    }

    private void bellowsManager()
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

    private void bellowsChange()
    {
        if (bellowsSlider.value >= 4.0f)
        {
            bellows.GetComponent<SpriteRenderer>().sprite = bellowsClosed;
            soundController.playBellowsBlow();
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
            if (forgeBurst.isPlaying)
            {
                forgeBurst.Stop();
            }

            forgeBurst.Play();
        }
    }

    public void toggleComponentOnForge()
    {
        componentOnForge = !componentOnForge;

        if (!paused)
        {
            tutorialHelper(11);
        }
    }

    public void toggleComponentOnAnvil()
    {
        componentOnAnvil = !componentOnAnvil;

        if (!paused)
        {
            tutorialHelper(13);
        }
    }

    public void toggleComponentInBarrel()
    {
        if (componentInBarrel)
        {
            barrelSliderObject.SetActive(false);
            craftingComponent.SetActive(true);
            craftingComponent.GetComponent<ComponentBehavior>().removeFromBarrel();
            barrelSteam.Stop();
        }
        else if (!componentInBarrel)
        {
            barrelSlider.gameObject.SetActive(true);
            craftingComponent.SetActive(false);
        }
        componentInBarrel = !componentInBarrel;

        if (tutorialRoutine.tutorialComplete(17))
        {
            tutorialHelper(18);
        }
    }

    private void barrelManager()
    {
        if (barrelSlider.value < 80.0f)
        {
            dunk = true;
        }

        if (barrelSlider.value > 80.0f)
        {
            heatSlider.value -= (Time.deltaTime * quenchingSliderChange);
            if (!barrelSteam.isPlaying)
            {
                barrelSteam.Play();
            }

            if (dunk)
            {
                if (barrelSplash.isPlaying)
                {
                    barrelSplash.Stop();
                }
                barrelSplash.Play();

                dunk = false;
            }
        }

        
    }

    public void toggleComponentOnGrinder()
    {
        componentOnGrinder = !componentOnGrinder;
        grinderSparksBase.SetActive(!grinderSparksBase.activeSelf);
        soundController.playGrinding();
        tutorialHelper(21);
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
            case "town":
                soundController.stopAllMusic();
                soundController.playTownMusic();
                craftingCamera.transform.position = new Vector3(background1.transform.position.x, background1.transform.position.y, -10);
                craftingCamera.SetActive(false);
                townCamera.SetActive(true);
                workshopButton.gameObject.SetActive(true);
                overlayCanvas.worldCamera = townCamera.GetComponent<Camera>();
                break;
            case "rear":
                craftingCamera.transform.position = new Vector3(background2.transform.position.x, background2.transform.position.y, -10);
                townButton.gameObject.SetActive(false);
                rearButton.gameObject.SetActive(false);
                frontButton.gameObject.SetActive(true);
                break;
            case "front":
                craftingCamera.transform.position = new Vector3(background1.transform.position.x, background1.transform.position.y, -10);
                townButton.gameObject.SetActive(true);
                rearButton.gameObject.SetActive(true);
                frontButton.gameObject.SetActive(false);
                break;
            case "workshop":
                soundController.stopAllMusic();
                soundController.playWorkshopMusic();
                townCamera.SetActive(false);
                craftingCamera.SetActive(true);
                workshopButton.gameObject.SetActive(false);
                overlayCanvas.worldCamera = craftingCamera.GetComponent<Camera>();
                break;
            default:
                Debug.Log("Scene not found");
                break;
        }
    }

//************************************************************************************************************************
//************************************* ALLOWABLE COMPONENT INTERACTION GETTERS
//************************************************************************************************************************

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

//******************************************************************************************************************
//******************************************* POLISHING STAGE HELPER METHODS
//******************************************************************************************************************

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
        tutorialHelper(31);
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

//****************************************************************************************************************************
//******************************************* SHARPENING STAGE HELPER METHODS
//****************************************************************************************************************************

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
        if (sharpenCycleQuality >= 0.9f)
        {
            displaySharpenCycleScore("Excellent");
            GameObject tempBurst;
            tempBurst = Instantiate(excellentBurst) as GameObject;
            Destroy(tempBurst, 2.0f);
        }
        else if (sharpenCycleQuality >= 0.8f)
        {
            displaySharpenCycleScore("Good");
            GameObject tempBurst;
            tempBurst = Instantiate(goodBurst) as GameObject;
            Destroy(tempBurst, 2.0f);
        }
        else if (sharpenCycleQuality >= 0.7f)
        {
            displaySharpenCycleScore("Bad");
            GameObject tempBurst;
            tempBurst = Instantiate(badBurst) as GameObject;
            Destroy(tempBurst, 2.0f);
        }
        else
        {
            displaySharpenCycleScore("Terrible");
            GameObject tempBurst;
            tempBurst = Instantiate(badBurst) as GameObject;
            Destroy(tempBurst, 2.0f);
        }
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

//**********************************************************************************************************************
//********************************** INTERFACE BUTTON MANAGEMENT 
//**********************************************************************************************************************

    public void ShowItemMaterialButtons()
    {
        if (!itemMaterials)
        {
            itemTypeButton.SetActive(true);
            materialTypeButton.SetActive(true);
            itemMaterials = true;
            SetItemButton();
            SetMaterialButton();
            startButton.transform.GetChild(0).GetComponent<Text>().text = "Reset Craft Process";
        }
        else
        {
            itemTypeButton.SetActive(false);
            materialTypeButton.SetActive(false);
            itemMaterials = false;
            startButton.transform.GetChild(0).GetComponent<Text>().text = "Start Craft Process";
        }

        if (itemSub)
        {
            types.SetActive(false);
            itemSub = false;
        }
        else if (materialSub)
        {
            materials.SetActive(false);
            materialSub = false;
        }

        if (!materialSet || !itemSet)
        {
            materialSet = false;
            itemSet = false;
        }

        tutorialHelper(2);
    }

    public void SelectItemType()
    {
        if (!materials.activeSelf)
        {
            types.SetActive(!types.activeSelf);
        }

        itemSub = true;
        tutorialHelper(3);
    }

    public void SelectMaterialType()
    {
        if (!types.activeSelf)
        {
            materials.SetActive(!materials.activeSelf);
        }

        materialSub = true;
        tutorialHelper(4);
    }
     
    public void SetMaterialButton(Sprite image)
    {
        materialTypeButton.GetComponent<Image>().sprite = image;
        SelectMaterialType();
        materialTypeButton.GetComponentInChildren<Text>().text = "";
        materialSet = true;
        if (itemSet)
        {
            requiredMaterialsWindow.SetActive(true);
            setRequiredMaterials();
            tutorialHelper(5);
        }
    }

    void SetMaterialButton()
    {
        materialTypeButton.GetComponent<Image>().sprite = startButton.GetComponent<Image>().sprite;
        materialTypeButton.GetComponentInChildren<Text>().text = "Material";
    }

    public void SetMaterial(string material)
    {
        materialType = material;
    }

    public void removeMaterial()
    {

    }

    public void SetItemButton(Sprite image)
    {
        itemTypeButton.GetComponent<Image>().sprite = image;
        SelectItemType();
        itemTypeButton.GetComponentInChildren<Text>().text = "";
        itemSet = true;
        if (materialSet)
        {
            requiredMaterialsWindow.SetActive(true);
            setRequiredMaterials();
            tutorialHelper(5);
        }
    }

    void SetItemButton()
    {
        itemTypeButton.GetComponent<Image>().sprite = startButton.GetComponent<Image>().sprite;
        itemTypeButton.GetComponentInChildren<Text>().text = "Item";
    }

    public void SetItem(string item)
    {
        itemType = item;
    }

    void setRequiredMaterials()
    {
        char tempChar;

        requiredNames = dataScript.getRequiredItemsToCraft(itemType, materialType);
        Debug.Log("Required Names: " + requiredNames);
        foreach (string stuff in requiredNames)
        {
            Debug.Log(stuff);
        }
        requiredQuantites = new int[requiredNames.Length];

        for (int i = 0; i < requiredNames.Length; i++)
        {
            tempChar = requiredNames[i][0];
            requiredQuantites[i] = (int)tempChar;
            requiredNames[i] = requiredNames[0].Remove(0);
            requiredMaterialTexts[(i * 2) + 2].text = requiredNames[i] + " X " + requiredQuantites[i];
            requiredMaterialTexts[(i * 2) + 3].text = "" + createInventory.getQuantity(requiredNames[i]);
        }
    }

//*****************************************************************************************************************************
//************************************************* INSTANTIATION METHODS (COMPONENT AND FINAL ITEM)
//*****************************************************************************************************************************

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

    private void CreateItem()
    {
        GameObject tempObj = Instantiate(GameObject.Find("Equipment/Test Sword")) as GameObject;
        double powerLevel = dataScript.getBasePowerLevel(itemType, materialType);
        double qualityPercentage = itemQuality / possibleItemQuality;
        if (qualityPercentage > 0.99f)
        {
            tempObj.GetComponent<ItemScript>().SetItemStats(materialType, itemType, "Ultimate", (int)(powerLevel * 2.0f));
        }
        else if (qualityPercentage > 0.95f && qualityPercentage <= 0.99f)
        {
            tempObj.GetComponent<ItemScript>().SetItemStats(materialType, itemType, "Exceptional", (int)(powerLevel * 1.6f));
        }
        else if (qualityPercentage > 0.80f && qualityPercentage <= 0.95f)
        {
            tempObj.GetComponent<ItemScript>().SetItemStats(materialType, itemType, "Good", (int)(powerLevel * 1.4f));
        }
        else if (qualityPercentage > 0.60f && qualityPercentage <= 0.80f)
        {
            tempObj.GetComponent<ItemScript>().SetItemStats(materialType, itemType, "Average", (int)(powerLevel * 1.2f));
        }
        else if (qualityPercentage > 0.40f && qualityPercentage <= 0.60f)
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

        showCraftResult(tempObj);

        createInventory.addCraftedItem(tempObj);

        tutorialHelper(32);
        
    }

    private void displayGrindCycleScore()
    {
        tempTxt = Instantiate(cycleScore) as Text;
        tempTxt.transform.SetParent(workshopCanvas.transform);
        tempTxt.transform.localScale = new Vector3(1, 1, 1);
        tempTxt.transform.position = new Vector3(grinderGauge.transform.position.x, grinderGauge.transform.position.y + 0.2f, grinderGauge.transform.position.z);
    }

    private void displaySharpenCycleScore(string result)
    {
        tempTxt = Instantiate(cycleScore) as Text;
        tempTxt.transform.SetParent(workshopCanvas.transform);
        tempTxt.transform.localScale = new Vector3(1, 1, 1);
        tempTxt.transform.position = new Vector3(sharpeningComponent.transform.position.x, sharpeningComponent.transform.position.y + 0.2f, sharpeningComponent.transform.position.z - 7);
        tempTxt.text = result;
    }

    private void showCraftResult(GameObject newObj)
    {
        craftResultBG.SetActive(true);
        craftResultDesc.SetActive(true);
        craftResultIcon.SetActive(true);
        craftResultInfo.SetActive(true);
        craftResultDesc.GetComponent<Text>().text = newObj.GetComponent<ItemScript>().GetItemDescription();
        resultTimer = 0;
        resultTimerActive = true;
    }

    private void stopShowCraftResult()
    {
        tutorialHelper(33);
        craftResultBG.SetActive(false);
        craftResultDesc.SetActive(false);
        craftResultIcon.SetActive(false);
        craftResultInfo.SetActive(false);
    }

    private void resetResultTimer()
    {
        resultTimer = 10;
        resultTimerActive = false;
    }

    public void Pause()
    {
        paused = !paused;
    }

    public bool isPaused()
    {
        return paused;
    }

    public void timedPause(float time)
    {
        pauseTimer = time;
        needUnPaused = true;
        paused = true;
    }

    public int getCurrentStageAbsoluteValue()
    {
        return currentStageAbsVal;
    }

    private void tutorialHelper(int step)
    {
        if (!tutorialRoutine.tutorialComplete(step))
        {
            tutorialRoutine.tutorialMachine(step);
        }
    }

    public GameObject getComponent()
    {
        return craftingComponent;
    }
}
