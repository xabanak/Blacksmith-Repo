using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LevelChoiceTravel : MonoBehaviour {

    private TownBehavior townBehavior;
    public Button[] buttons;
    public Text[] texts;
    private Adventurer[] adventurers;
    private AdventureRoutine adventurerRoutine;

	// Use this for initialization
	void Start () 
    {
        townBehavior = GameObject.Find("GameController").GetComponent<TownBehavior>();
        adventurerRoutine = GameObject.Find("GameController").GetComponent<AdventureRoutine>();
        adventurers = adventurerRoutine.getAdventurers();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnMouseDown()
    {
        // TEST METHOD
        //for (int i = 0; i < 15; i++)
        //    adventurers[townBehavior.activeTravelHero - 1].levelUp();
        int temp = adventurers[townBehavior.activeTravelHero - 1].getLevel();

        if (temp == 1)
        {
            buttons[0].gameObject.SetActive(true);
            texts[0].text = "1";
        }

        if (temp == 2)
        {
            buttons[0].gameObject.SetActive(true);
            texts[0].text = "2";
            buttons[0].GetComponent<RectTransform>().localPosition = new Vector3(315, 30, 0);
            buttons[1].gameObject.SetActive(true);
            texts[1].text = "1";
            buttons[1].GetComponent<RectTransform>().localPosition = new Vector3(315, -30, 0);
        }
        if (temp == 3)
        {
            buttons[0].gameObject.SetActive(true);
            texts[0].text = "3";
            buttons[0].GetComponent<RectTransform>().localPosition = new Vector3(315, 60, 0);
            buttons[1].gameObject.SetActive(true);
            texts[1].text = "2";
            buttons[2].gameObject.SetActive(true);
            texts[2].text = "1";
            buttons[2].GetComponent<RectTransform>().localPosition = new Vector3(315, -60, 0);
        }

        if (temp == 4)
        {
            buttons[0].gameObject.SetActive(true);
            texts[0].text = "4";
            buttons[0].GetComponent<RectTransform>().localPosition = new Vector3(315, 90, 0);
            buttons[1].gameObject.SetActive(true);
            texts[1].text = "3";
            buttons[1].GetComponent<RectTransform>().localPosition = new Vector3(315, 30, 0);
            buttons[2].gameObject.SetActive(true);
            texts[2].text = "2";
            buttons[2].GetComponent<RectTransform>().localPosition = new Vector3(315, -30, 0);
            buttons[3].gameObject.SetActive(true);
            texts[3].text = "1";
            buttons[3].GetComponent<RectTransform>().localPosition = new Vector3(315, -90, 0);
        }

        if (temp == 5)
        {
            buttons[0].gameObject.SetActive(true);
            texts[0].text = "5";
            buttons[0].GetComponent<RectTransform>().localPosition = new Vector3(315, 120, 0);
            buttons[1].gameObject.SetActive(true);
            texts[1].text = "4";
            buttons[1].GetComponent<RectTransform>().localPosition = new Vector3(315, 60, 0);
            buttons[2].gameObject.SetActive(true);
            texts[2].text = "3";
            buttons[3].gameObject.SetActive(true);
            texts[3].text = "2";
            buttons[3].GetComponent<RectTransform>().localPosition = new Vector3(315, -60, 0);
            buttons[4].gameObject.SetActive(true);
            texts[4].text = "1";
            buttons[4].GetComponent<RectTransform>().localPosition = new Vector3(315, -120, 0);
        }

        if (temp >= 6)
        {
            buttons[0].gameObject.SetActive(true);
            texts[0].text = "" + temp;
            buttons[0].GetComponent<RectTransform>().localPosition = new Vector3(315, 150, 0);
            buttons[1].gameObject.SetActive(true);
            texts[1].text = "" + (temp - 1);
            buttons[1].GetComponent<RectTransform>().localPosition = new Vector3(315, 90, 0);
            buttons[2].gameObject.SetActive(true);
            texts[2].text = "" + (temp - 2);
            buttons[2].GetComponent<RectTransform>().localPosition = new Vector3(315, 30, 0);
            buttons[3].gameObject.SetActive(true);
            texts[3].text = "" + (temp - 3);
            buttons[3].GetComponent<RectTransform>().localPosition = new Vector3(315, -30, 0);
            buttons[4].gameObject.SetActive(true);
            texts[4].text = "" + (temp - 4);
            buttons[4].GetComponent<RectTransform>().localPosition = new Vector3(315, -90, 0);
            buttons[5].gameObject.SetActive(true);
            texts[5].text = "" + (temp - 5);
            buttons[5].GetComponent<RectTransform>().localPosition = new Vector3(315, -150, 0);
        }
    }
}
