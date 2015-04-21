using UnityEngine;
using System.Collections;

public class ShowInventory : MonoBehaviour {

    public GameObject inventoryCamera;
    public GameObject workshopCamera;

	// Use this for initialization
	void Start () 
    {
    }
	// Update is called once per frame
	void Update () {
	
	}

    public void DisplayInventory()
    {
        workshopCamera.SetActive(false);
        inventoryCamera.SetActive(true);
    }
}
