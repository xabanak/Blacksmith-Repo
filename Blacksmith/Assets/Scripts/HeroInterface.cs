using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroInterface : MonoBehaviour {

    private Adventurer[] adventurers;
    private AdventureRoutine adventurerRoutine;
    public GameObject baseWindow;
    public Button heroStatus;
    public Button adventureStatus;
    public Text heroName;
    public Button[] statusButtons;

	// Use this for initialization
	void Start () 
    {
        adventurerRoutine = GameObject.Find("GameController").GetComponent<AdventureRoutine>();
        adventurers = adventurerRoutine.getAdventurers();
        statusButtons[0].interactable = false;
        statusButtons[1].interactable = false;
        statusButtons[2].interactable = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void updateActiveHeroes()
    {

    }

    public void showBaseWindow(int hero)
    {
        adventurers = adventurerRoutine.getAdventurers();
        baseWindow.SetActive(true);
        heroName.text = adventurers[hero].getName();
    }
}
