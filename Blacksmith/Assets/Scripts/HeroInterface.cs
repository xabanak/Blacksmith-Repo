using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HeroInterface : MonoBehaviour {

    private DataScript dataScript;
    private Adventurer[] adventurers;
    private AdventureRoutine adventurerRoutine;
    public GameObject baseWindow;
    public GameObject finishedAdventureWindow;
    public Button heroStatus;
    public Button adventureStatus;
    public Text heroName;
    public Text[] lootLines;
    private const int totalLootLines = 6;
    public Text heroScript;
    public Button[] statusButtons;
    private int[] lootItems;
    private const int totalLootItems = 39;
    private int currentHeroStatus;
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
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    private void clearLootItems()
    {
        for (int i = 0; i < totalLootItems; i++)
        {
            lootItems[i] = 0;
        }
    }

    void updateActiveHeroes()
    {
        
    }

    public void setHeroScript()
    {
        heroScript.text = dataScript.getRandomReturnScript();
    }

    public void showBaseWindow(int hero)
    {
        adventurers = adventurerRoutine.getAdventurers();
        baseWindow.SetActive(true);
        heroName.text = adventurers[hero].getName();
        currentHeroStatus = hero;
        Debug.Log("Hero :" + hero);
    }

    public void setLootItems(string item, int qty)
    {
        item = addUnderscore(item);
        Debug.Log("loot string" + item);
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

        finishedAdventureWindow.SetActive(false);
    }

    public void resetBaseWindow()
    {
        adventurers = adventurerRoutine.getAdventurers();
        baseWindow.SetActive(false);
        heroName.text = "";
    }
}
