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
        InventoryToggle();
	}

    void InventoryToggle()
    {
        if (!craftRoutine.isCrafting() && Input.GetKeyDown(KeyCode.I) && workshop && !inventory.activeSelf)
        {
            //Debug.Log("Inventory Enabled");
            inventoryCanvas.worldCamera = workCamera;
            inventory.SetActive(true);
            ToggleTools();
        }
        else if (Input.GetKeyDown(KeyCode.I) && inventory.activeSelf)
        {
            //Debug.Log("Inventory Disabled");
            inventoryCanvas.worldCamera = inventoryCamera;
            inventory.SetActive(false);
            ToggleTools();
        }
        else if (Input.GetKeyDown(KeyCode.I) && town && !inventory.activeSelf)
        {
            inventoryCanvas.worldCamera = townCamera;
        }
        else if (Input.GetKeyDown(KeyCode.I) && inventory.activeSelf)
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
        component.SetActive(!component.activeSelf);
    }
}
