using UnityEngine;
using System.Collections;

public class BuildingsBehavior : MonoBehaviour {

   // private string name;
    private TownBehavior townBehavior;

    public GameObject tavern;
    public GameObject emporium;
    public GameObject market;
    public GameObject travel;

	// Use this for initialization
	void Start () 
    {
        //name = gameObject.name;
        townBehavior = GameObject.Find("GameController").GetComponent<TownBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void openWindow(string window)
    {
        toggleBuildings();

        switch(window)
        {
            case "Tavern":
                townBehavior.toggleTavernWindow();
                townBehavior.getAdventurerSet();
                townBehavior.setTavernWindow();
                break;
            case "Travel":
                townBehavior.toggleTravelWindow();
                //townBehavior.setTravelHeroButtons();
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
