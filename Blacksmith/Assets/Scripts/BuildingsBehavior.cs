using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildingsBehavior : MonoBehaviour {

    private TownBehavior townBehavior;
    private SoundController soundController;
    private AdventureRoutine adventureRoutine;

    public GameObject tavern;
    public GameObject emporium;
    public GameObject market;
    public GameObject travel;
    public GameObject message;

    public GameObject returnToWorkshopBtn;
    public GameObject tavernSign;
    public GameObject emporiumSign;
    public GameObject marketSign;
    public GameObject travelSign;

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
                    returnToWorkshopBtn.SetActive(false);
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
                returnToWorkshopBtn.SetActive(false);
                break;
            case "Market":
                townBehavior.toggleMarketWindow();
                returnToWorkshopBtn.SetActive(false);
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
        toggleSigns();
    }

    public void toggleSigns()
    {
        tavernSign.SetActive(!tavernSign.activeSelf);
        emporiumSign.SetActive(!emporiumSign.activeSelf);
        marketSign.SetActive(!marketSign.activeSelf);
        travelSign.SetActive(!travelSign.activeSelf);
    }
    
    public void showSigns()
    {
        tavernSign.SetActive(true);
        emporiumSign.SetActive(true);
        marketSign.SetActive(true);
        travelSign.SetActive(true);
    }

    public void hideSigns()
    {
        tavernSign.SetActive(false);
        emporiumSign.SetActive(false);
        marketSign.SetActive(false);
        travelSign.SetActive(false);
    }
}
