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
    private SoundController soundController;
    private AdventureRoutine adventureRoutine;
    private Adventurer adventurerOne;
    private Adventurer adventurerTwo;
    private Adventurer adventurerThree;
    private Adventurer[] adventurers;
    private BuildingsBehavior buildingsBehavior;
    private MarketRoutine marketRoutine;
    private HeroInterface heroInterface;
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
    public Button[] levelButtons;
    public GameObject[] travelSpots;
    public GameObject returnToWorkshopBtn;

    void Awake ()
    {

    }

	// Use this for initialization
	void Start () 
    {
        soundController = GameObject.Find("GameController").GetComponent<SoundController>();
        adventureRoutine = GameObject.Find("GameController").GetComponent<AdventureRoutine>();
        buildingsBehavior = GameObject.Find("Town/Buildings").GetComponent<BuildingsBehavior>();
        heroInterface = GameObject.Find("GameController").GetComponent<HeroInterface>();
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
            heroInterface.deactivateHeroInterface();
            soundController.stopAllMusic();
            soundController.playTavernMusic();
        }
        else
        {
            tavernCanvas.gameObject.SetActive(false);
            tavernCanvas.worldCamera = tavernCamera;
            heroInterface.activateHeroInterface();
            soundController.playTavernMusic();
            soundController.playTownMusic();
        }
    }

    public void hireAdventurer()
    {
        confirmationBox.SetActive(false);
        toggleTavernWindow();
        buildingsBehavior.toggleBuildings();
        returnToWorkshopBtn.SetActive(true);

        switch(heroSelection)
        {
            case 1:
                adventureRoutine.addAdventurer(adventurerOne);
                newHeroes = true;
                break;
            case 2:
                adventureRoutine.addAdventurer(adventurerTwo);
                newHeroes = true;
                break;
            case 3:
                adventureRoutine.addAdventurer(adventurerThree);
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
                resetTravelWindow();
                toggleTravelWindow();
                buildingsBehavior.toggleBuildings();
                toggleTravelInfo(false);
                travelHeroOne.GetComponent<Image>().color = Color.white;
                travelHeroTwo.GetComponent<Image>().color = Color.white;
                travelHeroThree.GetComponent<Image>().color = Color.white;
                returnToWorkshopBtn.SetActive(true);
                break;
            case "Tavern":
                toggleTavernWindow();
                buildingsBehavior.toggleBuildings();
                returnToWorkshopBtn.SetActive(true);
                break;
            case "Market":
                toggleMarketWindow();
                //marketCanvas.worldCamera = marketCamera;
                //marketCanvas.gameObject.SetActive(false);
                buildingsBehavior.toggleBuildings();
                returnToWorkshopBtn.SetActive(true);
                break;
            default:
                Debug.Log("Returning from not found!");
                break;
        }
    }

    public void toggleTravelWindow()
    {
        //Debug.Log("toggleTravelWindow called");
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

            heroInterface.deactivateHeroInterface();
            soundController.stopAllMusic();
            soundController.playTravelMusic();
        }
        else
        {
            travelCanvas.gameObject.SetActive(false);
            travelCanvas.worldCamera = travelCamera;
            heroInterface.activateHeroInterface();
            soundController.playTravelMusic();
            soundController.playTownMusic();

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
        //Debug.Log("setTravelHeroButtons called");
        if (adventurers[0] != null)
        {
            if (!adventurers[0].canAdventure())
            {
                //Debug.Log("Hero one interactable: false");
                travelHeroOne.GetComponent<Button>().interactable = false;
            }
            else
            {
                travelHeroOne.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            travelHeroOne.GetComponent<Button>().interactable = false;
        }

        if (adventurers[1] != null)
        {
            if (!adventurers[1].canAdventure())
            {
                //Debug.Log("Hero two interactable: false");
                travelHeroTwo.GetComponent<Button>().interactable = false;
            }
            else
            {
                travelHeroTwo.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            travelHeroTwo.GetComponent<Button>().interactable = false;
        }

        if (adventurers[2] != null)
        {
            if (!adventurers[2].canAdventure())
            {
                //Debug.Log("Hero three interactable: false");
                travelHeroThree.GetComponent<Button>().interactable = false;
            }
            else
            {
                travelHeroThree.GetComponent<Button>().interactable = true;
            }
        }
        else
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
            heroInterface.deactivateHeroInterface();
            soundController.stopAllMusic();
            soundController.playMarketMusic();
        }
        else
        {
            marketCanvas.gameObject.SetActive(false);
            marketCanvas.worldCamera = marketCamera;
            heroInterface.activateHeroInterface();
            soundController.playMarketMusic();
            soundController.playTownMusic();
        }
    }

    public void sendAdventurer(int level)
    {
        //Debug.Log("send town called");
        if (activeTravelHero == 1)
        {
            //Debug.Log("ActiveTravelHero 1");
            adventureRoutine.sendOnAdventure(adventurers[0], currentTravelZone, level);
        }
        else if(activeTravelHero == 2)
        {
            //Debug.Log("ActiveTravelHero 2");
            adventureRoutine.sendOnAdventure(adventurers[1], currentTravelZone, level);
        }
        else if(activeTravelHero == 3)
        {
            //Debug.Log("ActiveTravelHero 3");
            adventureRoutine.sendOnAdventure(adventurers[2], currentTravelZone, level);
        }
    }

    public void setCurrentTravelZone(string zone)
    {
        currentTravelZone = zone;
    }

    public void resetTravelWindow()
    {
        foreach (Button levelButton in levelButtons)
        {
            levelButton.gameObject.SetActive(false);
            levelButton.gameObject.GetComponent<RectTransform>().transform.localPosition = new Vector3(315, 0, 0);
        }

        foreach (GameObject spot in travelSpots)
        {
            spot.gameObject.GetComponent<Image>().color = Color.black;
            spot.gameObject.SetActive(false);
        }

        //returnToTown("Travel");
    }
}
