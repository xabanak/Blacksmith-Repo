using UnityEngine;
using System.Collections;

public class ShowInventory : MonoBehaviour {

    private GameObject inventoryCamera;
    private GameObject craftingCamera;

	// Use this for initialization
	void Start () 
    {
        inventoryCamera = GameObject.Find("Inventory/Inventory Camera");
        craftingCamera = GameObject.Find("Crafting/Crafting Camera");
    }
	// Update is called once per frame
	void Update () {
	
	}

    public void DisplayInventory()
    {
        craftingCamera.SetActive(false);
        inventoryCamera.SetActive(true);
    }
}
