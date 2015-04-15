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
    private float spacer = 0.375f;

    private int totalItems = 30;
    private int[] testInts;

    private string[] testStrings;

    private ScrollRect tempRect;

    private bool setValue = false;

    private int[] gold;
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

    //private int[] axe;
    //private int[] mace;
    //private int[] flail;
    //private int[] hammer;

    private int[] swordQty;
    private string[] swordName;
    private const int swordSize = 10;
    private SortedInventory swords;

    private int[] shieldQty;
    private string[] shieldName;
    private const int shieldSize = 10;
    private SortedInventory shields;

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

        inventoryScrollbar.value = 1;
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
