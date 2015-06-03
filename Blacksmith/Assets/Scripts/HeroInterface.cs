using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HeroInterface : MonoBehaviour {

    private Adventurer[] adventurers;
    private AdventureRoutine adventurerRoutine;
    public GameObject baseWindow;
    public Button heroStatus;
    public Button adventureStatus;
    public Text heroName;
    public Button[] statusButtons;
    private int[] lootItems;
    private const int totalLootItems = 39;

	// Use this for initialization
	void Start () 
    {
        adventurerRoutine = GameObject.Find("GameController").GetComponent<AdventureRoutine>();
        adventurers = adventurerRoutine.getAdventurers();
        statusButtons[0].interactable = false;
        statusButtons[1].interactable = false;
        statusButtons[2].interactable = false;
        lootItems = new int[totalLootItems];
        clearLootItems();
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

    public void showBaseWindow(int hero)
    {
        adventurers = adventurerRoutine.getAdventurers();
        baseWindow.SetActive(true);
        heroName.text = adventurers[hero].getName();
    }

    public void setLootItems(string item, int qty)
    {
        int itemType = (int)Enum.Parse(typeof(Item), item);
        lootItems[itemType] += qty;
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
                tempString += "_";
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
                tempString += " ";
            }
            else
            {
                tempString += word[i];
            }
        }

        return tempString;
    }
    
}
