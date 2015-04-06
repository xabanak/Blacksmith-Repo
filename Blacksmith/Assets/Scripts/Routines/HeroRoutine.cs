using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroRoutine : MonoBehaviour 
{
    private int minutes;
    private int seconds;

    public float timer = 10; // timer to track hero return time
    public Text heroReturnText;


	// Use this for initialization
	void Start () 
    {
        heroReturnText.text = "Doom in: 100 seconds";
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer -= Time.deltaTime;
        minutes = (int)(timer / 60.0f);
        seconds = (int)timer % 60;
        if (seconds >= 10)
        {
            heroReturnText.text = "Hero returns: " + minutes + ":" + seconds;
        }
        else if (seconds < 10 && seconds > 0)
        {
            heroReturnText.text = "Hero returns: " + minutes + ":0" + seconds;
        }
        else
        {
            heroReturnText.text = "Hero has returned!";
        }
	}
}
