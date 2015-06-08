using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CreateInventory : MonoBehaviour 
{

    public GameObject weaponBackground;
    public GameObject armorBackground;
    public GameObject materialBackground;
    public GameObject componentBackground;
    public GameObject miscBackground;
    public GameObject inventoryWindow;

    public GameObject itemLine;

    public Text textBox1;
    public Text textBox2;

    private Text tempText1;
    private Text tempText2;

    public Canvas inventoryCanvas;
    public GameObject singleLine;
    public GameObject tempObj;

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
    public SortedInventory swords = new SortedInventory();
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
        oreCost[1] = 150;
        oreCost[2] = 300;
        oreCost[3] = 500;
        oreCost[4] = 700;
        oreCost[5] = 1000;
        oreCost[6] = 1200;
        oreCost[7] = 1400;
        oreCost[8] = 1600;
        oreCost[9] = 2000;

        oreName[0] = "Tin Ore";
        oreName[1] = "Copper Ore";
        oreName[2] = "Zinc Ore";
        oreName[3] = "Iron Ore";
        oreName[4] = "Charcoal";
        oreName[5] = "Chromium Ore";
        oreName[6] = "Manganese Ore";
        oreName[7] = "Cobalt Ore";
        oreName[8] = "Tungsten Ore";
        oreName[9] = "Titanium Ore";
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
        ingotCost[1] = 300;
        ingotCost[2] = 600;
        ingotCost[3] = 1000;
        ingotCost[4] = 1400;
        ingotCost[5] = 2000;
        ingotCost[6] = 2400;
        ingotCost[7] = 2800;
        ingotCost[8] = 3200;
        ingotCost[9] = 4000;
        

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

        skinCost[0] = 30;
        skinCost[1] = 100;
        skinCost[2] = 250;
        skinCost[3] = 400;
        skinCost[4] = 600;
        skinCost[5] = 800;
        skinCost[6] = 1000;
        skinCost[7] = 1200;
        skinCost[8] = 1400;
        skinCost[9] = 1600;


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

        leatherCost[0] = 60;
        leatherCost[1] = 200;
        leatherCost[2] = 500;
        leatherCost[3] = 800;
        leatherCost[4] = 1200;
        leatherCost[5] = 1600;
        leatherCost[6] = 2000;
        leatherCost[7] = 2400;
        leatherCost[8] = 2800;
        leatherCost[9] = 3200;

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

        woodCost[0] = 40;
        woodCost[1] = 80;
        woodCost[2] = 200;
        woodCost[3] = 350;
        woodCost[4] = 500;
        woodCost[5] = 700;
        woodCost[6] = 900;
        woodCost[7] = 1100;
        woodCost[8] = 1300;
        woodCost[9] = 1500;

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

        lumberCost[0] = 80;
        lumberCost[1] = 160;
        lumberCost[2] = 400;
        lumberCost[3] = 700;
        lumberCost[4] = 1000;
        lumberCost[5] = 1400;
        lumberCost[6] = 1800;
        lumberCost[7] = 2200;
        lumberCost[8] = 2600;
        lumberCost[9] = 3000;

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

        leatherStrapCost[0] = 5;
        leatherStrapCost[1] = 25;
        leatherStrapCost[2] = 100;
        leatherStrapCost[3] = 300;
        leatherStrapCost[4] = 500;

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

        leatherPaddingCost[0] = 5;
        leatherPaddingCost[1] = 25;
        leatherPaddingCost[2] = 100;
        leatherPaddingCost[3] = 300;
        leatherPaddingCost[4] = 500;

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

        hiltCost[0] = 3;
        hiltCost[1] = 30;
        hiltCost[2] = 75;
        hiltCost[3] = 150;
        hiltCost[4] = 300;

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

        sheathCost[0] = 2;
        sheathCost[1] = 20;
        sheathCost[2] = 60;
        sheathCost[3] = 125;
        sheathCost[4] = 250;

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

        handleCost[0] = 4;
        handleCost[1] = 40;
        handleCost[2] = 90;
        handleCost[3] = 200;
        handleCost[4] = 400;

        handleName[0] = "Basic Handle";
        handleName[1] = "Standard Handle";
        handleName[2] = "Good Handle";
        handleName[3] = "Excellent Handle";
        handleName[4] = "Expert Handle";
        // End Define handle types

        //SetQuantitiesTestMethod();
        giveStartMaterials();
	}

    // TEST METHOD FOR ADDING IN A RANDOM AMOUNT OF ITEMS.
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

    void giveStartMaterials()
    {
        ingotQty[0]++;
        sheathQty[0]++;
        hiltQty[0]++;
        //oreQty[0] = 5;
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
        totalItems = 0;

        for (int i = 0; i < swords.GetCurrentSize(); i++)
        {
            addInventoryLine(swords.GetItem(i).GetComponent<ItemScript>().GetItemDescription(), 0, weaponBackground);
            totalItems++;
        }

        for (int i = totalItems; i < 19; i++)
        {
            addInventoryLine("", 0, weaponBackground, true);
        }
    }

    // Creates a list displaying all the armor/shields in inventory.
    void UpdateArmorList()
    {
        for (int i = 0; i < shields.GetCurrentSize(); i++)
        {
            addInventoryLine(shields.GetItem(i).GetComponent<ItemScript>().GetItemDescription(), 0, armorBackground);
            totalItems++;
        }

        for (int i = 0; i < breastplates.GetCurrentSize(); i++)
        {
            addInventoryLine(breastplates.GetItem(i).GetComponent<ItemScript>().GetItemDescription(), 0, armorBackground);
            totalItems++;
        }

        for (int i = 0; i < helms.GetCurrentSize(); i++)
        {
            addInventoryLine(helms.GetItem(i).GetComponent<ItemScript>().GetItemDescription(), 0, armorBackground);
            totalItems++;
        }

        for (int i = 0; i < bracers.GetCurrentSize(); i++)
        {
            addInventoryLine(bracers.GetItem(i).GetComponent<ItemScript>().GetItemDescription(), 0, armorBackground);
            totalItems++;
        }

        for (int i = 0; i < gauntlets.GetCurrentSize(); i++)
        {
            addInventoryLine(gauntlets.GetItem(i).GetComponent<ItemScript>().GetItemDescription(), 0, armorBackground);
            totalItems++;
        }

        for (int i = 0; i < boots.GetCurrentSize(); i++)
        {
            addInventoryLine(boots.GetItem(i).GetComponent<ItemScript>().GetItemDescription(), 0, armorBackground);
            totalItems++;
        }

        for (int i = 0; i < greaves.GetCurrentSize(); i++)
        {
            addInventoryLine(greaves.GetItem(i).GetComponent<ItemScript>().GetItemDescription(), 0, armorBackground);
            totalItems++;
        }

        for (int i = 0; i < pauldrons.GetCurrentSize(); i++)
        {
            addInventoryLine(pauldrons.GetItem(i).GetComponent<ItemScript>().GetItemDescription(), 0, armorBackground);
            totalItems++;
        }
    }

    // Creates a list displaying all the materials in inventory.
    public void UpdateMaterialList()
    {
        totalItems = 0;
        // fuel, ore, ingot, skin, leather, gem, gemstone, wood, lumber

        // Generate fuel list
        for (int i = 0; i < fuelSize; i++)
        {
            if (fuelQty[i] > 0)
            {
                addInventoryLine(fuelName[i], fuelQty[i], materialBackground, false);
                totalItems++;
            }
        }
        
        // Generate ore list
        for (int i = 0; i < oreSize; i++)
        {
            if (oreQty[i] > 0)
            {
                addInventoryLine(oreName[i], oreQty[i], materialBackground, false);
                totalItems++;
            }
        }

        // Generate ingot list
        for (int i = 0; i < ingotSize; i++)
        {
            if (ingotQty[i] > 0)
            {
                addInventoryLine(ingotName[i], ingotQty[i], materialBackground, false);
                totalItems++;
            }
        }

        // Generate skin list
        for (int i = 0; i < skinSize; i++)
        {
            if (skinQty[i] > 0)
            {
                addInventoryLine(skinName[i], skinQty[i], materialBackground, false);
                totalItems++;
            }
        }

        // Generate leather list
        for (int i = 0; i < leatherSize; i++)
        {
            if (leatherQty[i] > 0)
            {
                addInventoryLine(leatherName[i], leatherQty[i], materialBackground, false);
                totalItems++;
            }
        }

        // Generate gem list
        for (int i = 0; i < gemSize; i++)
        {
            if (gemQty[i] > 0)
            {
                addInventoryLine(gemName[i], gemQty[i], materialBackground, false);
                totalItems++;
            }
        }
        
        // Generate gemstone list
        for (int i = 0; i < gemstoneSize; i++)
        {
            if (gemstoneQty[i] > 0)
            {
                addInventoryLine(gemstoneName[i], gemstoneQty[i], materialBackground, false);
                totalItems++;
            }
        }

        // Generate wood list
        for (int i = 0; i < woodSize; i++)
        {
            if (woodQty[i] > 0)
            {
                addInventoryLine(woodName[i], woodQty[i], materialBackground, false);
                totalItems++;
            }
        }

        // Generate lumber list
        for (int i = 0; i < lumberSize; i++)
        {
            if (lumberQty[i] > 0)
            {
                addInventoryLine(lumberName[i], lumberQty[i], materialBackground, false);
                totalItems++;
            }
        }

        if (totalItems == 0)
        {
            addInventoryLine("You have no materials", 0, materialBackground, true);
            totalItems++;
        }

        for (int i = totalItems; i < 19; i++)
        {
            addInventoryLine("", 0, materialBackground, true);
        }
    }

    // Creates a list displaying all the components in inventory.
    public void UpdateComponentList()
    {
        totalItems = 0;
        // leatherStrap, leatherPadding, hilt, sheath, handle

        // Generate leatherStrap list
        for (int i = 0; i < leatherStrapSize; i++)
        {
            if (leatherStrapQty[i] > 0)
            {
                addInventoryLine(leatherStrapName[i], leatherStrapQty[i], componentBackground, false);
                totalItems++;
            }
        }

        // Generate leatherPadding list
        for (int i = 0; i < leatherPaddingSize; i++)
        {
            if (leatherPaddingQty[i] > 0)
            {
                addInventoryLine(leatherPaddingName[i], leatherPaddingQty[i], componentBackground, false);
                totalItems++;
            }
        }

        // Generate hilt list
        for (int i = 0; i < hiltSize; i++)
        {
            if (hiltQty[i] > 0)
            {
                addInventoryLine(hiltName[i], hiltQty[i], componentBackground, false);
                totalItems++;
            }
        }

        // Generate sheath list
        for (int i = 0; i < sheathSize; i++)
        {
            if (sheathQty[i] > 0)
            {
                addInventoryLine(sheathName[i], sheathQty[i], componentBackground, false);
                totalItems++;
            }
        }

        // Generate handle list
        for (int i = 0; i < handleSize; i++)
        {
            if (handleQty[i] > 0)
            {
                addInventoryLine(handleName[i], handleQty[i], componentBackground, false);
                totalItems++;
            }
        }

        if (totalItems == 0)
        {
            addInventoryLine("You have no components", 0, componentBackground, true);
            totalItems++;
        }

        for (int i = totalItems; i < 19; i++)
        {
            addInventoryLine("", 0, componentBackground, true);
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

        resetScrollbarValue();
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

        resetScrollbarValue();
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

        resetScrollbarValue();
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

        resetScrollbarValue();
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

        resetScrollbarValue();
    }

    // Take an item object and add it to the on hand inventory.
    public void addCraftedItem(GameObject newItem)
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

    public void deleteCraftedItem(GameObject item)
    {
        switch (item.GetComponent<ItemScript>().GetItem())
        {
            case "Sword":
                swords.RemoveItem(item);
                break;
            default:
                Debug.Log("Crafted item not found on delete");
                break;
        }

        //Debug.Log("Destroying " + item.name);
        DestroyImmediate(item);

        BuildInventory();
    }

    public void removeCraftedItem(GameObject item)
    {
        switch (item.GetComponent<ItemScript>().GetItem())
        {
            case "Sword":
                swords.RemoveItem(item);
                break;
            default:
                Debug.Log("Crafted item not found on remove");
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

    public int getQuantity(string item)
    {
        switch (item)
        {
            case "Tin Ore":
                return oreQty[0];
            case "Copper Ore":
                return oreQty[1];
            case "Zinc Ore":
                return oreQty[2];
            case "Iron Ore":
                return oreQty[3];
            case "Charcoal":
                return oreQty[4];
            case "Chromium Ore":
                return oreQty[5];
            case "Manganese Ore":
                return oreQty[6];
            case "Cobalt Ore":
                return oreQty[7];
            case "Tungsten Ore":
                return oreQty[8];
            case "Titanium Ore":
                return oreQty[9];
            case "Tin Ingot":
                return ingotQty[0];
            case "Copper Ingot":
                return ingotQty[1];
            case "Bronze Ingot":
                return ingotQty[2];
            case "Brass Ingot":
                return ingotQty[3];
            case "Iron Ingot":
                return ingotQty[4];
            case "Blackened Iron Ingot":
                return ingotQty[5];
            case "Steel Ingot":
                return ingotQty[6];
            case "Low Grade Steel Alloy Ingot":
                return ingotQty[7];
            case "High Grade Steel Alloy Ingot":
                return ingotQty[8];
            case "Titanium Ingot":
                return ingotQty[9];
            case "Basic Sheath":
                return sheathQty[0];
            case "Standard Sheath":
                return sheathQty[1];
            case "Good Sheath":
                return sheathQty[2];
            case "Excellent Sheath":
                return sheathQty[3];
            case "Expert Sheath":
                return sheathQty[4];
            case "Basic Hilt":
                return hiltQty[0];
            case "Standard Hilt":
                return hiltQty[1];
            case "Good Hilt":
                return hiltQty[2];
            case "Excellent Hilt":
                return hiltQty[3];
            case "Expert Hilt":
                return hiltQty[4];
            default:
                Debug.Log("Item parse not found");
                return 0;
        }

        //Debug.Log("Item parse not found");
        //return 0;
    }

    public void addItem(string itemName, int quantity)
    {
        switch (itemName)
        {
            case "Tin Ore":
                oreQty[0] += quantity;
                break;
            case "Copper Ore":
                oreQty[1] += quantity;
                break;
            case "Zinc Ore":
                oreQty[2] += quantity;
                break;
            case "Iron Ore":
                oreQty[3] += quantity;
                break;
            case "Carbon":
                oreQty[4] += quantity;
                break;
            case "Chromium Ore":
                oreQty[5] += quantity;
                break;
            case "Manganese Ore":
                oreQty[6] += quantity;
                break;
            case "Cobalt Ore":
                oreQty[7] += quantity;
                break;
            case "Tungsten Ore":
                oreQty[8] += quantity;
                break;
            case "Titanium Ore":
                oreQty[9] += quantity;
                break;
            case "Tin Ingot":
                ingotQty[0] += quantity;
                break;
            case "Copper Ingot":
                ingotQty[1] += quantity;
                break;
            case "Bronze Ingot":
                ingotQty[2] += quantity;
                break;
            case "Brass Ingot":
                ingotQty[3] += quantity;
                break;
            case "Iron Ingot":
                ingotQty[4] += quantity;
                break;
            case "Blackened Iron Ingot":
                ingotQty[5] += quantity;
                break;
            case "Steel Ingot":
                ingotQty[6] += quantity;
                break;
            case "Low Grade Steel Alloy Ingot":
                ingotQty[7] += quantity;
                break;
            case "High Grade Steel Alloy Ingot":
                ingotQty[8] += quantity;
                break;
            case "Titanium Ingot":
                ingotQty[9] += quantity;
                break;
            case "Sheep Skin":
                skinQty[0] += quantity;
                break;
            case "Goat Skin":
                skinQty[1] += quantity;
                break;
            case "Buffalo Skin":
                skinQty[2] += quantity;
                break;
            case "Dodo Skin":
                skinQty[3] += quantity;
                break;
            case "Serpent Skin":
                skinQty[4] += quantity;
                break;
            case "Wolf Skin":
                skinQty[5] += quantity;
                break;
            case "Ogre Skin":
                skinQty[6] += quantity;
                break;
            case "Troll Skin":
                skinQty[7] += quantity;
                break;
            case "Wyvern Skin":
                skinQty[8] += quantity;
                break;
            case "Dragon Skin":
                skinQty[9] += quantity;
                break;
            case "Rough Malachite":
                gemQty[0] += quantity;
                break;
            case "Rough Lapis Lazuli":
                gemQty[1] += quantity;
                break;
            case "Rough Turquoise":
                gemQty[2] += quantity;                
                break;
            case "Rough Coral":
                gemQty[3] += quantity;
                break;
            case "Rough Agate":
                gemQty[4] += quantity;
                break;
            case "Rough Jasper":
                gemQty[5] += quantity;
                break;
            case "Rough Opal":
                gemQty[6] += quantity;
                break;
            case "Rough Ruby":
                gemQty[7] += quantity;
                break;
            case "Rough Pearl":
                gemQty[8] += quantity;
                break;
            case "Rough Moonstone":
                gemQty[9] += quantity;
                break;
            case "Raw Elm":
                woodQty[0] += quantity;
                break;
            case "Raw Alder":
                woodQty[1] += quantity;
                break;
            case "Raw Maple":
                woodQty[2] += quantity;
                break;
            case "Raw Sandlewood":
                woodQty[3] += quantity;
                break;
            case "Raw Ash":
                woodQty[4] += quantity;
                break;
            case "Raw Fir":
                woodQty[5] += quantity;
                break;
            case "Raw Cedar":
                woodQty[6] += quantity;
                break;
            case "Raw Ironwood":
                woodQty[7] += quantity;
                break;
            case "Raw Rosewood":
                woodQty[8] += quantity;
                break;
            case "Raw Ebony":
                woodQty[9] += quantity;
                break;
            case "Basic Leather Strap":
                leatherStrapQty[0] += quantity;
                break;
            case "Standard Leather Strap":
                leatherStrapQty[1] += quantity;
                break;
            case "Good Leather Strap":
                leatherStrapQty[2] += quantity;
                break;
            case "Excellent Leather Strap":
                leatherStrapQty[3] += quantity;
                break;
            case "Expert Leather Strap":
                leatherStrapQty[4] += quantity;
                break;
            case "Basic Leather Padding":
                leatherPaddingQty[0] += quantity;
                break;
            case "Standard Leather Padding":
                leatherPaddingQty[1] += quantity;
                break;
            case "Good Leather Padding":
                leatherPaddingQty[2] += quantity;
                break;
            case "Excellent Leather Padding":
                leatherPaddingQty[3] += quantity;
                break;
            case "Expert Leather Padding":
                leatherPaddingQty[4] += quantity;
                break;
            case "Basic Hilt":
                hiltQty[0] += quantity;
                break;
            case "Standard Hilt":
                hiltQty[1] += quantity;
                break;
            case "Good Hilt":
                hiltQty[2] += quantity;
                break;
            case "Excellent Hilt":
                hiltQty[3] += quantity;
                break;
            case "Expert Hilt":
                hiltQty[4] += quantity;
                break;
            case "Basic Sheath":
                sheathQty[0] += quantity;
                break;
            case "Standard Sheath":
                sheathQty[1] += quantity;
                break;
            case "Good Sheath":
                sheathQty[2] += quantity;
                break;
            case "Excellent Sheath":
                sheathQty[3] += quantity;
                break;
            case "Expert Sheath":
                sheathQty[4] += quantity;
                break;
            case "Basic Handle":
                handleQty[0] += quantity;
                break;
            case "Standard Handle":
                handleQty[1] += quantity;
                break;
            case "Good Handle":
                handleQty[2] += quantity;
                break;
            case "Excellent Handle":
                handleQty[3] += quantity;
                break;
            case "Expert Handle":
                handleQty[4] += quantity;
                break;
            default:
                Debug.Log("Merchant item not found");
                break;
        }

        //Debug.Log("Added " + itemName + " of quantity: " + quantity + " to inventory");

        BuildInventory();
    }

    public void removeItem(string itemName, int quantity)
    {
        //Debug.Log(itemName + " " + quantity);
        switch (itemName)
        {
            case "Basic Fuel":
                fuelQty[0] -= quantity;
                break;
            case "Standard Fuel":
                fuelQty[1] -= quantity;
                break;
            case "Good Fuel":
                fuelQty[2] -= quantity;
                break;
            case "Excellent Fuel":
                fuelQty[3] -= quantity;
                break;
            case "Expert Fuel":
                fuelQty[4] -= quantity;
                break;
            case "Tin Ore":
                oreQty[0] -= quantity;
                break;
            case "Copper Ore":
                oreQty[1] -= quantity;
                break;
            case "Zinc Ore":
                oreQty[2] -= quantity;
                break;
            case "Iron Ore":
                oreQty[3] -= quantity;
                break;
            case "Black Ore":
                oreQty[4] -= quantity;
                break;
            case "Nickel Ore":
                oreQty[5] -= quantity;
                break;
            case "Carbon Ore":
                oreQty[6] -= quantity;
                break;
            case "Manganese Ore":
                oreQty[7] -= quantity;
                break;
            case "Chromium Ore":
                oreQty[8] -= quantity;
                break;
            case "Dragon Ore":
                oreQty[9] -= quantity;
                break;
            case "Tin Ingot":
                ingotQty[0] -= quantity;
                break;
            case "Copper Ingot":
                ingotQty[1] -= quantity;
                break;
            case "Bronze Ingot":
                ingotQty[2] -= quantity;
                break;
            case "Brass Ingot":
                ingotQty[3] -= quantity;
                break;
            case "Iron Ingot":
                ingotQty[4] -= quantity;
                break;
            case "Blackened Iron Ingot":
                ingotQty[5] -= quantity;
                break;
            case "Steel Ingot":
                ingotQty[6] -= quantity;
                break;
            case "Low Grade Steel Alloy Ingot":
                ingotQty[7] -= quantity;
                break;
            case "High Grade Steel Alloy Ingot":
                ingotQty[8] -= quantity;
                break;
            case "Titanium Ingot":
                ingotQty[9] -= quantity;
                break;
            case "Sheep Skin":
                skinQty[0] -= quantity;
                break;
            case "Goat Skin":
                skinQty[1] -= quantity;
                break;
            case "Buffalo Skin":
                skinQty[2] -= quantity;
                break;
            case "Dodo Skin":
                skinQty[3] -= quantity;
                break;
            case "Serpent Skin":
                skinQty[4] -= quantity;
                break;
            case "Wolf Skin":
                skinQty[5] -= quantity;
                break;
            case "Ogre Skin":
                skinQty[6] -= quantity;
                break;
            case "Troll Skin":
                skinQty[7] -= quantity;
                break;
            case "Wyvern Skin":
                skinQty[8] -= quantity;
                break;
            case "Dragon Skin":
                skinQty[9] -= quantity;
                break;
            case "Sheep Leather":
                leatherQty[0] -= quantity;
                break;
            case "Goat Leather":
                leatherQty[1] -= quantity;
                break;
            case "Buffalo Leather":
                leatherQty[2] -= quantity;
                break;
            case "Dodo Leather":
                leatherQty[3] -= quantity;
                break;
            case "Serpent Leather":
                leatherQty[4] -= quantity;
                break;
            case "Wolf Leather":
                leatherQty[5] -= quantity;
                break;
            case "Ogre Leather":
                leatherQty[6] -= quantity;
                break;
            case "Troll Leather":
                leatherQty[7] -= quantity;
                break;
            case "Wyvern Leather":
                leatherQty[8] -= quantity;
                break;
            case "Dragon Leather":
                leatherQty[9] -= quantity;
                break;
            case "Rough Malachite":
                gemQty[0] -= quantity;
                break;
            case "Rough Lapis Lazuli":
                gemQty[1] -= quantity;
                break;
            case "Rough Turquoise":
                gemQty[2] -= quantity;
                break;
            case "Rough Coral":
                gemQty[3] -= quantity;
                break;
            case "Rough Agate":
                gemQty[4] -= quantity;
                break;
            case "Rough Jasper":
                gemQty[5] -= quantity;
                break;
            case "Rough Opal":
                gemQty[6] -= quantity;
                break;
            case "Rough Ruby":
                gemQty[7] -= quantity;
                break;
            case "Rough Pearl":
                gemQty[8] -= quantity;
                break;
            case "Rough Moonstone":
                gemQty[9] -= quantity;
                break;
            case "Polished Malachite":
                gemstoneQty[0] -= quantity;
                break;
            case "Polished Lapis Lazuli":
                gemstoneQty[1] -= quantity;
                break;
            case "Polished Turquoise":
                gemstoneQty[2] -= quantity;
                break;
            case "Polished Coral":
                gemstoneQty[3] -= quantity;
                break;
            case "Polished Agate":
                gemstoneQty[4] -= quantity;
                break;
            case "Polished Jasper":
                gemstoneQty[5] -= quantity;
                break;
            case "Polished Opal":
                gemstoneQty[6] -= quantity;
                break;
            case "Polished Ruby":
                gemstoneQty[7] -= quantity;
                break;
            case "Polished Pearl":
                gemstoneQty[8] -= quantity;
                break;
            case "Polished Moonstone":
                gemstoneQty[9] -= quantity;
                break;
            case "Raw Elm":
                woodQty[0] -= quantity;
                break;
            case "Raw Alder":
                woodQty[1] -= quantity;
                break;
            case "Raw Maple":
                woodQty[2] -= quantity;
                break;
            case "Raw Sandlewood":
                woodQty[3] -= quantity;
                break;
            case "Raw Ash":
                woodQty[4] -= quantity;
                break;
            case "Raw Fir":
                woodQty[5] -= quantity;
                break;
            case "Raw Cedar":
                woodQty[6] -= quantity;
                break;
            case "Raw Ironwood":
                woodQty[7] -= quantity;
                break;
            case "Raw Rosewood":
                woodQty[8] -= quantity;
                break;
            case "Raw Ebony":
                woodQty[9] -= quantity;
                break;
            case "Elm Lumber":
                lumberQty[0] -= quantity;
                break;
            case "Alder Lumber":
                lumberQty[1] -= quantity;
                break;
            case "Maple Lumber":
                lumberQty[2] -= quantity;
                break;
            case "Sandlewood Lumber":
                lumberQty[3] -= quantity;
                break;
            case "Ash Lumber":
                lumberQty[4] -= quantity;
                break;
            case "Fir Lumber":
                lumberQty[5] -= quantity;
                break;
            case "Cedar Lumber":
                lumberQty[6] -= quantity;
                break;
            case "Ironwood Lumber":
                lumberQty[7] -= quantity;
                break;
            case "Rosewood Lumber":
                lumberQty[8] -= quantity;
                break;
            case "Ebony Lumber":
                lumberQty[9] -= quantity;
                break;
            case "Basic Leather Strap":
                leatherStrapQty[0] -= quantity;
                break;
            case "Standard Leather Strap":
                leatherStrapQty[1] -= quantity;
                break;
            case "Good Leather Strap":
                leatherStrapQty[2] -= quantity;
                break;
            case "Excellent Leather Strap":
                leatherStrapQty[3] -= quantity;
                break;
            case "Expert Leather Strap":
                leatherStrapQty[4] -= quantity;
                break;
            case "Basic Leather Padding":
                leatherPaddingQty[0] -= quantity;
                break;
            case "Standard Leather Padding":
                leatherPaddingQty[1] -= quantity;
                break;
            case "Good Leather Padding":
                leatherPaddingQty[2] -= quantity;
                break;
            case "Excellent Leather Padding":
                leatherPaddingQty[3] -= quantity;
                break;
            case "Expert Leather Padding":
                leatherPaddingQty[4] -= quantity;
                break;
            case "Basic Hilt":
                hiltQty[0] -= quantity;
                break;
            case "Standard Hilt":
                hiltQty[1] -= quantity;
                break;
            case "Good Hilt":
                hiltQty[2] -= quantity;
                break;
            case "Excellent Hilt":
                hiltQty[3] -= quantity;
                break;
            case "Expert Hilt":
                hiltQty[4] -= quantity;
                break;
            case "Basic Sheath":
                sheathQty[0] -= quantity;
                break;
            case "Standard Sheath":
                sheathQty[1] -= quantity;
                break;
            case "Good Sheath":
                sheathQty[2] -= quantity;
                break;
            case "Excellent Sheath":
                sheathQty[3] -= quantity;
                break;
            case "Expert Sheath":
                sheathQty[4] -= quantity;
                break;
            case "Basic Handle":
                handleQty[0] -= quantity;
                break;
            case "Standard Handle":
                handleQty[1] -= quantity;
                break;
            case "Good Handle":
                handleQty[2] -= quantity;
                break;
            case "Excellent Handle":
                handleQty[3] -= quantity;
                break;
            case "Expert Handle":
                handleQty[4] -= quantity;
                break;
            default:
                Debug.Log("Merchant item not found");
                break;
        }

        //Debug.Log("Added " + itemName + " of quantity: " + quantity + " to inventory");

        BuildInventory();
    }

    public SortedInventory getItemType(string type)
    {
        if (type == "sword")
        {
            return swords;
        }

        return null;
    }

    private void addInventoryLine(string item, int qty, GameObject background)
    {
        tempObj = Instantiate(itemLine, background.transform.position, Quaternion.identity) as GameObject;
        tempObj.transform.SetParent(background.transform);
        tempObj.transform.localScale = new Vector3(1, 1, 1);
        tempObj.name = item;
        tempObj.transform.GetChild(0).GetComponent<Text>().text = item;
        tempObj.transform.GetChild(1).GetComponent<Text>().text = "";
    }
    private void addInventoryLine(string item, int qty, GameObject background, bool blank)
    {
        tempObj = Instantiate(itemLine, background.transform.position, Quaternion.identity) as GameObject;
        tempObj.transform.SetParent(background.transform);
        tempObj.transform.localScale = new Vector3(1, 1, 1);
        tempObj.name = item;
        if (!blank)
        {
            tempObj.transform.GetChild(0).GetComponent<Text>().text = item;
            tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + qty;
        }
        else
        {
            if (qty == 0)
            {
                tempObj.transform.GetChild(0).GetComponent<Text>().text = item;
            }
            else
            {
                tempObj.transform.GetChild(0).GetComponent<Text>().text = "";
            }
            tempObj.transform.GetChild(1).GetComponent<Text>().text = "";
        }
    }

    public void resetScrollbarValue()
    {
        Canvas.ForceUpdateCanvases();
        inventoryWindow.GetComponent<ScrollRect>().verticalScrollbar.value = 0.0f;
        Canvas.ForceUpdateCanvases();
        inventoryWindow.GetComponent<ScrollRect>().verticalScrollbar.value = 1f;
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
                        //DecreaseSize();
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
