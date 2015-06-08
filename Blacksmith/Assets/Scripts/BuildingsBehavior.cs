using UnityEngine;
using System.Collections;

public class BuildingsBehavior : MonoBehaviour {

    private TownBehavior townBehavior;
    private SoundController soundController;
    private AdventureRoutine adventureRoutine;

    public GameObject tavern;
    public GameObject emporium;
    public GameObject market;
    public GameObject travel;
    public GameObject message;

    public Canvas townCanvas;

	void Start () 
    {
        townBehavior = GameObject.Find("GameController").GetComponent<TownBehavior>();
        soundController = GameObject.Find("GameController").GetComponent<SoundController>();
        adventureRoutine = GameObject.Find("GameController").GetComponent<AdventureRoutine>();
	}
	
	void Update () {
	
	}

    public void openWindow(string window)
    {
        toggleBuildings();

        switch(window)
        {
            case "Tavern":
                if (adventureRoutine.getNumAdventurers() < 3)
                {
                    townBehavior.toggleTavernWindow();
                    townBehavior.getAdventurerSet();
                    townBehavior.setTavernWindow();
                }
                else
                {
                    GameObject tempObj;
                    tempObj = Instantiate(message);
                    tempObj.transform.SetParent(townCanvas.transform);
                    tempObj.transform.localScale = new Vector3(.3f, .3f, .3f);
                    tempObj.transform.localPosition = new Vector3(-250, 85, 0);
                    toggleBuildings();
                }
                break;
            case "Travel":
                townBehavior.toggleTravelWindow();
                townBehavior.setTravelHeroButtons();
                break;
            case "Market":
                townBehavior.toggleMarketWindow();
                break;
            default:
                break;
        }
    }

    public void toggleBuildings()
    {
        tavern.SetActive(!tavern.activeSelf);
        emporium.SetActive(!emporium.activeSelf);
        market.SetActive(!market.activeSelf);
        travel.SetActive(!travel.activeSelf);
    }
}
