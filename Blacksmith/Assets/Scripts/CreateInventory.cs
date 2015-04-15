using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CreateInventory : MonoBehaviour {

    public GameObject background;

    public Text textBox1;
    public Text textBox2;
    public Text testText;

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

    //private int[] axe;
    //private int[] mace;
    //private int[] flail;
    //private int[] hammer;

    // Weapon & shield declarations
    private int[] swordQty;
    private string[] swordName;
    private const int swordSize = 10;
    private SortedInventory swords;

    private int[] shieldQty;
    private string[] shieldName;
    private const int shieldSize = 10;
    private SortedInventory shields;

    // Armor declarations
    private int[] breastplateQty;
    private string[] breastplateName;
    private const int breastPlateSize = 10;
    private SortedInventory breastplates;

    private int[] helmQty;
    private string[] helmName;
    private const int helmSize = 10;
    private SortedInventory helms;

    private int[] bracersQty;
    private string[] bracersName;
    private const int bracersSize = 10;
    private SortedInventory bracers;

    private int[] gauntletsQty;
    private string[] gauntletsName;
    private const int gauntletsSize = 10;
    private SortedInventory gauntlets;

    private int[] bootsQty;
    private string[] bootsName;
    private const int bootsSize = 10;
    private SortedInventory boots;

    private int[] greavesQty;
    private string[] greavesName;
    private const int greavesSize = 10;
    private SortedInventory greaves;

    private int[] pauldronsQty;
    private string[] pauldronsName;
    private const int pauldronsSize = 10;
    private SortedInventory pauldrons;
    
    


    



	// Use this for initialization
	void Start ()
    {
        testStrings = new string[30];
        testStrings[0] = "Iron Ore";
        testStrings[1] = "Copper Ore";
        testStrings[2] = "Bronze Alloy";
        testStrings[3] = "Brass Alloy";
        testStrings[4] = "Iron Ore";
        testStrings[5] = "Blackened Iron Alloy";
        testStrings[6] = "Steel Alloy";
        testStrings[7] = "Hardened Steel Alloy";
        testStrings[8] = "Silver Ore";
        testStrings[9] = "Dragon Bone";
        testStrings[10] = "Iron Ore";
        testStrings[11] = "Copper Ore";
        testStrings[12] = "Bronze Alloy";
        testStrings[13] = "Brass Alloy";
        testStrings[14] = "Iron Ore";
        testStrings[15] = "Blackened Iron Alloy";
        testStrings[16] = "Steel Alloy";
        testStrings[17] = "Hardened Steel Alloy";
        testStrings[18] = "Silver Ore";
        testStrings[19] = "Dragon Bone";
        testStrings[20] = "Iron Ore";
        testStrings[21] = "Copper Ore";
        testStrings[22] = "Bronze Alloy";
        testStrings[23] = "Brass Alloy";
        testStrings[24] = "Iron Ore";
        testStrings[25] = "Blackened Iron Alloy";
        testStrings[26] = "Steel Alloy";
        testStrings[27] = "Hardened Steel Alloy";
        testStrings[28] = "Silver Ore";
        testStrings[29] = "Dragon Bone";

        testInts = new int[30];
        testInts[0] = 5;
        testInts[1] = 15;
        testInts[2] = 25;
        testInts[3] = 35;
        testInts[4] = 45;
        testInts[5] = 55;
        testInts[6] = 65;
        testInts[7] = 75;
        testInts[8] = 85;
        testInts[9] = 95;
        testInts[10] = 5;
        testInts[11] = 15;
        testInts[12] = 25;
        testInts[13] = 35;
        testInts[14] = 45;
        testInts[15] = 55;
        testInts[16] = 65;
        testInts[17] = 75;
        testInts[18] = 85;
        testInts[19] = 95;
        testInts[20] = 5;
        testInts[21] = 15;
        testInts[22] = 25;
        testInts[23] = 35;
        testInts[24] = 45;
        testInts[25] = 55;
        testInts[26] = 65;
        testInts[27] = 75;
        testInts[28] = 85;
        testInts[29] = 95;

        //Define sword types and start quantities.
        swordQty = new int[swordSize];
        swordName = new string[swordSize];

        for (int i = 0; i < swordSize; i++)
        {
            swordQty[i] = 0;
        }

        swordName[0] = "Tin Sword";
        swordName[1] = "Copper Sword";
        swordName[2] = "Bronze Sword";
        swordName[3] = "Brass Sword";
        swordName[4] = "Iron Sword";
        swordName[5] = "BlackenedIron Sword";
        swordName[6] = "Steel Sword";
        swordName[7] = "SteelAlloyL1 Sword";
        swordName[8] = "SteelAlloyL2 Sword";
        swordName[9] = "Titanium Sword";
        //End Define sword

        // Define material types
        // fuel, ore, ingot, skin, leather, gem, gemstone, wood, lumber

        // Define fuel types
        fuelQty = new int[fuelSize];
        fuelName = new string[fuelSize];

        for (int i = 0; i < fuelSize; i++)
        {
            fuelQty[i] = 0;
        }

        fuelName[0] = "Basic Fuel";
        fuelName[0] = "Standard Fuel";
        fuelName[0] = "Good Fuel";
        fuelName[0] = "Excellent Fuel";
        fuelName[0] = "Expert Fuel";
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



        inventoryScrollbar.value = 1;

        SetQuantitiesTestMethod();
	}

    void SetQuantitiesTestMethod()
    {
        for (int i = 0; i < 5; i++)
        {
            oreQty[i] = Random.Range(1, 9);
            ingotQty[i] = Random.Range(1, 9);
            skinQty[i] = Random.Range(1, 9);
            leatherQty[i] = Random.Range(1, 9);
            gemQty[i] = Random.Range(1, 9);
            gemstoneQty[i] = Random.Range(1, 9);
            woodQty[i] = Random.Range(1, 9);
            lumberQty[i] = Random.Range(1, 9);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        
	}

    public void SetBackground()
    {

        for (int i = 0; i < totalItems; i++)
        {
            tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
            tempLine.transform.SetParent(background.transform);
            tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText1.transform.SetParent(tempLine.transform);
            tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText1.text = testStrings[i];
            tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText2.transform.SetParent(tempText1.transform);
            tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText2.text = "" + testInts[i];
        }

    }

    public void ResetScrollbar()
    {
        inventoryScrollbar.value = 1;
    }

    // Calls all updates to update the current on hand inventory.
    void BuildInventory()
    {
        UpdateWeaponList();
        UpdateArmorList();
        UpdateMaterialList();
        UpdateComponentList();
        UpdateMiscList();
    }

    // Creates the list displaying all the weapons in inventory.
    public void UpdateWeaponList()
    {
        // Generate sword list
        for (int i = 0; i < swordSize; i++)
        {
            if (swordQty[i] > 0)
            {
                tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
                tempLine.transform.SetParent(background.transform);
                tempText1 = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText1.transform.SetParent(tempLine.transform);
                tempText1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText1.text = swordName[i];
                tempText2 = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
                tempText2.transform.SetParent(tempText1.transform);
                tempText2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                tempText2.text = "" + swordQty[i];
            }
        }
    }

    // Creates a list displaying all the armor in inventory.
    void UpdateArmorList()
    {

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
                tempLine.transform.SetParent(background.transform);
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
                tempLine.transform.SetParent(background.transform);
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
                tempLine.transform.SetParent(background.transform);
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
                tempLine.transform.SetParent(background.transform);
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
                tempLine.transform.SetParent(background.transform);
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
                tempLine.transform.SetParent(background.transform);
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
                tempLine.transform.SetParent(background.transform);
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
                tempLine.transform.SetParent(background.transform);
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
                tempLine.transform.SetParent(background.transform);
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
    void UpdateComponentList()
    {

    }

    // Creates a list displaying all the miscellaneous items in inventory.
    void UpdateMiscList()
    {

    }

    // Take an item object and add it to the on hand inventory.
    void AddNewItem()
    {

    }
}

public class SortedInventory
{
    private int inventorySize = 10;
    private GameObject[] storedItems;
    private SortedInventory()
    {
        storedItems = new GameObject[inventorySize];
    }

    private void increaseSize()
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

    private void decreaseSize()
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

    public bool addItem(GameObject item)
    {
        if (storedItems.Length >= (inventorySize/2))
        {
            increaseSize();
        }
        string material = item.GetComponent<ItemScript>().getMaterial();

        for(int i = 0; i < storedItems.Length; i++)
        {
            if ((int)Enum.Parse(typeof(Material), material) > (int)Enum.Parse(typeof(Material), storedItems[i].GetComponent<ItemScript>().getMaterial()))
            {
                continue;
            }
            /*else if ((int)Enum.Parse(typeof(Material), material) < (int)Enum.Parse(typeof(Material), storedItems[i].GetComponent<ItemScript>.getMaterial()))
            {
                insertItem(item, i - 1);
            }*/
            else
            {
                insertItem(item, i);
                return true;
            }
        }

        return false;
    }

    public bool removeItem(GameObject item)
    {
        int count = 0;
        foreach(GameObject listItem in storedItems)
        {
            if (listItem == item)
            {
                if (count == storedItems.Length)
                {
                    storedItems[count] = storedItems[count + 1];
                }
                else
                {
                    for (int i = count; i < (storedItems.Length - 1); i++)
                    {
                        storedItems[i] = storedItems[i + 1];
                    }
                    storedItems[storedItems.Length] = storedItems[storedItems.Length + 1];
                }
                if ((inventorySize / 2)  > storedItems.Length)
                {
                    if (inventorySize > 10)
                    {
                        decreaseSize();
                    }
                }
                return true;
            }
            count++;
        }
        return false;
    }

    private void insertItem(GameObject item, int insertionPoint)
    {
        for(int i = (storedItems.Length-1); i >= insertionPoint; i--)
        {
            storedItems[i + 1] = storedItems[i];
        }
        storedItems[insertionPoint] = item;
    }

<<<<<<< HEAD:Blacksmith/Assets/Scripts/Routines/CreateInventory.cs


=======
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
>>>>>>> origin/master:Blacksmith/Assets/Scripts/CreateInventory.cs
}
