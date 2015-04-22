﻿using UnityEngine;
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

    public GameObject craftingCamera;
    public GameObject background1;
    public GameObject background2;
    private bool workshopFront = true;

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
    //private const double baseTimeStage1 = 60.0f;
	private const float hammerHitIncrease = 10.0f;
	private const float bellowsHitIncrese = 5.0f;
	private const float heatToStart = 25.0f;
	private const float hammerToStart = 25.0f;

    private bool furnaceIsMelting;
    private bool componentOnAnvil;
    private bool componentInBarrel;
    private bool componentOnForge;
    private bool componentOnGrinder;

    private float countDown = 3.0f;
    private float quality;
    private const float timeSync = 1.0f;
    private float timeQuality;

    public float itemQuality;
    public float possibleItemQuality;
	private string itemType;
	private string materialType;
	
    private int currentStage;
    private int currentStageAbsVal; // gets the integer value of the stage itself, not the number of the stage in order of stages for the current item
    private int totalStages;
    private double currentStageTime;

    private string annText;
    private bool annActive;
    private float annEndTime;
    private float annTimer;

    private bool timerSet;
    private bool timerActive;
    private float timerEndTime;
    private float timerTimer;

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
        annText = announcement;
        annEndTime = time;
        annTimer = 0.0f;
        annActive = true;
    }

    void resetAnnouncement()
    {
        annText = "";
        annEndTime = 0.0f;
        annTimer = 0.0f;
        annActive = false;
    }

    void resetCrafting()
    {
        currentStage = -1;

        componentOnAnvil = false;
        componentOnForge = false;
        componentInBarrel = false;
        componentOnGrinder = false;

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
		
	}

	void Update () 
    {
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
                annActive = false;
            }
        }

        if (currentStage != -1)
        {
            if (currentStageAbsVal == 0)
            {
                if (componentInBarrel)
                {
                    heatSlider.value -= (Time.deltaTime * quenchingSliderChange); ;
                }
                else
                {
                    heatSlider.value -= (Time.deltaTime * heatSliderChange);
                }
                hammerSlider.value -= (Time.deltaTime * hammerSliderChange);
                if (timerSet && !timerActive && heatSlider.value > heatToStart && hammerSlider.value > hammerToStart)
                {
                    startTimer();
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

            }
            else if (currentStageAbsVal == 2)
            {

            }
            else if (currentStageAbsVal == 3)
            {

            }
            else if (currentStageAbsVal == 4)
            {

            }
            else if(currentStageAbsVal == 5)
            {

            }
        }
    }
    void resetBetweenStages()
    {
        resetTimer();
    }

    void stageShaping()
    {
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

    }

    void stageTempering()
    {
    }

    void stageGrinding()
    {
        //enable the new ui for grinding
        //switch camera location
    }

    void stageSharpening()
    {

    }

    void stagePolishing()
    {
    }




    public void hammerHitOnAnvil()
    {
        if (currentStageAbsVal == 0)
        {
            if (componentOnAnvil)
            {
                hammerSlider.value += hammerHitIncrease;
            }
        }
    }

    public void bellowsPump()
    {
        if (currentStageAbsVal == 0 || currentStageAbsVal == 1 || currentStageAbsVal == 2)
        {
            if (componentOnForge)
            {
                heatSlider.value += bellowsHitIncrese;
            }
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
}
