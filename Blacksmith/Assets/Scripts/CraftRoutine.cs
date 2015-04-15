using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CraftRoutine : MonoBehaviour 
{
    //sprites to load various background difficulties into the hammer and heat bars
	public Sprite heatDiff1;
	public Sprite heatDiff2;
	public Sprite heatDiff3;
	public Sprite hammerDiff1;
	public Sprite hammerDiff2;
	public Sprite hammerDiff3;

	public float heatSliderChange;
	public float hammerSliderChange;
	public float timeSliderChange;
	public float furnaceSliderChange;
	public float quenchingSliderChange;

	public GameObject heatSliderObject;
	public GameObject hammerSliderObject;
	public GameObject timerSliderObject;
	public GameObject furnaceSliderObject;
	private Slider heatSlider;
	private Slider hammerSlider;
	private Slider timerSlider;
	private Slider furnaceSlider;

    public GameObject forge;
    public GameObject bellows;
    public GameObject craftingComponent; //eventually the game will programmatically instantiate the GameObject that you will use during the current crafting session, for now we will assign it a test object
    public GameObject coolingBarrel;
    public GameObject hammer;
    public GameObject anvil;

    private Image heatSliderBackground;
    private Image hammerSliderBackground;

    public StageTimeMatrix timeMultiplier;

    public Text stage;
    public Text popUpText;
    public Text results;

    private const float fullSlider = 60.0f;
    private const float emptySlider = 0.0f;
    private const float baseTimeStage1 = 60.0f;
	private const float hammerHitIncrease = 10.0f;
	private const float bellowsHitIncrese = 5.0f;
	private const float heatToStart = 25.0f;
	private const float hammerToStart = 25.0f;

    private bool furnaceIsMelting;
    private bool componentOnAnvil;
    private bool componentInBarrel;
    private bool componentOnForge;

    private float countDown = 3.0f;
    private float quality = 0.0f;
    private float timeSync = 1.0f;


	private string itemType;
	private string materialType;
	
    private int currentStage;
    private int currentStageAbsVal; // gets the integer value of the stage itself, not the number of the stage in order of stages for the current item
    private int totalStages;
    private double currentStageTime;



    void resetCrafting()
    {
        currentStage = -1;

        componentOnAnvil = false;
        componentOnForge = false;
        componentInBarrel = false;

        heatSliderObject.SetActive(false);
        hammerSliderObject.SetActive(false);
        timerSliderObject.SetActive(false);
        //hammer.SetActive(false);
        //anvil.SetActive(false);
        //coolingBarrel.SetActive(false);
        //bellows.SetActive(false);
        //forge.SetActive(false);


        stage.enabled = false;
        popUpText.enabled = false;

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
        heatSliderBackground = GameObject.Find("/Canvas/Heat Gauge/Background").GetComponent<Image>();
        hammerSliderBackground = GameObject.Find("Canvas/Hammer Gauge/Background").GetComponent<Image>();

		heatSlider = heatSliderObject.GetComponent<Slider> ();
		hammerSlider = hammerSliderObject.GetComponent<Slider> ();
		timerSlider = timerSliderObject.GetComponent<Slider> ();
		furnaceSlider = furnaceSliderObject.GetComponent<Slider> ();

        resetCrafting();



        //timerSlider.maxValue = baseTimeStage1;
        
        //results.enabled = false;
    }

    public void startCrafting(string item, string material)
    {
	itemType = item;
	materialType = material;
	
		
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
		currentStageAbsVal = (timeMultiplier.getStage(itemType, currentStage));
		
		switch(currentStage)
		{
			case 0:
				stageShaping();
				break;
			
			case 1:
				//stageHardening();
				break;
			
			case 2:
				//stageTempering();
				break;
				
			case 3:
				//stagePolishing();
				break;
				
			case 4:
				//stageSharpening();
				break;
				
			case 5:
				//stageGrinding();
				break;
				
			default:
				Debug.Log("Error: currentStage is out of range for crafting process, current stage is " + currentStage);
                break;
		}
	}

	void endCrafting()
	{
		
	}

	void Update () 
    {
        while (currentStage != -1)
        {

        }

        /*IsTimerDone();

        if (timeSync > 0)
        {
            timeSync -= Time.deltaTime;
        }
        

        if (isCrafting || isBeginningCrafting)
        {
            if (needToStartCraft)
            {
                SetPopUpText("Stage 1");
                stage.enabled = true;
                NextStage();
                needToStartCraft = false;
            }

            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
                SetPopUpTextActive(true);
            }

            else if (countDown <= 0)
            {
                SetPopUpTextActive(false);
            }

			if (componentInBarrel)
			{
				heatSlider.value -= Time.deltaTime * quenchingSliderChange;
			}
			else
			{
				heatSlider.value -= Time.deltaTime * heatSliderChange;
			} 
			
			hammerSlider.value -= Time.deltaTime * hammerSliderChange;       
        }

        if (isCrafting && !isBeginningCrafting)
        {
            timerSlider.value += Time.deltaTime;
            if (timeSync <= 0)
            {
                qualityUpdate();
                timeSync = 1.0f;
            }
        }
        else if (isBeginningCrafting && !isCrafting)
        {
            if ((heatSlider.value > heatToStart) && (hammerSlider.value > hammerToStart))
            {
                isBeginningCrafting = !isBeginningCrafting;
                isCrafting = !isCrafting;
            }
        }
        else if (!isCrafting && !isBeginningCrafting)
        {
            needToStartCraft = true;
            stage.enabled = false;
            displayResults();
        }

        if (furnaceIsMelting)
        {
            furnaceSlider.value += furnaceSliderChange;
        }*/
    }

    void stageShaping()
    {
        hammerSliderObject.SetActive(true);
        heatSliderObject.SetActive(true);

    }

    public void hammerHitOnAnvil()
    {
       // if ((isCrafting || isBeginningCrafting) && componentOnAnvil)
        {
            hammerSlider.value += hammerHitIncrease;
        }
    }

    public void bellowsPump()
    {
        //if ((isCrafting || isBeginningCrafting) && componentOnForge)
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
        componentInBarrel = !componentInBarrel;
    }

    /*public void craftingToggle()
    {
		if (isBeginningCrafting) 
		{
			isBeginningCrafting = false;
			isCrafting = true;
		}
        else if (isCrafting)
        {
            isCrafting = false;
            heatSlider.value = emptySlider;
            hammerSlider.value = emptySlider;
            timerSlider.value = emptySlider;
            needToStartCraft = true;
            
        }
        else if(!isCrafting && !isBeginningCrafting)
        {
            isBeginningCrafting = true;
            curStage = 0;
        }
    }

    public void furnaceToggle()
    {
        if (furnaceIsMelting)
        {
            furnaceIsMelting = false;
            furnaceSlider.value = fullSlider;
        }
        else if(!furnaceIsMelting)
        {
            furnaceIsMelting = true;
            furnaceSlider.value = emptySlider;
        }
    }

    void NextStage()
    {
        curStage++;
        ResetCountDown();
        timerSlider.maxValue = baseTimeStage1 * (float)timeMultiplier.getMultiplier("Sword", "Tin");
        stage.text = "Stage " + curStage + "/" + totalStages;
    }

    void ResetCountDown()
    {
        countDown = 3;
    }

    void SetPopUpText (string phrase)
    {
        popUpText.text = phrase;
    }

    void IsTimerDone ()
    {
        if (timerSlider.value == timerSlider.maxValue)
        {
            isCrafting = false;
            timerSlider.value = 0;
        }
    }

    void SetPopUpTextActive (bool change)
    {
        popUpText.enabled = change;
    }

    void qualityUpdate ()
    {
        if (heatSlider.value > 25 && heatSlider.value < 75)
        {
            quality += 0.5f;
        }
        if (hammerSlider.value > 25 && hammerSlider.value < 75)
        {
            quality += 0.5f;
        }

        results.text = "Quality: " + quality;
    }

    void displayResults()
    {
        //results.enabled = true;
        results.text = "Quality: " + quality;
    }*/
}
