using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    private CraftRoutine craftRoutine;
    private CreateInventory createInventory;

    private GameObject hammer;
    private GameObject component;

    public GameObject inventory;
    private GameObject weaponsTab;

    public Camera workCamera;
    public GameObject workCameraObj;
    public Camera inventoryCamera;
    public Camera townCamera;
    public Camera startCamera;
    public GameObject startCameraObj;
    public GameObject escapeMenu;

    public Canvas workshopCanvas;
    public Canvas inventoryCanvas;

    public Button creditsButton;
    public GameObject creditsBackground;

    private bool workshop;
    private bool town;
    private bool tutorial;

    private TutorialRoutine tutorialRoutine;
    private SoundController soundController;

    public AudioSource invOpen;
    public AudioSource invClosed;

    private int gold;
    private bool[] tiers; // holds identity for if a tier is unlocked
    private const int totalTiers = 10;

    void Awake()
    {
        gameObject.AddComponent<TutorialRoutine>();
        weaponsTab = GameObject.Find("Inventory/Inventory Canvas/Inventory Window/Weapons");
        tutorial = true;
        craftRoutine = GameObject.Find("CraftingController").GetComponent<CraftRoutine>();
        createInventory = GameObject.Find("Inventory/InventoryController").GetComponent<CreateInventory>();
        hammer = GameObject.Find("Crafting/Hammer");
        component = GameObject.Find("Crafting/Component");
        setScene("workshop");
        tutorialRoutine = this.GetComponent<TutorialRoutine>();
        soundController = this.GetComponent<SoundController>();
        UnityEngine.Random.seed = (int)System.DateTime.Now.Ticks;
        soundController.playWorkshopMusic();
        gold = 100;
        
    }
	// Use this for initialization
	void Start () 
    {
        //workCameraObj.SetActive(false);
        tiers = new bool[totalTiers];
        tiers[0] = true;
        for (int i = 1; i < totalTiers; i++)
        {
            tiers[i] = false;
        }
    }
    
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryToggle();
        }

        if (tutorialRoutine.tutorialComplete(34) && weaponsTab.activeSelf && !craftRoutine.isPaused())
        {
            tutorialHelper(35);
        }
        if (!craftRoutine.isPaused() && tutorialRoutine.tutorialComplete(35))
        {
            tutorialHelper(36);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapeMenu.SetActive(!escapeMenu.activeSelf);
        }
	}

    void InventoryToggle()
    {
        /*if (tutorialRoutine.tutorialComplete(33))
        {
            tutorialHelper(34);
        }*/

        if (!craftRoutine.isCrafting() && workshop && !inventoryCanvas.GetComponent<Canvas>().enabled)
        {
            //Debug.Log("Inventory Enabled");
            invOpen.Play();
            inventoryCanvas.worldCamera = workCamera;
            inventoryCanvas.GetComponent<Canvas>().enabled = true;
            //inventory.SetActive(true);
            //ToggleTools();
        }
        else if (inventoryCanvas.enabled)
        {
            //Debug.Log("Inventory Disabled");
            invClosed.Play();
            inventoryCanvas.worldCamera = inventoryCamera;
            inventoryCanvas.GetComponent<Canvas>().enabled = false;
            //inventory.SetActive(false);
            //ToggleTools();
        }
        else if (town && !inventoryCanvas.GetComponent<Canvas>().enabled)
        {
            invOpen.Play();
            inventoryCanvas.worldCamera = townCamera;
            inventoryCanvas.GetComponent<Canvas>().enabled = true;
        }
        else if (!inventoryCanvas.GetComponent<Canvas>().enabled)
        {
            inventoryCanvas.worldCamera = inventoryCamera;
        }
    }

    public void setScene(string scene)
    {
        switch(scene)
        {
            case "workshop":
                workshop = true;
                town = false;
                break;
            case "town":
                town = true;
                workshop = false;
                break;
            default:
                Debug.Log("scene not found");
                break;
        }
    }

    /*void ToggleTools()
    {
        hammer.SetActive(!hammer.activeSelf);
    }*/

    private void tutorialHelper(int step)
    {
        if (!tutorialRoutine.tutorialComplete(step))
        {
            tutorialRoutine.tutorialMachine(step);
        }
    }

    public void disableTutorial()
    {
        tutorial = false;
    }

    public bool isTutorialActive()
    {
        return tutorial;
    }

    public void startGame()
    {
        startCameraObj.SetActive(false);
        workCameraObj.SetActive(true);
        tutorialRoutine.tutorialMachine(1);
    }

    public bool decGold(int change)
    {
        if (gold >= change)
        {
            gold -= change;
            return true;
        }

        return false;

    }

    public void incGold(int change)
    {
        gold += change;
    }

    public int getGold()
    {
        return gold;
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void displayCredits()
    {
        creditsBackground.SetActive(!creditsBackground.activeSelf);
    }

    public void unlockTier(int tier)
    {
        tiers[tier - 1] = true;
    }

    public bool checkProgression(int tier)
    {
        return tiers[tier - 1];
    }
}
