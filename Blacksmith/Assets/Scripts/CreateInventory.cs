using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CreateInventory : MonoBehaviour {

    public GameObject weaponBackground;
    public GameObject armorBackground;
    public GameObject materialBackground;
    public GameObject componentBackground;
    public GameObject miscBackground;
    public GameObject inventoryWindow;

    public Text textBox1;
    public Text textBox2;

    private Text tempText1;
    private Text tempText2;

    public Canvas inventoryCanvas;
    public GameObject singleLine;
    public GameObject tempLine;

    public Scrollbar inventoryScrollbar;

    private float lineStartPosition = 2.95f;
    private float spacer = 0.35f;

    private int totalItems = 30;
    private int[] testInts;

    private string[] testStrings;

    private ScrollRect tempRect;

    private bool setValue = false;
    private bool resetScrollBar = false;

    private int[] gold;

    // Material declarations
    public int[] fuelQty;
    public int[] fuelCost;
    public string[] fuelName;
    private const int fuelSize = 5;

    public int[] oreQty;
    public int[] oreCost;
    public string[] oreName;
    private const int oreSize = 10;

    public int[] ingotQty;
    public int[] ingotCost;
    public string[] ingotName;
    private const int ingotSize = 10;

    public int[] skinQty;
    public int[] skinCost;
    public string[] skinName;
    private const int skinSize = 10;

    public int[] leatherQty;
    public int[] leatherCost;
    public string[] leatherName;
    private const int leatherSize = 10;

    public int[] gemQty;
    public int[] gemCost;
    public string[] gemName;
    private const int gemSize = 10;

    public int[] gemstoneQty;
    public int[] gemstoneCost;
    public string[] gemstoneName;
    private const int gemstoneSize = 10;

    public int[] woodQty;
    public int[] woodCost;
    public string[] woodName;
    private const int woodSize = 10;

    public int[] lumberQty;
    public int[] lumberCost;
    public string[] lumberName;
    private const int lumberSize = 10;

    // Component declarations
    public int[] leatherStrapQty;
    public int[] leatherStrapCost;
    public string[] leatherStrapName;
    private const int leatherStrapSize = 5;

    public int[] leatherPaddingQty;
    public int[] leatherPaddingCost;
    public string[] leatherPaddingName;
    private const int leatherPaddingSize = 5;

    public int[] hiltQty;
    public int[] hiltCost;
    public string[] hiltName;
    private const int hiltSize = 5;

    public int[] sheathQty;
    public int[] sheathCost;
    public string[] sheathName;
    private const int sheathSize = 5;

    public int[] handleQty;
    public int[] handleCost;
    public string[] handleName;
    private const int handleSize = 5;

    // Weapon & shield declarations
    private SortedInventory swords = new SortedInventory();
    //private SortedInventory axes = new SortedInventory();
    //private SortedInventory maces = new SortedInventory();
    //private SortedInventory flails = new SortedInventory();
    //private SortedInventory hammers = new SortedInventory();
    private SortedInventory shields = new SortedInventory();
    private SortedInventory breastplates = new SortedInventory();
    private SortedInventory helms = new SortedInventory();
    private SortedInventory bracers = new SortedInventory();
    private SortedInventory gauntlets = new SortedInventory();
    private SortedInventory boots = new SortedInventory();
    private SortedInventory greaves = new SortedInventory();
    private SortedInventory pauldrons = new SortedInventory();
    
	// Use this for initialization
	void Start ()
    {
        // Define material types: fuel, ore, ingot, skin, leather, gem, gemstone, wood, lumber
        // Define fuel types
        fuelQty = new int[fuelSize];
        fuelCost = new int[fuelSize];
        fuelName = new string[fuelSize];

        for (int i = 0; i < fuelSize; i++)
        {
            fuelQty[i] = 0;
        }

        fuelCost[0] = 1;
        fuelCost[1] = 5;
        fuelCost[2] = 20;
        fuelCost[3] = 50;
        fuelCost[4] = 100;

        fuelName[0] = "Basic Fuel";
        fuelName[1] = "Standard Fuel";
        fuelName[2] = "Good Fuel";
        fuelName[3] = "Excellent Fuel";
        fuelName[4] = "Expert Fuel";
        // End Define fuel types

        // Define ore types
        oreQty = new int[oreSize];
        oreCost = new int[oreSize];
        oreName = new string[oreSize];

        for (int i = 0; i < oreSize; i++)
        {
            oreQty[i] = 0;
        }

        oreCost[0] = 50;
        oreCost[1] = 100;
        oreCost[2] = 200;
        oreCost[3] = 300;
        oreCost[4] = 400;
        oreCost[5] = 500;
        oreCost[6] = 600;
        oreCost[7] = 700;
        oreCost[8] = 800;
        oreCost[9] = 900;

        oreName[0] = "Tin Ore";
        oreName[1] = "Copper Ore";
        oreName[2] = "Zinc Ore";
        oreName[3] = "Iron Ore";
        oreName[4] = "Black Ore";
        oreName[5] = "Nickel Ore";
        oreName[6] = "Carbon Ore";
        oreName[7] = "Manganese Ore";
        oreName[8] = "Chromium Ore";
        oreName[9] = "Dragon Ore";
        // End Define ore types

        // Define ingot types
        ingotQty = new int[ingotSize];
        ingotCost = new int[ingotSize];
        ingotName = new string[ingotSize];

        for (int i = 0; i < ingotSize; i++)
        {
            ingotQty[i] = 0;
        }

        ingotCost[0] = 100;
        ingotCost[1] = 200;
        ingotCost[2] = 300;
        ingotCost[3] = 400;
        ingotCost[4] = 500;
        ingotCost[5] = 600;
        ingotCost[6] = 700;
        ingotCost[7] = 800;
        ingotCost[8] = 900;
        ingotCost[9] = 1000;
        

        ingotName[0] = "Tin Ingot";
        ingotName[1] = "Copper Ingot";
        ingotName[2] = "Bronze Ingot";
        ingotName[3] = "Brass Ingot";
        ingotName[4] = "Iron Ingot";
        ingotName[5] = "Blackened Iron Ingot";
        ingotName[6] = "Steel Ingot";
        ingotName[7] = "Low Grade Steel Alloy Ingot";
        ingotName[8] = "High Grade Steel Alloy Ingot";
        ingotName[9] = "Titanium Ingot";
        // End Define ingot types

        // Define skin types
        skinQty = new int[skinSize];
        skinCost = new int[skinSize];
        skinName = new string[skinSize];

        for (int i = 0; i < skinSize; i++)
        {
            skinQty[i] = 0;
        }

        skinCost[0] = 50;
        skinCost[1] = 100;
        skinCost[2] = 150;
        skinCost[3] = 200;
        skinCost[4] = 250;
        skinCost[5] = 300;
        skinCost[6] = 350;
        skinCost[7] = 400;
        skinCost[8] = 450;
        skinCost[9] = 500;


        skinName[0] = "Sheep Skin";
        skinName[1] = "Goat Skin";
        skinName[2] = "Buffalo Skin";
        skinName[3] = "Dodo Skin";
        skinName[4] = "Serpent Skin";
        skinName[5] = "Wolf Skin";
        skinName[6] = "Ogre Skin";
        skinName[7] = "Troll Skin";
        skinName[8] = "Wyvern Skin";
        skinName[9] = "Dragon Skin";
        // End Define skin types

        // Define leather types
        leatherQty = new int[leatherSize];
        leatherCost = new int[leatherSize];
        leatherName = new string[leatherSize];

        for (int i = 0; i < leatherSize; i++)
        {
            leatherQty[i] = 0;
        }

        leatherCost[0] = 100;
        leatherCost[1] = 200;
        leatherCost[2] = 300;
        leatherCost[3] = 400;
        leatherCost[4] = 500;
        leatherCost[5] = 600;
        leatherCost[6] = 700;
        leatherCost[7] = 800;
        leatherCost[8] = 900;
        leatherCost[9] = 1000;

        leatherName[0] = "Sheep Leather";
        leatherName[1] = "Goat Leather";
        leatherName[2] = "Buffalo Leather";
        leatherName[3] = "Dodo Leather";
        leatherName[4] = "Serpent Leather";
        leatherName[5] = "Wolf Leather";
        leatherName[6] = "Ogre Leather";
        leatherName[7] = "Troll Leather";
        leatherName[8] = "Wyvern Leather";
        leatherName[9] = "Dragon Leather";
        // End Define leather types

        // Define gem types
        gemQty = new int[gemSize];
        gemCost = new int[gemSize];
        gemName = new string[gemSize];

        for (int i = 0; i < gemSize; i++)
        {
            gemQty[i] = 0;
        }

        gemCost[0] = 200;
        gemCost[1] = 400;
        gemCost[2] = 600;
        gemCost[3] = 800;
        gemCost[4] = 1000;
        gemCost[5] = 1200;
        gemCost[6] = 1400;
        gemCost[7] = 1600;
        gemCost[8] = 1800;
        gemCost[9] = 2000;

        gemName[0] = "Rough Malachite";
        gemName[1] = "Rough Lapis Lazuli";
        gemName[2] = "Rough Turquoise";
        gemName[3] = "Rough Coral";
        gemName[4] = "Rough Agate";
        gemName[5] = "Rough Jasper";
        gemName[6] = "Rough Opal";
        gemName[7] = "Rough Ruby";
        gemName[8] = "Rough Pearl";
        gemName[9] = "Rough Moonstone";
        // End Define gem types

        // Define gemstone types
        gemstoneQty = new int[gemstoneSize];
        gemstoneCost = new int[gemstoneSize];
        gemstoneName = new string[gemstoneSize];

        for (int i = 0; i < gemstoneSize; i++)
        {
            gemstoneQty[i] = 0;
        }

        gemstoneCost[0] = 400;
        gemstoneCost[1] = 800;
        gemstoneCost[2] = 1200;
        gemstoneCost[3] = 1600;
        gemstoneCost[4] = 2000;
        gemstoneCost[5] = 2400;
        gemstoneCost[6] = 2800;
        gemstoneCost[7] = 3200;
        gemstoneCost[8] = 3600;
        gemstoneCost[9] = 4000;

        gemstoneName[0] = "Polished Malchite";
        gemstoneName[1] = "Polished Lapis Lazuli";
        gemstoneName[2] = "Polished Turquoise";
        gemstoneName[3] = "Polished Coral";
        gemstoneName[4] = "Polished Agate";
        gemstoneName[5] = "Polished Jasper";
        gemstoneName[6] = "Polished Opal";
        gemstoneName[7] = "Polished Ruby";
        gemstoneName[8] = "Polished Pearl";
        gemstoneName[9] = "Polished Moonstone";
        // End Define gemstone types

        // Define wood types
        woodQty = new int[woodSize];
        woodCost = new int[woodSize];
        woodName = new string[woodSize];

        for (int i = 0; i < woodSize; i++)
        {
            woodQty[i] = 0;
        }

        woodCost[0] = 50;
        woodCost[1] = 100;
        woodCost[2] = 200;
        woodCost[3] = 300;
        woodCost[4] = 400;
        woodCost[5] = 500;
        woodCost[6] = 600;
        woodCost[7] = 700;
        woodCost[8] = 800;
        woodCost[9] = 900;

        woodName[0] = "Raw Elm";
        woodName[1] = "Raw Alder";
        woodName[2] = "Raw Maple";
        woodName[3] = "Raw Sandlewood";
        woodName[4] = "Raw Ash";
        woodName[5] = "Raw Fir";
        woodName[6] = "Raw Cedar";
        woodName[7] = "Raw Ironwood";
        woodName[8] = "Raw Rosewood";
        woodName[9] = "Raw Ebony";
        // End Define wood types

        // Define lumber types
        lumberQty = new int[lumberSize];
        lumberCost = new int[lumberSize];
        lumberName = new string[lumberSize];

        for (int i = 0; i < lumberSize; i++)
        {
            lumberQty[i] = 0;
        }

        lumberCost[0] = 100;
        lumberCost[1] = 200;
        lumberCost[2] = 300;
        lumberCost[3] = 400;
        lumberCost[4] = 500;
        lumberCost[5] = 600;
        lumberCost[6] = 700;
        lumberCost[7] = 800;
        lumberCost[8] = 900;
        lumberCost[9] = 1000;

        lumberName[0] = "Elm Lumber";
        lumberName[1] = "Alder Lumber";
        lumberName[2] = "Maple Lumber";
        lumberName[3] = "Sandalwood Lumber";
        lumberName[4] = "Ash Lumber";
        lumberName[5] = "Fir Lumber";
        lumberName[6] = "Cedar Lumber";
        lumberName[7] = "Ironwood Lumber";
        lumberName[8] = "Rosewood Lumber";
        lumberName[9] = "Ebony Lumber";
        // End Define lumber types
        // End Define material types

        // Define component types: leatherStrap, leatherPadding, hilt, sheath, handle
        // Define leatherStrap types
        leatherStrapQty = new int[leatherStrapSize];
        leatherStrapCost = new int[leatherStrapSize];
        leatherStrapName = new string[leatherStrapSize];

        for (int i = 0; i < leatherStrapSize; i++)
        {
            leatherStrapQty[i] = 0;
        }

        leatherStrapCost[0] = 25;
        leatherStrapCost[1] = 50;
        leatherStrapCost[2] = 100;
        leatherStrapCost[3] = 150;
        leatherStrapCost[4] = 200;

        leatherStrapName[0] = "Basic Leather Strap";
        leatherStrapName[1] = "Standard Leather Strap";
        leatherStrapName[2] = "Good Leather Strap";
        leatherStrapName[3] = "Excellent Leather Strap";
        leatherStrapName[4] = "Expert Leather Strap";

        // Define leatherPadding types
        leatherPaddingQty = new int[leatherPaddingSize];
        leatherPaddingCost = new int[leatherPaddingSize];
        leatherPaddingName = new string[leatherPaddingSize];

        for (int i = 0; i < leatherPaddingSize; i++)
        {
            leatherPaddingQty[i] = 0;
        }

        leatherPaddingCost[0] = 25;
        leatherPaddingCost[1] = 50;
        leatherPaddingCost[2] = 100;
        leatherPaddingCost[3] = 150;
        leatherPaddingCost[4] = 200;

        leatherPaddingName[0] = "Basic Leather Padding";
        leatherPaddingName[1] = "Standard Leather Padding";
        leatherPaddingName[2] = "Good Leather Padding";
        leatherPaddingName[3] = "Excellent Leather Padding";
        leatherPaddingName[4] = "Expert Leather Padding";
        // End Define leatherPadding types

        // Define hilt types
        hiltQty = new int[hiltSize];
        hiltCost = new int[hiltSize];
        hiltName = new string[hiltSize];

        for (int i = 0; i < hiltSize; i++)
        {
            hiltQty[i] = 0;
        }

        hiltCost[0] = 50;
        hiltCost[1] = 100;
        hiltCost[2] = 150;
        hiltCost[3] = 250;
        hiltCost[4] = 500;

        hiltName[0] = "Basic Hilt";
        hiltName[1] = "Standard Hilt";
        hiltName[2] = "Good Hilt";
        hiltName[3] = "Excellent Hilt";
        hiltName[4] = "Expert Hilt";
        // End Define hilt types

        // Define sheath types
        sheathQty = new int[sheathSize];
        sheathCost = new int[sheathSize];
        sheathName = new string[sheathSize];

        for (int i = 0; i < sheathSize; i++)
        {
            sheathQty[i] = 0;
        }

        sheathCost[0] = 25;
        sheathCost[1] = 50;
        sheathCost[2] = 75;
        sheathCost[3] = 100;
        sheathCost[4] = 200;

        sheathName[0] = "Basic Sheath";
        sheathName[1] = "Standard Sheath";
        sheathName[2] = "Good Sheath";
        sheathName[3] = "Excellent Sheath";
        sheathName[4] = "Expert Sheath";
        // End Define sheath types

        // Define handle types
        handleQty = new int[handleSize];
        handleCost = new int[handleSize];
        handleName = new string[handleSize];

        for (int i = 0; i < handleSize; i++)
        {
            handleQty[i] = 0;
        }

        handleCost[0] = 30;
        handleCost[1] = 60;
        handleCost[2] = 90;
        handleCost[3] = 120;
        handleCost[4] = 250;

        handleName[0] = "Basic Handle";
        handleName[1] = "Standard Handle";
        handleName[2] = "Good Handle";
        handleName[3] = "Excellent Handle";
        handleName[4] = "Expert Handle";
        // End Define handle types

        SetQuantitiesTestMethod();
	}

    void SetQuantitiesTestMethod()
    {
        for (int i = 0; i < 5; i++)
        {
            fuelQty[i] = UnityEngine.Random.Range(1, 9);
            oreQty[i] = UnityEngine.Random.Range(1, 9);
            ingotQty[i] = UnityEngine.Random.Range(1, 9);
            skinQty[i] = UnityEngine.Random.Range(1, 9);
            leatherQty[i] = UnityEngine.Random.Range(1, 9);
            gemQty[i] = UnityEngine.Random.Range(1, 9);
            gemstoneQty[i] = UnityEngine.Random.Range(1, 9);
            woodQty[i] = UnityEngine.Random.Range(1, 9);
            lumberQty[i] = UnityEngine.Random.Range(1, 9);
        }

        for (int i = 0; i < 5; i++)
        {
            leatherStrapQty[i] = UnityEngine.Random.Range(1, 9);
            leatherPaddingQty[i] = UnityEngine.Random.Range(1, 9);
            hiltQty[i] = UnityEngine.Random.Range(1, 9);
            sheathQty[i] = UnityEngine.Random.Range(1, 9);
            handleQty[i] = UnityEngine.Random.Range(1, 9);
        }
    }

	// Update is called once per frame
	void Update ()
    {

	}

    public void ResetScrollbar()
    {
        inventoryScrollbar.value = 1;
    }

    // Calls all updates to update the current on hand inventory.
    public void BuildInventory()
    {
        ClearInventory();
        UpdateWeaponList();
        UpdateArmorList();
        UpdateMaterialList();
        UpdateComponentList();
        //UpdateMiscList();

        DisableInventoryWindows();
    }

    // Creates the list displaying all the weapons in inventory.
    public void UpdateWeaponList()
    {
        int tempInt = 17 - swords.GetCurrentSize();
        Debug.Log("Size: " + swords.GetCurrentSize());
        for (int i = 0; i < swords.GetCurrentSize(); i++)
        {
            tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, inventoryCanvas.transform.position.z - 1), Quaternion.identity) as GameObject;
            tempLine.transform.SetParent(weaponBackground.transform);
            tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, inventoryCanvas.transform.position.z - 1), Quaternion.identity) as Text;
            tempText1.transform.SetParent(tempLine.transform);
            tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText1.text = swords.GetItem(i).GetComponent<ItemScript>().GetItemDescription();
        }

        if (tempInt > 0)
        {
            for (int i = swords.GetCurrentSize(); i < 17; i++)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, inventoryCanvas.transform.position.z - 1), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(weaponBackground.transform);
                Debug.Log("Line space " + i);
            }
        }
    }

    // Creates a list displaying all the armor/shields in inventory.
    void UpdateArmorList()
    {
        for (int i = 0; i < shields.GetCurrentSize(); i++)
        {
            tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
            tempLine.transform.SetParent(armorBackground.transform);
            tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText1.transform.SetParent(tempLine.transform);
            tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText1.text = shields.GetItem(i).GetComponent<ItemScript>().GetItemDescription();
        }

        for (int i = 0; i < breastplates.GetCurrentSize(); i++)
        {
            tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
            tempLine.transform.SetParent(armorBackground.transform);
            tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText1.transform.SetParent(tempLine.transform);
            tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText1.text = breastplates.GetItem(i).GetComponent<ItemScript>().GetItemDescription();
        }

        for (int i = 0; i < helms.GetCurrentSize(); i++)
        {
            tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
            tempLine.transform.SetParent(armorBackground.transform);
            tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText1.transform.SetParent(tempLine.transform);
            tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText1.text = helms.GetItem(i).GetComponent<ItemScript>().GetItemDescription();
        }

        for (int i = 0; i < bracers.GetCurrentSize(); i++)
        {
            tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
            tempLine.transform.SetParent(armorBackground.transform);
            tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText1.transform.SetParent(tempLine.transform);
            tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText1.text = bracers.GetItem(i).GetComponent<ItemScript>().GetItemDescription();
        }

        for (int i = 0; i < gauntlets.GetCurrentSize(); i++)
        {
            tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
            tempLine.transform.SetParent(armorBackground.transform);
            tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText1.transform.SetParent(tempLine.transform);
            tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText1.text = gauntlets.GetItem(i).GetComponent<ItemScript>().GetItemDescription();
        }

        for (int i = 0; i < boots.GetCurrentSize(); i++)
        {
            tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
            tempLine.transform.SetParent(armorBackground.transform);
            tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText1.transform.SetParent(tempLine.transform);
            tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText1.text = boots.GetItem(i).GetComponent<ItemScript>().GetItemDescription();
        }

        for (int i = 0; i < greaves.GetCurrentSize(); i++)
        {
            tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
            tempLine.transform.SetParent(armorBackground.transform);
            tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText1.transform.SetParent(tempLine.transform);
            tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText1.text = greaves.GetItem(i).GetComponent<ItemScript>().GetItemDescription();
        }

        for (int i = 0; i < pauldrons.GetCurrentSize(); i++)
        {
            tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
            tempLine.transform.SetParent(armorBackground.transform);
            tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText1.transform.SetParent(tempLine.transform);
            tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText1.text = pauldrons.GetItem(i).GetComponent<ItemScript>().GetItemDescription();
        }
    }

    // Creates a list displaying all the materials in inventory.
    public void UpdateMaterialList()
    {
        // fuel, ore, ingot, skin, leather, gem, gemstone, wood, lumber

        // Generate fuel list
        for (int i = 0; i < fuelSize; i++)
        {
            if (fuelQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(materialBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = fuelName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + fuelQty[i];
            }
        }
        
        // Generate ore list
        for (int i = 0; i < oreSize; i++)
        {
            if (oreQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(materialBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = oreName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + oreQty[i];
            }
        }

        // Generate ingot list
        for (int i = 0; i < ingotSize; i++)
        {
            if (ingotQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(materialBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = ingotName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + ingotQty[i];
            }
        }

        // Generate skin list
        for (int i = 0; i < skinSize; i++)
        {
            if (skinQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(materialBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = skinName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + skinQty[i];
            }
        }

        // Generate leather list
        for (int i = 0; i < leatherSize; i++)
        {
            if (leatherQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(materialBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = leatherName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + leatherQty[i];
            }
        }

        // Generate gem list
        for (int i = 0; i < gemSize; i++)
        {
            if (gemQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(materialBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = gemName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + gemQty[i];
            }
        }
        
        // Generate gemstone list
        for (int i = 0; i < gemstoneSize; i++)
        {
            if (gemstoneQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(materialBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = gemstoneName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + gemstoneQty[i];
            }
        }

        // Generate wood list
        for (int i = 0; i < woodSize; i++)
        {
            if (woodQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(materialBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = woodName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + woodQty[i];
            }
        }

        // Generate lumber list
        for (int i = 0; i < lumberSize; i++)
        {
            if (lumberQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(materialBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = lumberName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + lumberQty[i];
            }
        }
    }

    // Creates a list displaying all the components in inventory.
    public void UpdateComponentList()
    {
        // leatherStrap, leatherPadding, hilt, sheath, handle

        // Generate leatherStrap list
        for (int i = 0; i < leatherStrapSize; i++)
        {
            if (leatherStrapQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(componentBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = leatherStrapName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + leatherStrapQty[i];
            }
        }

        // Generate leatherPadding list
        for (int i = 0; i < leatherPaddingSize; i++)
        {
            if (leatherPaddingQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(componentBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = leatherPaddingName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + leatherPaddingQty[i];
            }
        }

        // Generate hilt list
        for (int i = 0; i < hiltSize; i++)
        {
            if (hiltQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(componentBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = hiltName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + hiltQty[i];
            }
        }

        // Generate sheath list
        for (int i = 0; i < sheathSize; i++)
        {
            if (sheathQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(componentBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = sheathName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + sheathQty[i];
            }
        }

        // Generate handle list
        for (int i = 0; i < handleSize; i++)
        {
            if (handleQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(componentBackground.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = handleName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + handleQty[i];
            }
        }
    }

    // Creates a list displaying all the miscellaneous items in inventory.
    /*void UpdateMiscList()
    {

    }*/

    // Set the weapons window as the only active window
    public void viewWeaponList()
    {
        // weapons
        weaponBackground.SetActive(true);
        armorBackground.SetActive(false);
        materialBackground.SetActive(false);
        componentBackground.SetActive(false);
        miscBackground.SetActive(false);

        inventoryWindow.GetComponent<ScrollRect>().content = weaponBackground.GetComponent<RectTransform>();

        ResetScrollbar();
    }

    // Set the armor window as the only active window
    public void viewArmorList()
    {
        // armor
        weaponBackground.SetActive(false);
        armorBackground.SetActive(true);
        materialBackground.SetActive(false);
        componentBackground.SetActive(false);
        miscBackground.SetActive(false);

        inventoryWindow.GetComponent<ScrollRect>().content = armorBackground.GetComponent<RectTransform>();

        ResetScrollbar();
    }

    // Set the material window as the only active window
    public void viewMaterialList()
    {
        // materials
        weaponBackground.SetActive(false);
        armorBackground.SetActive(false);
        materialBackground.SetActive(true);
        componentBackground.SetActive(false);
        miscBackground.SetActive(false);

        inventoryWindow.GetComponent<ScrollRect>().content = materialBackground.GetComponent<RectTransform>();

        ResetScrollbar();
    }

    // Set the component window as the only active window
    public void viewComponentList()
    {
        // components
        weaponBackground.SetActive(false);
        armorBackground.SetActive(false);
        materialBackground.SetActive(false);
        componentBackground.SetActive(true);
        miscBackground.SetActive(false);

        inventoryWindow.GetComponent<ScrollRect>().content = componentBackground.GetComponent<RectTransform>();

        ResetScrollbar();
    }

    // Set the miscellaneous window as the only active window
    public void viewMiscList()
    {
        // misc
        weaponBackground.SetActive(false);
        armorBackground.SetActive(false);
        materialBackground.SetActive(false);
        componentBackground.SetActive(false);
        miscBackground.SetActive(true);

        inventoryWindow.GetComponent<ScrollRect>().content = miscBackground.GetComponent<RectTransform>();

        ResetScrollbar();
    }

    // Take an item object and add it to the on hand inventory.
    public void AddNewItem(GameObject newItem)
    {
        // Item types: sword, shield, breastplate, helm, bracers, gauntlets, boots, greaves, pauldrons.

        // Stores the item type to determine what sortedArray to store the GameObject in.
        string itemType = newItem.GetComponent<ItemScript>().GetItem();

        switch (itemType)
        {
            case "Sword":
                swords.AddItem(newItem);
                break;

            case "Shield":
                shields.AddItem(newItem);
                break;

            case "Breastplate":
                breastplates.AddItem(newItem);
                break;

            case "Helm":
                helms.AddItem(newItem);
                break;

            case "Bracers":
                bracers.AddItem(newItem);
                break;

            case "Gauntlets":
                gauntlets.AddItem(newItem);
                break;

            case "Boots":
                boots.AddItem(newItem);
                break;

            case "Greaves":
                greaves.AddItem(newItem);
                break;

            case "Pauldrons":
                pauldrons.AddItem(newItem);
                break;

            default:
                Debug.Log("Item type was not found.");
                break;
        }

        BuildInventory();
    }

    private void DisableInventoryWindows()
    {
        weaponBackground.SetActive(false);
        armorBackground.SetActive(false);
        materialBackground.SetActive(false);
        componentBackground.SetActive(false);
        miscBackground.SetActive(false);
    }

    public void ClearInventory()
    {
        foreach (Transform child in weaponBackground.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in armorBackground.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in materialBackground.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in componentBackground.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public int getConstantSize(string item)
    {
        switch(item)
        {
            case "fuel":
                return fuelSize;
            case "ore":
                return oreSize;
            case "ingot":
                return ingotSize;
            case "skin":
                return skinSize;
            case "leather":
                return leatherSize;
            case "gem":
                return gemSize;
            case "gemstone":
                return gemstoneSize;
            case "wood":
                return woodSize;
            case "lumber":
                return lumberSize;
            case "leather strap":
                return leatherStrapSize;
            case "leather padding":
                return leatherPaddingSize;
            case "hilt":
                return hiltSize;
            case "sheath":
                return sheathSize;
            case "handle":
                return handleSize;
            default:
                Debug.Log("Item type " + item + " not found");
                return 0;
        }
    }
}

public class SortedInventory
{
    private int inventorySize = 10;
    public int currentSize = 0;
    private GameObject[] storedItems;

    public SortedInventory()
    {
        storedItems = new GameObject[inventorySize];
        for (int i = 0; i < inventorySize; i++)
        {
            storedItems[i] = null;
        }
    }

    private void IncreaseSize()
    {
        inventorySize *= 2;
        GameObject[] tempArray = new GameObject[inventorySize];
        int count = 0;
        foreach(GameObject item in storedItems)
        {
            tempArray[count] = storedItems[count];
            count++;
        }
        storedItems = tempArray;
    }

    private void DecreaseSize()
    {
        inventorySize /= 2;
        GameObject[] tempArray = new GameObject[inventorySize];
        int count = 0;
        foreach (GameObject item in storedItems)
        {
            tempArray[count] = storedItems[count];
            count++;
        }
        storedItems = tempArray;
    }

    public bool AddItem(GameObject item)
    {
        if (currentSize >= (inventorySize/2))
        {
            IncreaseSize();
        }

        string material = item.GetComponent<ItemScript>().GetMaterial();

        if (currentSize == 0)
        {
            InsertItem(item, currentSize);
            currentSize++;
            return true;
        }
        else if (currentSize > 0)
        {
            for (int i = 0; i < currentSize; i++)
            {
                if ((int)Enum.Parse(typeof(Material), material) <= (int)Enum.Parse(typeof(Material), storedItems[i].GetComponent<ItemScript>().GetMaterial()))
                {
                    if(i == (currentSize-1))
                    {
                        InsertItem(item, (i + 1));
                        currentSize++;
                        return true;
                    }

                    continue;
                }
                else if ((int)Enum.Parse(typeof(Material), material) > (int)Enum.Parse(typeof(Material), storedItems[i].GetComponent<ItemScript>().GetMaterial()))
                {
                    InsertItem(item, i);
                    currentSize++;
                    return true;
                }
            }
        }
        Debug.Log("Unable to add item to inventory");
        return false;
    }

    public bool RemoveItem(GameObject item)
    {
        for(int i = 0; i < currentSize; i++)
        {
            if (storedItems[i] == item)
            {
                if (i == (currentSize - 1))
                {
                    storedItems[i] = storedItems[i + 1];
                    currentSize--;
                }
                else
                {
                    for (int j = i; j < (currentSize - 1); j++)
                    {
                        storedItems[j] = storedItems[j + 1];
                    }
                    currentSize--;
                    storedItems[currentSize] = storedItems[currentSize + 1];
                }
                if ((inventorySize / 2)  > currentSize)
                {
                    if (inventorySize > 10)
                    {
                        DecreaseSize();
                    }
                }
                return true;
            }
        }
        return false;
    }

    private void InsertItem(GameObject item, int insertionPoint)
    {
        //Debug.Log("Insertion point is: " + insertionPoint);
        for(int i = currentSize; i >= insertionPoint; i--)
        {
            //Debug.Log("current size is: " + currentSize);
            //Debug.Log("Swapped: " + i + " times");
            storedItems[i + 1] = storedItems[i];
        }

        //Debug.Log("Item type: " + item.GetComponent<ItemScript>().GetMaterial());
        storedItems[insertionPoint] = item;

        //Debug.Log("InsertItem finished");
    }

    public GameObject GetItem(int index)
    {
        return storedItems[index];
    }

    public int GetCurrentSize()
    {
        return currentSize;
    }

    enum Material
    {
        Tin = 0,
        Copper,
        Bronze,
        Brass,
        Iron,
        BlackenedIron,
        Steel,
        SteelAlloyL1,
        SteelAlloyL2,
        Titanium
    }
}
