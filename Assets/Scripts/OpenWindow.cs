using UnityEngine;
using System.Collections;

public class OpenWindow : MonoBehaviour {

    private BuildingsBehavior buildingsBehavior;

	// Use this for initialization
	void Start () 
    {
        buildingsBehavior = GameObject.Find("Town/Buildings").GetComponent<BuildingsBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        buildingsBehavior.openWindow(gameObject.name);
    }
}
