using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroRoutine : MonoBehaviour 
{
    public int hiredHeroes;
    private int minutes;
    private int seconds;

    public float timer1 = 10; // timer to track hero return time of first hero
    public float timer2 = 20; // timer to track hero return time of first hero
    public float timer3 = 30; // timer to track hero return time of first hero
    public Text heroReturnText1;
    public Text heroReturnText2;
    public Text heroReturnText3;




	// Use this for initialization
	void Start () 
    {
        hiredHeroes = 0;
        heroReturnText1.text = "Hero returns: 0:00";
        heroReturnText2.text = "Hero returns: 0:00";
        heroReturnText3.text = "Hero returns: 0:00";
        heroReturnText1.enabled = false;
        heroReturnText2.enabled = false;
        heroReturnText3.enabled = false;

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (heroReturnText1.enabled == true)
        {
            timer1 -= Time.deltaTime;
            UpdateHeroTimer(timer1, heroReturnText1);
        }

        if (heroReturnText2.enabled == true)
        {
            timer2 -= Time.deltaTime;
            UpdateHeroTimer(timer2, heroReturnText2);
        }

        if (heroReturnText3.enabled == true)
        {
            timer3 -= Time.deltaTime;
            UpdateHeroTimer(timer3, heroReturnText3);
        }

        // test method
        SetHeroActiveText();
	}

    void UpdateHeroTimer(float timer, Text heroReturnText)
    {
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
        else if (seconds == 0 && minutes == 0)
        {
            heroReturnText.text = "Hero has returned!";
        }
    }

    void SetHeroActiveText ()
    {
        if (hiredHeroes == 1)
        {
            heroReturnText1.enabled = true;
        }

        else if (hiredHeroes == 2)
        {
            heroReturnText2.enabled = true;
        }

        else if (hiredHeroes == 3)
        {
            heroReturnText3.enabled = true;
        }

    }
}
