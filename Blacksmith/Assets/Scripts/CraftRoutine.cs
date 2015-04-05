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

    public Button startCraftingButton;
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

        startCraftingButton.onClick.AddListener(() => { isCrafting = true; });

        isCrafting = false;
        furnaceIsMelting = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        while (isCrafting)
        {
            heatSlider.value -= heatSliderChange;
            hammerSlider.value += hammerSliderChange;
            timerSlider.value += timeSliderChange;
        }

        while (furnaceIsMelting)
        {
            furnaceSlider.value += furnaceSliderChange;
        }

	}

	void fixedUpdate () 
    {

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
