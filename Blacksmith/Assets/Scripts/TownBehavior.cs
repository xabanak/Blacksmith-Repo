using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TownBehavior : MonoBehaviour {

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
    public Canvas townCanvas;
    public Canvas tavernCanvas;
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

    
}
