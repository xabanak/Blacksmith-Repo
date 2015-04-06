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

    private const float fullSlider = 10000.0f;
    private const float emptySlider = 0.0f;

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

	private Slider heatSlider;
	private Slider hammerSlider;
	private Slider timerSlider;
    private Slider furnaceSlider;


    private bool isCrafting;
    private bool furnaceIsMelting;
    public bool componentOnForge;
    private bool componentOnAnvil;
    private bool componentInBarrel;

    private Text stage;
    private bool stageActive;

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


        furnaceSlider.value = 0.0f;

        isCrafting = false;
        furnaceIsMelting = false;

        //stage.enabled = false;
        //stageActive = false;
        

	}

	// Update is called once per frame
	void Update () 
    {
        if (isCrafting)
        {
            heatSlider.value -= Time.deltaTime * heatSliderChange;
            hammerSlider.value -= Time.deltaTime * hammerSliderChange;
            timerSlider.value += Time.deltaTime * timeSliderChange;
        }

        if (furnaceIsMelting)
        {
            furnaceSlider.value += furnaceSliderChange;
        }
    }

    public void hammerHitOnAnvil()
    {
        if (componentOnAnvil)
        {
            hammerSlider.value += 7.5f;
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

    void toggleComponentInBarrel()
    {
        componentInBarrel = !componentInBarrel;
    }

	void fixedUpdate () 
    {
       
	}

    public void bellowsPump()
    {
        if (componentOnForge)
        {
            heatSlider.value += 10.0f;
        }
    }

    public void craftingToggle()
    {
        if (isCrafting)
        {
            isCrafting = false;
            heatSlider.value = emptySlider;
            hammerSlider.value = emptySlider;
            timerSlider.value = emptySlider;
        }
        else if(!isCrafting)
        {
            isCrafting = true;
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

    }
}
