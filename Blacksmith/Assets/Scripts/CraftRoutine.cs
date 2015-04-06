using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CraftRoutine : MonoBehaviour {
	public Sprite heatDiffOne;
	public Sprite heatDiffTwo;
	public Sprite heatDiffThree;
	public GameObject heatSliderObject;
	public GameObject hammerSliderObject;
	public GameObject timerSliderObject;
	public GameObject furnaceSliderObject;
    public float timer = 70;
    public Text heroReturnText;
	private Slider heatSlider;
	private Slider hammerSlider;
	private Slider timerSlider;
    private Slider furnaceSlider;
    private int minutes;
    private int seconds;

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
        heroReturnText.text = "Doom in: 100 seconds";
	}

	// Update is called once per frame
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
        
	}

	void fixedUpdate () {

	}
}
