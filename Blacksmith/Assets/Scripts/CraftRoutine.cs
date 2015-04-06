using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CraftRoutine : MonoBehaviour {
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
<<<<<<< HEAD
    public float timer = 70;
    public Text heroReturnText;
=======

    public GameObject forge;
    public GameObject bellows;
    public GameObject craftingComponent; //eventually the game will programmatically find the GameObject that you will use during the current crafting session, for now we will assign it a test object
    public GameObject coolingBarrel;
    public GameObject hammer;
    public GameObject anvil;

>>>>>>> origin/master
	private Slider heatSlider;
	private Slider hammerSlider;
	private Slider timerSlider;
    private Slider furnaceSlider;
    private int minutes;
    private int seconds;

    private bool isCrafting;
    private bool furnaceIsMelting;

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
<<<<<<< HEAD
		furnaceSlider.value = 0.0f;
        heroReturnText.text = "Doom in: 100 seconds";
=======
        furnaceSlider.value = 0.0f;

        isCrafting = false;
        furnaceIsMelting = false;
>>>>>>> origin/master
	}

	// Update is called once per frame
<<<<<<< HEAD
	void Update () {
		heatSlider.value += 100.0f;
		hammerSlider.value += 100.0f;
		timerSlider.value += 100.0f;
		furnaceSlider.value += 100.0f;
        timer -= Time.deltaTime;
        minutes = (int)(timer / 60.0f);
        seconds = (int)timer % 60;
        if (seconds >= 10)
        {
            heroReturnText.text = "Hero returns: " + minutes + ":" + seconds;
        }
        else
        {
            heroReturnText.text = "Hero returns: " + minutes + ":0" + seconds;
        }
        
=======
	void Update () 
    {
    
>>>>>>> origin/master
	}

	void fixedUpdate () 
    {
        if (isCrafting)
        {
            heatSlider.value -= heatSliderChange;
            hammerSlider.value += hammerSliderChange;
            timerSlider.value += timeSliderChange;
        }

        if (furnaceIsMelting)
        {
            furnaceSlider.value += furnaceSliderChange;
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
}
