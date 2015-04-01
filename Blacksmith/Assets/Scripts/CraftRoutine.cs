using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CraftRoutine : MonoBehaviour {
	public GameObject heatSliderObject;
	public GameObject hammerSliderObject;
	public GameObject timerSliderObject;
	public GameObject furnaceSliderObject;
	private Slider heatSlider;
	private Slider hammerSlider;
	private Slider timerSlider;
	private Slider furnaceSlider;

	// Use this for initialization
	void Start () 
	{
		GameObject heatBck = GameObject.Find ("heatSliderObject/Background");
		Image heatBckImage = heatBck.GetComponent<Image> ();
		heatBckImage.sprite = Resources.Load ("Images/heat scale1.png") as Sprite;

		heatSlider = heatSliderObject.GetComponent<Slider> ();
		hammerSlider = hammerSliderObject.GetComponent<Slider> ();
		timerSlider = timerSliderObject.GetComponent<Slider> ();
		furnaceSlider = furnaceSliderObject.GetComponent<Slider> ();

		heatSlider.value = 0;
		hammerSlider.value = 0;
		timerSlider.value = 0;
		furnaceSlider.value = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void fixedUpdate () {
		heatSlider.value += 1;
	}
}
