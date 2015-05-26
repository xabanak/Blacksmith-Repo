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

    public Canvas workshopCanvas;
    public Canvas inventoryCanvas;

    private bool workshop;
    private bool town;

    private bool tutorial;

    private TutorialRoutine tutorialRoutine;
    private SoundController soundController;

    public AudioSource invOpen;
    public AudioSource invClosed;

    private int gold;

    void Awake()
    {
        gameObject.AddComponent<TutorialRoutine>();
        weaponsTab = GameObject.Find("Inventory/Inventory Canvas/Inventory Window/Weapons");
        tutorial = true;
        craftRoutine = GameObject.Find("CraftingController").GetComponent<CraftRoutine>();
        createInventory = GameObject.Find("Inventory/InventoryController").GetComponent<CreateInventory>();
        hammer = GameObject.Find("Crafting/Hammer");
        component = GameObject.Find("Crafting/Component");
        SetScene("workshop");
        tutorialRoutine = this.GetComponent<TutorialRoutine>();
        soundController = this.GetComponent<SoundController>();
        UnityEngine.Random.seed = (int)System.DateTime.Now.Ticks;
        soundController.playWorkshopMusic();
        gold = 1000;
    }
	// Use this for initialization
	void Start () 
    {
        //workCameraObj.SetActive(false);
    }
    
	
	// Update is called once per frame
	void Update () 
    {
        
        if (workshop && !soundController.isWorkshopMusicPlaying())
        {
            soundController.playWorkshopMusic();
        }
        if (craftRoutine.isCrafting())
        {
            soundController.playWorkshopMusic();
        }
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
	}

    void InventoryToggle()
    {
        if (!craftRoutine.isPaused() && tutorialRoutine.tutorialComplete(33))
        {
            tutorialHelper(34);
        }

        if (!craftRoutine.isCrafting() && workshop && !inventoryCanvas.GetComponent<Canvas>().enabled)
        {
            //Debug.Log("Inventory Enabled");
            invOpen.Play();
            inventoryCanvas.worldCamera = workCamera;
            inventoryCanvas.GetComponent<Canvas>().enabled = true;
            //inventory.SetActive(true);
            ToggleTools();
        }
        else if (inventoryCanvas.enabled)
        {
            //Debug.Log("Inventory Disabled");
            invClosed.Play();
            inventoryCanvas.worldCamera = inventoryCamera;
            inventoryCanvas.GetComponent<Canvas>().enabled = false;
            //inventory.SetActive(false);
            ToggleTools();
        }
        else if (town && !inventoryCanvas.GetComponent<Canvas>().enabled)
        {
            inventoryCanvas.worldCamera = townCamera;
        }
        else if (!inventoryCanvas.GetComponent<Canvas>().enabled)
        {
            inventoryCanvas.worldCamera = inventoryCamera;
        }
    }

    void SetScene(string scene)
    {
        switch(scene)
        {
            case "workshop":
                workshop = true;
                break;
            case "town":
                town = true;
                break;
            default:
                Debug.Log("scene not found");
                break;
        }
    }

    void ToggleTools()
    {
        hammer.SetActive(!hammer.activeSelf);
    }

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
}
