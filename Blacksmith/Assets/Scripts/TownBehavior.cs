using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TownBehavior : MonoBehaviour {

    public GameObject maleHeroOne;
    public GameObject travelHeroOne;
    public GameObject travelHeroTwo;
    public GameObject travelHeroThree;
    public GameObject confirmationBox;
    public Text confirmationBoxText;
    private AdventureRoutine adventureRoutine;
    private Adventurer adventurerOne;
    private Adventurer adventurerTwo;
    private Adventurer adventurerThree;
    private Adventurer[] adventurers;
    private BuildingsBehavior buildingsBehavior;
    private MarketRoutine marketRoutine;
    public Text textOne;
    public Text textTwo;
    public Text textThree;
    public Camera townCamera;
    public Camera tavernCamera;
    public Camera travelCamera;
    public Camera marketCamera;
    public Canvas townCanvas;
    public Canvas tavernCanvas;
    public Canvas travelCanvas;
    public Canvas marketCanvas;
    private bool newHeroes;
    private int heroSelection;
    public int activeTravelHero;
    private string currentTravelZone;
    

    public Text testText;

    void Awake ()
    {

    }

	// Use this for initialization
	void Start () 
    {
        adventureRoutine = GameObject.Find("GameController").GetComponent<AdventureRoutine>();
        buildingsBehavior = GameObject.Find("Town/Buildings").GetComponent<BuildingsBehavior>();
        marketRoutine = GetComponent<MarketRoutine>();
        adventurers = adventureRoutine.getAdventurers();
        newHeroes = true;
        heroSelection = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
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

    public void hireAdventurer()
    {
        confirmationBox.SetActive(false);
        toggleTavernWindow();
        buildingsBehavior.toggleBuildings();

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
        adventurers = adventureRoutine.getAdventurers();
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
            case "Market":
                marketCanvas.worldCamera = marketCamera;
                marketCanvas.gameObject.SetActive(false);
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
            GameObject[] tempHeroes = new GameObject[3];
            tempHeroes[0] = travelHeroOne;
            tempHeroes[1] = travelHeroTwo;
            tempHeroes[2] = travelHeroThree;

            for (int i = 0; i <= 2; i++)
            {
                if (adventurers[i] != null)
                {
                    tempHeroes[i].GetComponent<Image>().sprite = maleHeroOne.GetComponent<SpriteRenderer>().sprite;
                    tempHeroes[i].transform.GetChild(0).GetComponent<Text>().text = adventurers[i].getName();
                }
            }
        }
        else
        {
            travelCanvas.gameObject.SetActive(false);
            travelCanvas.worldCamera = travelCamera;
        }
    }

    public void travelHeroSelection(string button)
    {
        //Adventurer[] tempAdventurers;
        //tempAdventurers = adventureRoutine.getAdventurers();

        switch(button)
        {
            case "Hero 1":
                if (adventurers[0] != null)
                {
                    travelHeroOne.GetComponent<Image>().color = Color.white;
                    if (travelHeroTwo.GetComponent<Button>().IsInteractable())
                        travelHeroTwo.GetComponent<Image>().color = fadeAlpha(travelHeroTwo.GetComponent<Image>().color);
                    if (travelHeroThree.GetComponent<Button>().IsInteractable())
                        travelHeroThree.GetComponent<Image>().color = fadeAlpha(travelHeroThree.GetComponent<Image>().color);
                    activeTravelHero = 1;
                }
                break;
            case "Hero 2":
                if (adventurers[1] != null)
                {
                    travelHeroTwo.GetComponent<Image>().color = Color.white;
                    if (travelHeroOne.GetComponent<Button>().IsInteractable())
                        travelHeroOne.GetComponent<Image>().color = fadeAlpha(travelHeroOne.GetComponent<Image>().color);
                    if (travelHeroThree.GetComponent<Button>().IsInteractable())
                        travelHeroThree.GetComponent<Image>().color = fadeAlpha(travelHeroThree.GetComponent<Image>().color);
                    activeTravelHero = 2;
                }
                break;
            case "Hero 3":
                if (adventurers[2] != null)
                {
                    travelHeroThree.GetComponent<Image>().color = Color.white;
                    if (travelHeroOne.GetComponent<Button>().IsInteractable())
                        travelHeroOne.GetComponent<Image>().color = fadeAlpha(travelHeroOne.GetComponent<Image>().color);
                    if (travelHeroTwo.GetComponent<Button>().IsInteractable())
                        travelHeroTwo.GetComponent<Image>().color = fadeAlpha(travelHeroTwo.GetComponent<Image>().color);
                    activeTravelHero = 3;
                }
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
   
    public void setTravelHeroButtons()
    {
        if (adventurers[0] != null)
        {
            travelHeroOne.GetComponent<Button>().interactable = true;
        }
        else if (adventurers[0] == null)
        {
            travelHeroOne.GetComponent<Button>().interactable = false;
        }
        
        if (adventurers[1] != null)
        {
            travelHeroTwo.GetComponent<Button>().interactable = true;
        }
        else if (adventurers[1] == null)
        {
            travelHeroTwo.GetComponent<Button>().interactable = false;
        }

        if (adventurers[2] != null)
        {
            travelHeroThree.GetComponent<Button>().interactable = true;
        }
        else if (adventurers[2] == null)
        {
            travelHeroThree.GetComponent<Button>().interactable = false;
        }
    }

    public void toggleMarketWindow()
    {
        if (!marketCanvas.gameObject.activeSelf)
        {
            marketCanvas.gameObject.SetActive(true);
            marketCanvas.worldCamera = townCamera;
            marketRoutine.setMarketWindow();
            
        }
        else
        {
            marketCanvas.gameObject.SetActive(false);
            marketCanvas.worldCamera = marketCamera;
        }
    }

    public void sendAdventurer(int level)
    {
        Debug.Log("send town called");
        if (activeTravelHero == 1)
        {
            Debug.Log("ActiveTravelHero 1");
            adventureRoutine.sendOnAdventure(adventurers[0], currentTravelZone, level);
        }
        else if(activeTravelHero == 2)
        {
            Debug.Log("ActiveTravelHero 2");
            adventureRoutine.sendOnAdventure(adventurers[1], currentTravelZone, level);
        }
        else if(activeTravelHero == 3)
        {
            Debug.Log("ActiveTravelHero 3");
            adventureRoutine.sendOnAdventure(adventurers[2], currentTravelZone, level);
        }
    }

    public void setCurrentTravelZone(string zone)
    {
        currentTravelZone = zone;
    }
}
