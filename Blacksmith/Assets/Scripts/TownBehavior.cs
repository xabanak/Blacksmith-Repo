using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TownBehavior : MonoBehaviour {

    private AdventureRoutine adventureRoutine;
    private Adventurer adventurerOne;
    private Adventurer adventurerTwo;
    private Adventurer adventurerThree;
    public Text textOne;
    public Text textTwo;
    public Text textThree;
    public Camera townCamera;
    public Camera tavernCamera;
    public Canvas townCanvas;
    public Canvas tavernCanvas;
    private bool newHeroes;

    public Text testText;

    void Awake ()
    {

    }

	// Use this for initialization
	void Start () 
    {
        adventureRoutine = GameObject.Find("GameController").GetComponent<AdventureRoutine>();
        newHeroes = true;
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

    public void hireAdventurer (int hero)
    {
        switch(hero)
        {
            case 1:
                adventureRoutine.addAdventurer(adventurerOne);
                testText.text = adventurerOne.getDescription();
                break;
            case 2:
                adventureRoutine.addAdventurer(adventurerTwo);
                testText.text = adventurerTwo.getDescription();
                break;
            case 3:
                adventureRoutine.addAdventurer(adventurerThree);
                testText.text = adventurerThree.getDescription();
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
}
