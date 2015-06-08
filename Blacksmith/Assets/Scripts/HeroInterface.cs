using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HeroInterface : MonoBehaviour {

    private DataScript dataScript;
    private Adventurer[] adventurers;
    private AdventureRoutine adventurerRoutine;
    private CreateInventory createInventory;
    public GameObject baseWindow;
    public GameObject statusWindow;
    public GameObject finishedAdventureWindow;
    public GameObject equipmentLine;
    public GameObject equipmentBackground;
    public GameObject equipmentWindow;
    public GameObject equipmentBorder;
    public Text[] lootLines;
    public Text heroName;
    public Text heroScript;
    public Text nameText;
    public Text levelText;
    public Text powerText;
    public Text adventurersText;
    public Button[] statusButtons;
    public Button equipButtonTest;
    public Button weaponButton;
    public Button doneButton;
    public Button heroStatus;
    public Button adventureStatus;
    public Sprite swordImage;
    private const int totalLootItems = 39;
    private const int totalLootLines = 6;
    private int currentHeroStatus;
    private int[] lootItems;
    private bool[] heroHasReturned;

	// Use this for initialization
	void Start () 
    {
        currentHeroStatus = 0;
        adventurerRoutine = GameObject.Find("GameController").GetComponent<AdventureRoutine>();
        adventurers = adventurerRoutine.getAdventurers();
        statusButtons[0].interactable = false;
        statusButtons[1].interactable = false;
        statusButtons[2].interactable = false;
        lootItems = new int[totalLootItems];
        clearLootItems();
        dataScript = GameObject.Find("GameController").GetComponent<DataScript>();
        createInventory = GameObject.Find("Inventory/InventoryController").GetComponent<CreateInventory>();
	}

    private void clearLootItems()
    {
        for (int i = 0; i < totalLootItems; i++)
        {
            lootItems[i] = 0;
        }
    }

    public void setHeroScript()
    {
        heroScript.text = dataScript.getRandomReturnScript();
    }

    public void showBaseWindow(int hero)
    {
        adventurers = adventurerRoutine.getAdventurers();
        if (!statusWindow.activeSelf)
        {
            baseWindow.SetActive(true);
            heroName.text = adventurers[hero].getName();
            currentHeroStatus = hero;

            if (adventurers[hero].canAdventure())
            {
                adventureStatus.interactable = false;
            }
            else
            {
                adventureStatus.interactable = true;
            }
        }
        //Debug.Log("Hero :" + hero);
    }

    public void setLootItems(string item, int qty)
    {
        item = addUnderscore(item);
        //Debug.Log("loot string" + item);
        int itemType = (int)Enum.Parse(typeof(Item), item);
        item = removeUnderscore(item);
        lootItems[itemType] += qty;
    }

    public void setLootLines()
    {
        string item;
        int counter = 0;

        for (int i = 0; i < totalLootItems; i++)
        {
            if (lootItems[i] > 0)
            {
                item = (string)Enum.GetName(typeof(Item), i);
                item = removeUnderscore(item);
                lootLines[counter].text = item + " X " + lootItems[i];
                counter++;
            }
        }

        for (int i = counter; i < totalLootLines; i++)
        {
            lootLines[i].text = "";
        }
    }

    public void displayAdventureResults()
    {
        setLootLines();
        setHeroScript();
        finishedAdventureWindow.SetActive(true);
    }

    public void collectAdventurerLoot()
    {
        adventurers = adventurerRoutine.getAdventurers();

        switch(currentHeroStatus)
        {
            case 0:
                adventurerRoutine.collectFromAdventurer(adventurers[0]);
                break;
            case 1:
                adventurerRoutine.collectFromAdventurer(adventurers[1]);
                break;
            case 2:
                adventurerRoutine.collectFromAdventurer(adventurers[2]);
                break;
        }
    }

    public void setCurrentSelectedHero(int index)
    {
        currentHeroStatus = index;
    }
    public void hideAdventureResults()
    {
        finishedAdventureWindow.SetActive(false);
        clearLootItems();
    }

    enum Item // Listing of items
    {
        Tin_Ore = 0,
        Copper_Ore,
        Zinc_Ore,
        Iron_Ore,
        Black_Ore,
        Nickel_Ore,
        Carbon_Ore,
        Manganese_Ore,
        Chromium_Ore,
        Dragon_Ore,
        Sheep_Skin,
        Goat_Skin,
        Buffalo_Skin,
        Dodo_Skin,
        Serpent_Skin,
        Wolf_Skin,
        Ogre_Skin,
        Troll_Skin,
        Wyvern_Skin,
        Dragon_Skin,
        Rough_Malachite,
        Rough_Lapis_Lazuli,
        Rough_Turquoise,
        Rough_Coral,
        Rough_Agate,
        Rough_Jasper,
        Rough_Opal,
        Rough_Ruby,
        Rough_Pearl,
        Rought_Moonstone,
        Raw_Elm,
        Raw_Alder,
        Raw_Maple,
        Raw_Sandlewood,
        Raw_Ash,
        Raw_Fir,
        Raw_Cedar,
        Raw_Ironwood,
        Raw_Rosewood,
        Raw_Ebony
    }

    private string removeUnderscore(string word)
    {
        string tempString = "";
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == '_')
            {
                tempString += " ";
            }
            else
            {
                tempString += word[i];
            }
        }

        return tempString;
    }

    private string addUnderscore(string word)
    {
        string tempString = "";
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == ' ')
            {
                tempString += "_";
            }
            else
            {
                tempString += word[i];
            }
        }

        return tempString;
    }
    
    public void resetHeroWindow()
    {
        heroName.text = "";
        for (int i = 0; i < totalLootLines; i++)
        {
            lootLines[i].text = "";
        }

        for (int i = 0; i < totalLootItems; i++)
        {
            lootItems[i] = 0;
        }

            finishedAdventureWindow.SetActive(false);
    }

    public void resetBaseWindow()
    {
        adventurers = adventurerRoutine.getAdventurers();
        baseWindow.SetActive(false);
        heroName.text = "";
    }

    public void equipHero(GameObject item)
    {
        adventurers[currentHeroStatus].equip(item);
        createInventory.swords.RemoveItem(item);
        clearEquipmentList();
        hideEquipmentWindow();
        setHeroInfo();
    }

    public void pullUpStatus()
    {
        baseWindow.SetActive(false);
        setHeroInfo();
        statusWindow.gameObject.SetActive(true);
    }

    private void setHeroInfo()
    {
        nameText.text = adventurers[currentHeroStatus].getName();
        levelText.text = "Level: " + adventurers[currentHeroStatus].getLevel();
        powerText.text = "Power: " + adventurers[currentHeroStatus].getPowerLevel();
        adventurersText.text = "Adventures: " + adventurers[currentHeroStatus].getAdventures();
        if (adventurers[currentHeroStatus].getEquipment("sword") != null)
        {
            weaponButton.image.overrideSprite = swordImage;
            weaponButton.transform.GetChild(0).GetComponent<Text>().text = "";
        }
        else
        {
            weaponButton.image.overrideSprite = null;
            weaponButton.transform.GetChild(0).GetComponent<Text>().text = "Weapon";
        }
    }

    public void closeHeroStatus()
    {
        nameText.text = "";
        levelText.text = "";
        powerText.text = "";
        adventurersText.text = "";
        statusWindow.gameObject.SetActive(false);
        equipButtonTest.gameObject.SetActive(false);
    }

    public void toggleEquipmentWindow()
    {
        equipmentWindow.SetActive(!equipmentWindow.activeSelf);
        equipmentBorder.SetActive(!equipmentBorder.activeSelf);
    }

    public void hideEquipmentWindow()
    {
        equipmentWindow.SetActive(false);
        equipmentBorder.SetActive(false);
    }

    public void clearEquipmentList()
    {
        foreach (Transform itemLine in equipmentBackground.transform)
        {
            Destroy(itemLine.gameObject);
        }
    }

    public void deactivateHeroInterface()
    {
        closeHeroStatus();
        hideEquipmentWindow();
        resetBaseWindow();
        foreach (Button status in statusButtons)
        {
            status.interactable = false;
        }
    }

    public void activateHeroInterface()
    {
        adventurers = adventurerRoutine.getAdventurers();
        int i = 0;

        foreach (Adventurer hero in adventurers)
        {
            if (hero != null && !hero.getAdventuringState())
            {
                statusButtons[i].interactable = true;
            }

            i++;
        }
    }
    public void buildEquipmentList()
    {
        int totalItems = 0;

        for (int i = 0; i < createInventory.getItemType("sword").GetCurrentSize(); i++)
        {
            addEquipmentLine(createInventory.getItemType("sword").GetItem(i).GetComponent<ItemScript>().GetItemDescription(), equipmentBackground, false, createInventory.getItemType("sword").GetItem(i));
            totalItems++;
        }

        if (totalItems == 0)
        {
            addEquipmentLine("No Equipment Availible", equipmentBackground, false, null);
            totalItems++;
        }

        for (int i = totalItems; i < 20; i++)
        {
            addEquipmentLine("", equipmentBackground, true, null);
        }
    }

    private void addEquipmentLine(string item, GameObject background, bool blank, GameObject type)
    {
        GameObject tempObj;

        tempObj = Instantiate(equipmentLine, background.transform.position, Quaternion.identity) as GameObject;
        tempObj.transform.SetParent(background.transform);
        tempObj.transform.localScale = new Vector3(1, 1, 1);
        tempObj.name = item;
        if (type != null)
        {
            tempObj.AddComponent<EquipHero>();
            tempObj.AddComponent<SellItem>();
            tempObj.GetComponent<SellItem>().setCraftedItem(type);
        }

        if (!blank)
        {
            tempObj.transform.GetChild(0).GetComponent<Text>().text = item;
        }
        else
        {
            tempObj.transform.GetChild(0).GetComponent<Text>().text = "";
        }
    }
}
