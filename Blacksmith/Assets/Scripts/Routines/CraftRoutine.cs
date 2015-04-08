using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CraftRoutine : MonoBehaviour 
{
	public Sprite heatDiffOne;
	public Sprite heatDiffTwo;
	public Sprite heatDiffThree;

    public float heatSliderChange;
    public float hammerSliderChange;
    public float timeSliderChange;
    public float furnaceSliderChange;
    public float quenchingSliderChange;

	public GameObject heatSliderObject;
	public GameObject hammerSliderObject;
	public GameObject timerSliderObject;
	public GameObject furnaceSliderObject;

    public GameObject forge;
    public GameObject bellows;
    public GameObject craftingComponent; //eventually the game will programmatically find the GameObject that you will use during the current crafting session, for now we will assign it a test object
    public GameObject coolingBarrel;
    public GameObject hammer;
    public GameObject anvil;

    public StageTimeMatrix timeMultiplier;

    public Text stage;
    public Text popUpText;

	private Slider heatSlider;
	private Slider hammerSlider;
	private Slider timerSlider;
    private Slider furnaceSlider;

    private const float fullSlider = 60.0f;
    private const float emptySlider = 0.0f;
    private const float baseTimeStage1 = 60.0f;
	private const float hammerHitIncrease = 5.0f;
	private const float bellowsHitIncrese = 5.0f;
	private const float heatToStart = 25.0f;
	private const float hammerToStart = 25.0f;

	public bool isBeginningCrafting;
    public bool isCrafting;
    private bool furnaceIsMelting;
    private bool componentOnAnvil;
    private bool componentInBarrel;
    private bool componentOnForge;
    private bool needToStartCraft = false;

    private float countDown = 3.0f;

    private int curStage = 0;
    private int totalStages = 4;

	// Use this for initialization
	void Start () 
	{
		GameObject heatBck = GameObject.Find("/Canvas/Heat Gauge/Background");
		Image heatBckImage = heatBck.GetComponent<Image> ();
		heatBckImage.sprite = heatDiffOne;

		heatSlider = heatSliderObject.GetComponent<Slider> ();
		hammerSlider = hammerSliderObject.GetComponent<Slider> ();
		timerSlider = timerSliderObject.GetComponent<Slider> ();
		furnaceSlider = furnaceSliderObject.GetComponent<Slider> ();

		heatSlider.value = 0.0f;
		hammerSlider.value = 0.0f;
		timerSlider.value = 0.0f;

        componentOnAnvil = false;
        componentOnForge = false;
        componentInBarrel = false;

        furnaceSlider.value = 0.0f;

		isBeginningCrafting = false;
        isCrafting = false;
        furnaceIsMelting = false;

        stage.enabled = false;

        timerSlider.maxValue = baseTimeStage1;
        popUpText.enabled = false;

  
        

	}

	// Update is called once per frame
	void Update () 
    {
        IsTimerDone();

        if (isCrafting || isBeginningCrafting)
        {
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
		else if(isCrafting && !isBeginningCrafting)
		{
			timerSlider.value += Time.deltaTime;

			SetPopUpText("Stage 1");
			
			if (countDown > 0)
			{
				countDown -= Time.deltaTime;
				SetPopUpTextActive(true);
			}
			
			if (countDown <= 0)
			{
				SetPopUpTextActive(false);
			}
			
			if (needToStartCraft)
			{
				stage.enabled = true;
				NextStage();
				needToStartCraft = false;
			}

		}
        else if (!isCrafting)
        {
            needToStartCraft = true;
            stage.enabled = false;
        }

		if (isBeginningCrafting && !isCrafting) 
		{
			if ((heatSlider.value > heatToStart) && (hammerSlider.value > hammerToStart))
			{
				isBeginningCrafting = !isBeginningCrafting;
				isCrafting = !isCrafting;
			}
		}

        if (furnaceIsMelting)
        {
            furnaceSlider.value += furnaceSliderChange;
        }
    }

    public void hammerHitOnAnvil()
    {
        if ((isCrafting || isBeginningCrafting) && componentOnAnvil)
        {
            hammerSlider.value += hammerHitIncrease;
        }
    }

    public void bellowsPump()
    {
        if ((isCrafting || isBeginningCrafting) && componentOnForge)
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

    public void craftingToggle()
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
}
