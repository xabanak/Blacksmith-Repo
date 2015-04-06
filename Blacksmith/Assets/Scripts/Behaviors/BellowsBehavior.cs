using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BellowsBehavior : MonoBehaviour 
{
    public CraftRoutine craftController;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
    void OnMouseDown()
    {
        craftController.bellowsPump();
    }
	// Update is called once per frame
	void Update () 
    {
	
	}
}
