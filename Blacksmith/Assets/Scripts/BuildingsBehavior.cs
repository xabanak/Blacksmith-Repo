using UnityEngine;
using System.Collections;

public class BuildingsBehavior : MonoBehaviour {

    private string name;
    private TownBehavior townBehavior;

	// Use this for initialization
	void Start () 
    {
        name = gameObject.name;
        townBehavior = GameObject.Find("GameController").GetComponent<TownBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        switch(name)
        {
            case "Tavern":
                townBehavior.toggleTavernWindow();
                townBehavior.getAdventurerSet();
                townBehavior.setTavernWindow();
                break;
            default:
                break;
        }
    }
}
