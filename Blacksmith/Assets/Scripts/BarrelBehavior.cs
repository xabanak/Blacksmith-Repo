using UnityEngine;
using System.Collections;

public class BarrelBehavior : MonoBehaviour {

    private CraftRoutine craftRoutine;

    void OnMouseDown()
    {
        if (craftRoutine.isComponentInbarrel())
        {
            craftRoutine.toggleComponentInBarrel();
        }
    }
	void Start () 
    {
        craftRoutine = GameObject.Find("Crafting/CraftingController").GetComponent<CraftRoutine>();
	}

	void Update () {
	
	}
}
