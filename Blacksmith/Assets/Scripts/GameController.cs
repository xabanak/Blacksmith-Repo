using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private CraftRoutine craftRoutine;

    public GameObject inventoryCamera;
    public GameObject workshopCamera;
    public GameObject townCamera;

    public Camera workCamera;

    public Canvas workshopCanvas;
    public Canvas inventoryCanvas;

    private bool workshop = true;
    private bool town = false;

	// Use this for initialization
	void Start () 
    {
        craftRoutine = GameObject.Find("CraftingController").GetComponent<CraftRoutine>();

    }
	
	// Update is called once per frame
	void Update () 
    {
        InventoryToggle();
        CanvasToggle();
	}

    void InventoryToggle()
    {
        if (!craftRoutine.isCrafting() && Input.GetKeyDown(KeyCode.I) && workshopCamera.activeSelf)
        {
            workshopCamera.SetActive(false);
            inventoryCamera.SetActive(true);
        }
        else if (!craftRoutine.isCrafting() && Input.GetKeyDown(KeyCode.I) && inventoryCamera.activeSelf && workshop)
        {
            workshopCamera.SetActive(true);
            inventoryCamera.SetActive(false);
        }
        else if (!craftRoutine.isCrafting() && Input.GetKeyDown(KeyCode.I) && inventoryCamera.activeSelf && town)
        {
            townCamera.SetActive(true);
            inventoryCamera.SetActive(false);
        }
    }

    void SetScene(string scene)
    {
        if (scene == "workshop")
        {
            workshop = true;
            town = false;
        }
        else if (scene == "town")
        {
            town = true;
            workshop = false;
        }
    }

    void CanvasToggle()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Changed camera");
            inventoryCanvas.worldCamera = workCamera;
        }
    }
}
