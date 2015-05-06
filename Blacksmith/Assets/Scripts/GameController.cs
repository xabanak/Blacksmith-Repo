using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private CraftRoutine craftRoutine;

    private GameObject hammer;
    private GameObject component;

    public GameObject inventory;

    public Camera workCamera;
    public Camera inventoryCamera;
    public Camera townCamera;

    public Canvas workshopCanvas;
    public Canvas inventoryCanvas;

    private bool workshop;
    private bool town;


	// Use this for initialization
	void Start () 
    {
        craftRoutine = GameObject.Find("CraftingController").GetComponent<CraftRoutine>();
        hammer = GameObject.Find("Crafting/Hammer");
        component = GameObject.Find("Crafting/Component");
        SetScene("workshop");
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryToggle();
        }
	}

    void InventoryToggle()
    {
        if (!craftRoutine.isCrafting() && workshop && !inventoryCanvas.GetComponent<Canvas>().enabled)
        {
            //Debug.Log("Inventory Enabled");
            inventoryCanvas.worldCamera = workCamera;
            inventoryCanvas.GetComponent<Canvas>().enabled = true;
            //inventory.SetActive(true);
            ToggleTools();
        }
        else if (inventoryCanvas.enabled)
        {
            //Debug.Log("Inventory Disabled");
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
}
