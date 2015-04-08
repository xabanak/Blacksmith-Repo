using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryRoutine : MonoBehaviour {

    private const int ARRAY_SIZE = 5;
    private int[] itemQuant;
    private string[] itemName;

    private int[] gold;
    private int[] weapon;
    private int[] armor;
    private int[] fuel; 
    private int[] ore;
    private int[] ingot;
    private int[] skin;
    private int[] leather;
    private int[] gem;
    private int[] gemstone;
    private int[] wood;
    private int[] lumber;
    private int[] leatherStrap;
    private int[] leatherPadding;
    private int[] hilt;
    private int[] sheath;
    private int[] handle;
    private int[] sword;
    private int[] axe;
    private int[] mace;
    private int[] flail;
    private int[] hammer;
    private int[] head;
    private int[] neck;
    private int[] chest;
    private int[] shoulders;
    private int[] arms;
    private int[] wrists;
    private int[] hands;
    private int[] legs;
    private int[] feet;
    private int[] shield;

    private bool isDisplayed = false;
    private bool shouldDisplay = false;

    public Text tester;

	// Use this for initialization
	void Start () {
	    itemQuant = new int[ARRAY_SIZE];
        itemName = new string[ARRAY_SIZE];

        itemQuant[0] = 1;
        itemQuant[1] = 0;
        itemQuant[2] = 0;
        itemQuant[3] = 3;
        itemQuant[4] = 2;

        itemName[0] = "Tin";
        itemName[1] = "Copper";
        itemName[2] = "Bronze";
        itemName[3] = "Brass";
        itemName[4] = "Iron";

        tester.text = "";
        tester.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (!isDisplayed && shouldDisplay)
        {
            isDisplayed = true;
            tester.enabled = true;
            DisplayInventory();
        }
        else if (isDisplayed && !shouldDisplay)
        {
            isDisplayed = false;
            tester.enabled = false;
        }
	}

    public void DisplayInventoryToggle()
    {
        if (shouldDisplay)
        {
            shouldDisplay = false;
        }
        else
        {
            shouldDisplay = true;
        }
    }

    void DisplayInventory()
    {
        tester.text = "";

        for (int i = 0; i < ARRAY_SIZE; i++)
        {
            if (itemQuant[i] > 0)
            {
                tester.text = tester.text + "Name: "  + itemName[i] + " Quantity: " + itemQuant[i] + "\n";
            }
        }
    }


}
