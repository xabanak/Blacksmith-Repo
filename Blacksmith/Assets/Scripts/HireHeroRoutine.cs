using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HireHeroRoutine : MonoBehaviour {

    private TownBehavior townBehavior;
    private string hero;

	// Use this for initialization
	void Start () 
    {
        townBehavior = GameObject.Find("GameController").GetComponent<TownBehavior>();
        hero = gameObject.name;
	}

    void OnMouseDown()
    {
        switch(hero)
        {
            case "Top Window":
                townBehavior.hireAdventurer(1);
                break;
            case "Middle Window":
                townBehavior.hireAdventurer(2);
                break;
            case "Bottom Window":
                townBehavior.hireAdventurer(3);
                break;
            default:
                break;

        }
    }
}
