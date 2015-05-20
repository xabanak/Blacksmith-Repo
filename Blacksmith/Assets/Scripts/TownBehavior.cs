﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TownBehavior : MonoBehaviour {

    public GameObject travelHeroOne;
    public GameObject travelHeroTwo;
    public GameObject travelHeroThree;
    public GameObject confirmationBox;
    public Text confirmationBoxText;
    private AdventureRoutine adventureRoutine;
    private Adventurer adventurerOne;
    private Adventurer adventurerTwo;
    private Adventurer adventurerThree;
    private BuildingsBehavior buildingsBehavior;
    public Text textOne;
    public Text textTwo;
    public Text textThree;
    public Camera townCamera;
    public Camera tavernCamera;
    public Camera travelCamera;
    public Canvas townCanvas;
    public Canvas tavernCanvas;
    public Canvas travelCanvas;
    private bool newHeroes;
    private int heroSelection;
    

    public Text testText;

    void Awake ()
    {

    }

	// Use this for initialization
	void Start () 
    {
        adventureRoutine = GameObject.Find("GameController").GetComponent<AdventureRoutine>();
        buildingsBehavior = GameObject.Find("Town/Buildings").GetComponent<BuildingsBehavior>();
        newHeroes = true;
        heroSelection = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (tavernCanvas.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            tavernCanvas.gameObject.SetActive(false);
            tavernCanvas.worldCamera = tavernCamera;
        }
	}

    public void toggleTavernWindow()
    {
        if (!tavernCanvas.gameObject.activeSelf)
        {
            tavernCanvas.gameObject.SetActive(true);
            tavernCanvas.worldCamera = townCamera;
        }
        else
        {
            tavernCanvas.gameObject.SetActive(false);
            tavernCanvas.worldCamera = tavernCamera;
        }
    }

    public void hireAdventurer ()
    {
        confirmationBox.SetActive(false);
        toggleTavernWindow();

        switch(heroSelection)
        {
            case 1:
                adventureRoutine.addAdventurer(adventurerOne);
                testText.text = adventurerOne.getDescription();
                newHeroes = true;
                break;
            case 2:
                adventureRoutine.addAdventurer(adventurerTwo);
                testText.text = adventurerTwo.getDescription();
                newHeroes = true;
                break;
            case 3:
                adventureRoutine.addAdventurer(adventurerThree);
                testText.text = adventurerThree.getDescription();
                newHeroes = true;
                break;
            default:
                Debug.Log("No adventurer found");
                break;
        }
    }

    public void getAdventurerSet()
    {
        if (newHeroes)
        {
            adventurerOne = new Adventurer();
            adventurerTwo = new Adventurer();
            adventurerThree = new Adventurer();
            newHeroes = false;
        }
    }

    public void setTavernWindow()
    {
        textOne.text = adventurerOne.getDescription();
        textTwo.text = adventurerTwo.getDescription();
        textThree.text = adventurerThree.getDescription();
    }
    
    public void setNewHeroes()
    {
        newHeroes = true;
    }

    public void confirmHero(int hero)
    {
        heroSelection = hero;
        Debug.Log(hero + ", " + heroSelection);
        confirmationBox.SetActive(true);
        switch (heroSelection)
        {
            case 1:
                confirmationBoxText.text = "You have selected\n" + adventurerOne.getName();
                break;
            case 2:
                confirmationBoxText.text = "You have selected\n" + adventurerTwo.getName();
                break;
            case 3:
                confirmationBoxText.text = "You have selected\n" + adventurerThree.getName();
                break;
            default:
                Debug.Log("Invalid hero selection");
                break;
        }
    }

    public void declineHero()
    {
        confirmationBox.SetActive(false);
        heroSelection = 0;
    }

    public void returnToTown(string from)
    {
        switch (from)
        {
            case "Travel":
                travelCanvas.worldCamera = travelCamera;
                travelCanvas.gameObject.SetActive(false);
                buildingsBehavior.toggleBuildings();
                toggleTravelInfo(false);
                travelHeroOne.GetComponent<Image>().color = Color.white;
                travelHeroTwo.GetComponent<Image>().color = Color.white;
                travelHeroThree.GetComponent<Image>().color = Color.white;
                break;
            case "Tavern":
                tavernCanvas.worldCamera = tavernCamera;
                tavernCanvas.gameObject.SetActive(false);
                buildingsBehavior.toggleBuildings();
                break;
            default:
                Debug.Log("Returning from not found!");
                break;
        }
    }

    public void toggleTravelWindow()
    {
        if (!travelCanvas.gameObject.activeSelf)
        {
            travelCanvas.gameObject.SetActive(true);
            travelCanvas.worldCamera = townCamera;
        }
        else
        {
            travelCanvas.gameObject.SetActive(false);
            travelCanvas.worldCamera = travelCamera;
        }
    }

    public void travelHeroSelection(string button)
    {
        switch(button)
        {
            case "Hero 1":
                travelHeroOne.GetComponent<Image>().color = Color.white;
                travelHeroTwo.GetComponent<Image>().color = fadeAlpha(travelHeroTwo.GetComponent<Image>().color);
                travelHeroThree.GetComponent<Image>().color = fadeAlpha(travelHeroThree.GetComponent<Image>().color);
                break;
            case "Hero 2":
                travelHeroTwo.GetComponent<Image>().color = Color.white;
                travelHeroOne.GetComponent<Image>().color = fadeAlpha(travelHeroOne.GetComponent<Image>().color);
                travelHeroThree.GetComponent<Image>().color = fadeAlpha(travelHeroThree.GetComponent<Image>().color);
                break;
            case "Hero 3":
                travelHeroThree.GetComponent<Image>().color = Color.white;
                travelHeroOne.GetComponent<Image>().color = fadeAlpha(travelHeroOne.GetComponent<Image>().color);
                travelHeroTwo.GetComponent<Image>().color = fadeAlpha(travelHeroTwo.GetComponent<Image>().color);
                break;
            default:
                Debug.Log("Invalid hero selection");
                break;
        }

        if ((button == "Hero 1" || button == "Hero 2" || button == "Hero 3") && !travelCanvas.transform.GetChild(0).gameObject.activeSelf)
        {
            toggleTravelInfo(true);
        }
    }

    private Color fadeAlpha(Color mute)
    {
        mute.a = 0.5f;
        return mute;
    }

    private void toggleTravelInfo(bool set)
    {
        for (int i = 0; i < 10; i++)
            {
                travelCanvas.transform.GetChild(i).gameObject.SetActive(set);
            }
    }
}
