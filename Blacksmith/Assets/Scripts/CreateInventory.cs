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
    private int[] fuelQty;
    private string[] fuelName;
    private const int fuelSize = 5;

    private int[] oreQty;
    private string[] oreName;
    private const int oreSize = 10;

    private int[] ingotQty;
    private string[] ingotName;
    private const int ingotSize = 10;

    private int[] skinQty;
    private string[] skinName;
    private const int skinSize = 10;

    private int[] leatherQty;
    private string[] leatherName;
    private const int leatherSize = 10;

    private int[] gemQty;
    private string[] gemName;
    private const int gemSize = 10;

    private int[] gemstoneQty;
    private string[] gemstoneName;
    private const int gemstoneSize = 10;

    private int[] woodQty;
    private string[] woodName;
    private const int woodSize = 10;

    private int[] lumberQty;
    private string[] lumberName;
    private const int lumberSize = 10;

    // Component declarations
    private int[] leatherStrapQty;
    private string[] leatherStrapName; 
    private const int leatherStrapSize = 5;

    private int[] leatherPaddingQty;
    private string[] leatherPaddingName;
    private const int leatherPaddingSize = 5;

    private int[] hiltQty;
    private string[] hiltName;
    private const int hiltSize = 5;

    private int[] sheathQty;
    private string[] sheathName;
    private const int sheathSize = 5;

    private int[] handleQty;
    private string[] handleName;
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
        fuelName = new string[fuelSize];

        for (int i = 0; i < fuelSize; i++)
        {
            fuelQty[i] = 0;
        }

        fuelName[0] = "Basic Fuel";
        fuelName[1] = "Standard Fuel";
        fuelName[2] = "Good Fuel";
        fuelName[3] = "Excellent Fuel";
        fuelName[4] = "Expert Fuel";
        // End Define fuel types

        // Define ore types
        oreQty = new int[oreSize];
        oreName = new string[oreSize];

        for (int i = 0; i < oreSize; i++)
        {
            oreQty[i] = 0;
        }

        oreName[0] = "Tin Ore";
        oreName[1] = "Copper Ore";
        oreName[2] = "Zinc Ore";
        oreName[3] = "Black Ore";
        oreName[4] = "Unknown Ore 5";
        oreName[5] = "Unknown Ore 6";
        oreName[6] = "Unknown Ore 7";
        oreName[7] = "Unknown Ore 8";
        oreName[8] = "Unknown Ore 9";
        oreName[9] = "Unknown Ore 10";
        // End Define ore types

        // Define ingot types
        ingotQty = new int[ingotSize];
        ingotName = new string[ingotSize];

        for (int i = 0; i < ingotSize; i++)
        {
            ingotQty[i] = 0;
        }

        ingotName[0] = "Tin Ingot";
        ingotName[1] = "Copper Ingot";
        ingotName[2] = "Bronze Ingot";
        ingotName[3] = "Brass Ingot";
        ingotName[4] = "Iron Ingot";
        ingotName[5] = "BlackenedIron Ingot";
        ingotName[6] = "Steel Ingot";
        ingotName[7] = "SteelAlloyL1 Ingot";
        ingotName[8] = "SteelAlloyL2 Ingot";
        ingotName[9] = "Titanium Ingot";
        // End Define ingot types

        // Define skin types
        skinQty = new int[skinSize];
        skinName = new string[skinSize];

        for (int i = 0; i < skinSize; i++)
        {
            skinQty[i] = 0;
        }

        skinName[0] = "Sheep Skin";
        skinName[1] = "Buffalo Skin";
        skinName[2] = "Unknown Skin 3";
        skinName[3] = "Unknown Skin 4";
        skinName[4] = "Unknown Skin 5";
        skinName[5] = "Unknown Skin 6";
        skinName[6] = "Unknown Skin 7";
        skinName[7] = "Unknown Skin 8";
        skinName[8] = "Unknown Skin 9";
        skinName[9] = "Unknown Skin 10";
        // End Define skin types

        // Define leather types
        leatherQty = new int[leatherSize];
        leatherName = new string[leatherSize];

        for (int i = 0; i < leatherSize; i++)
        {
            leatherQty[i] = 0;
        }

        leatherName[0] = "Unknown Leather 1";
        leatherName[1] = "Unknown Leather 2";
        leatherName[2] = "Unknown Leather 3";
        leatherName[3] = "Unknown Leather 4";
        leatherName[4] = "Unknown Leather 5";
        leatherName[5] = "Unknown Leather 6";
        leatherName[6] = "Unknown Leather 7";
        leatherName[7] = "Unknown Leather 8";
        leatherName[8] = "Unknown Leather 9";
        leatherName[9] = "Unknown Leather 10";
        // End Define leather types

        // Define gem types
        gemQty = new int[gemSize];
        gemName = new string[gemSize];

        for (int i = 0; i < gemSize; i++)
        {
            gemQty[i] = 0;
        }

        gemName[0] = "Unknown Gem 1";
        gemName[1] = "Unknown Gem 2";
        gemName[2] = "Unknown Gem 3";
        gemName[3] = "Unknown Gem 4";
        gemName[4] = "Unknown Gem 5";
        gemName[5] = "Unknown Gem 6";
        gemName[6] = "Unknown Gem 7";
        gemName[7] = "Unknown Gem 8";
        gemName[8] = "Unknown Gem 9";
        gemName[9] = "Unknown Gem 10";
        // End Define gem types

        // Define gemstone types
        gemstoneQty = new int[gemstoneSize];
        gemstoneName = new string[gemstoneSize];

        for (int i = 0; i < gemstoneSize; i++)
        {
            gemstoneQty[i] = 0;
        }

        gemstoneName[0] = "Unknown Gemstone 1";
        gemstoneName[1] = "Unknown Gemstone 2";
        gemstoneName[2] = "Unknown Gemstone 3";
        gemstoneName[3] = "Unknown Gemstone 4";
        gemstoneName[4] = "Unknown Gemstone 5";
        gemstoneName[5] = "Unknown Gemstone 6";
        gemstoneName[6] = "Unknown Gemstone 7";
        gemstoneName[7] = "Unknown Gemstone 8";
        gemstoneName[8] = "Unknown Gemstone 9";
        gemstoneName[9] = "Unknown Gemstone 10";
        // End Define gemstone types

        // Define wood types
        woodQty = new int[woodSize];
        woodName = new string[woodSize];

        for (int i = 0; i < woodSize; i++)
        {
            woodQty[i] = 0;
        }

        woodName[0] = "Unknown Wood 1";
        woodName[1] = "Unknown Wood 2";
        woodName[2] = "Unknown Wood 3";
        woodName[3] = "Unknown Wood 4";
        woodName[4] = "Unknown Wood 5";
        woodName[5] = "Unknown Wood 6";
        woodName[6] = "Unknown Wood 7";
        woodName[7] = "Unknown Wood 8";
        woodName[8] = "Unknown Wood 9";
        woodName[9] = "Unknown Wood 10";
        // End Define wood types

        // Define lumber types
        lumberQty = new int[lumberSize];
        lumberName = new string[lumberSize];

        for (int i = 0; i < lumberSize; i++)
        {
            lumberQty[i] = 0;
        }

        lumberName[0] = "Unknown Lumber 1";
        lumberName[1] = "Unknown Lumber 2";
        lumberName[2] = "Unknown Lumber 3";
        lumberName[3] = "Unknown Lumber 4";
        lumberName[4] = "Unknown Lumber 5";
        lumberName[5] = "Unknown Lumber 6";
        lumberName[6] = "Unknown Lumber 7";
        lumberName[7] = "Unknown Lumber 8";
        lumberName[8] = "Unknown Lumber 9";
        lumberName[9] = "Unknown Lumber 10";
        // End Define lumber types
        // End Define material types

        // Define component types: leatherStrap, leatherPadding, hilt, sheath, handle
        // Define leatherStrap types
        leatherStrapQty = new int[leatherStrapSize];
        leatherStrapName = new string[leatherStrapSize];

        for (int i = 0; i < leatherStrapSize; i++)
        {
            leatherStrapQty[i] = 0;
        }

        leatherStrapName[0] = "Unknown LeatherStrap 1";
        leatherStrapName[1] = "Unknown LeatherStrap 2";
        leatherStrapName[2] = "Unknown LeatherStrap 3";
        leatherStrapName[3] = "Unknown LeatherStrap 4";
        leatherStrapName[4] = "Unknown LeatherStrap 5";

        // Define leatherPadding types
        leatherPaddingQty = new int[leatherPaddingSize];
        leatherPaddingName = new string[leatherPaddingSize];

        for (int i = 0; i < leatherPaddingSize; i++)
        {
            leatherPaddingQty[i] = 0;
        }

        leatherPaddingName[0] = "Unknown LeatherPadding 1";
        leatherPaddingName[1] = "Unknown LeatherPadding 2";
        leatherPaddingName[2] = "Unknown LeatherPadding 3";
        leatherPaddingName[3] = "Unknown LeatherPadding 4";
        leatherPaddingName[4] = "Unknown LeatherPadding 5";
        // End Define leatherPadding types

        // Define hilt types
        hiltQty = new int[hiltSize];
        hiltName = new string[hiltSize];

        for (int i = 0; i < hiltSize; i++)
        {
            hiltQty[i] = 0;
        }

        hiltName[0] = "Unknown Hilt 1";
        hiltName[1] = "Unknown Hilt 2";
        hiltName[2] = "Unknown Hilt 3";
        hiltName[3] = "Unknown Hilt 4";
        hiltName[4] = "Unknown Hilt 5";
        // End Define hilt types

        // Define sheath types
        sheathQty = new int[sheathSize];
        sheathName = new string[sheathSize];

        for (int i = 0; i < sheathSize; i++)
        {
            sheathQty[i] = 0;
        }

        sheathName[0] = "Unknown Sheath 1";
        sheathName[1] = "Unknown Sheath 2";
        sheathName[2] = "Unknown Sheath 3";
        sheathName[3] = "Unknown Sheath 4";
        sheathName[4] = "Unknown Sheath 5";
        // End Define sheath types

        // Define handle types
        handleQty = new int[handleSize];
        handleName = new string[handleSize];

        for (int i = 0; i < handleSize; i++)
        {
            handleQty[i] = 0;
        }

        handleName[0] = "Unknown Handle 1";
        handleName[1] = "Unknown Handle 2";
        handleName[2] = "Unknown Handle 3";
        handleName[3] = "Unknown Handle 4";
        handleName[4] = "Unknown Handle 5";
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
