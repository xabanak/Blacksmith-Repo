using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    private string name;

    private int value;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    string getName ()
    {
        return name;
    }

    int getValue ()
    {
        return value;
    }

    void setName (string newName)
    {
        name = newName;
    }

    void setValue (int newValue)
    {
        value = newValue;
    }



}
