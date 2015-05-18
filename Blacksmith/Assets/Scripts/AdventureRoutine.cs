using UnityEngine;
using System.Collections;
using System;

public class AdventureRoutine : MonoBehaviour 
{
    private Adventurer[] adventurers;
    const int NUM_ADVENTURERS = 3;
    private int numAdventurers;
    public GameController gameController;

	void Start () 
    {
	    adventurers = new Adventurer[NUM_ADVENTURERS];
        numAdventurers = 0;
	}

	void Update () 
    {
        if (adventurers[0].getAdventuringState())
        {
            updateAdventure(0);
        }
        if (adventurers[1].getAdventuringState())
        {
            updateAdventure(1);
        }
        if (adventurers[2].getAdventuringState())
        {
            updateAdventure(2);
        }
    }

    private void updateAdventure(int adventurerIterator)
    {

    }

    public void addAdventurer(Adventurer newHero)
    {
        if (numAdventurers < 3)
        {
            adventurers[numAdventurers] = newHero;

            numAdventurers++;
        }
    }

    /*private void removeAdventurer(Adventurer hero)
    {
        for (int i = 0; i < NUM_ADVENTURERS; i++)
        {
            if (adventurers[i] == hero)

        }
    }*/
        //Debug.Log("numAdventurers = " + numAdventurers);

    public Adventurer[] getAdventurers()
    {
        return adventurers;
    }

    bool canHireAdventurer()
    {
        if (numAdventurers < NUM_ADVENTURERS)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool sendOnAdventure(Adventurer adventurer, string adventureZone)
    {
        if (adventurer.sendOnAdventure())
        {
            return true;
        }
        return false;
    }

    enum adventureZones
    {
        Plains,
        Caves,
        Forest,
        Swamp
    }
}

public class Adventurer
{
    bool isHome;
    bool isReturned;
    private string name;
    private int level;
    private int powerLevel;
    private int oreModifier;
    private int skinsModifier;
    private int woodModifier;
    private GameObject[] inventory;

    private const int INV_OBJECTS = 9;

    enum Item // Listing of items
    {
        Sword = 0,
        Shield,
        Breastplate,
        Helm,
        Bracers,
        Gauntlet,
        Boots,
        Greaves,
        Pauldrons
    }

    public Adventurer()
    {
        name = GameObject.Find("GameController").GetComponent<DataScript>().getAdventurerName();
        this.level = 1;
        powerLevel = 0;
        isHome = true;
        isReturned = false;
        inventory = new GameObject[INV_OBJECTS];

        oreModifier = UnityEngine.Random.Range(0, 6);
        //Debug.Log("oreModifier: " + oreModifier);
        if (oreModifier == 0)
        {
            skinsModifier = 5;
            woodModifier = 5;
        }
        else if (oreModifier == 1)
        {
            skinsModifier = UnityEngine.Random.Range(4, 6);
            if (skinsModifier == 4)
            {
                woodModifier = 5;
            }
            else if (skinsModifier == 5)
            {
                woodModifier = 4;
            }
        }
        else if (oreModifier == 2)
        {
            skinsModifier = UnityEngine.Random.Range(3, 6);
            if (skinsModifier == 3)
            {
                woodModifier = 5;
            }
            else if (skinsModifier == 4)
            {
                woodModifier = 4;
            }
            else if (skinsModifier == 5)
            {
                woodModifier = 3;
            }
        }
        else if (oreModifier == 3)
        {
            skinsModifier = UnityEngine.Random.Range(2, 6);
            if (skinsModifier == 2)
            {
                woodModifier = 5;
            }
            else if (skinsModifier == 3)
            {
                woodModifier = 4;
            }
            else if (skinsModifier == 4)
            {
                woodModifier = 3;
            }
            else if (skinsModifier == 5)
            {
                woodModifier = 2;
            }
        }
        else if (oreModifier == 4)
        {
            skinsModifier = UnityEngine.Random.Range(1, 6);
            if (skinsModifier == 1)
            {
                woodModifier = 5;
            }
            else if (skinsModifier == 2)
            {
                woodModifier = 4;
            }
            else if (skinsModifier == 3)
            {
                woodModifier = 3;
            }
            else if (skinsModifier == 4)
            {
                woodModifier = 2;
            }
            else if (skinsModifier == 5)
            {
                woodModifier = 1;
            }
        }
        else if (oreModifier == 5)
        {
            skinsModifier = UnityEngine.Random.Range(0, 6);
            if (skinsModifier == 0)
            {
                woodModifier = 5;
            }
            else if (skinsModifier == 1)
            {
                woodModifier = 4;
            }
            else if (skinsModifier == 2)
            {
                woodModifier = 3;
            }
            else if (skinsModifier == 3)
            {
                woodModifier = 2;
            }
            else if (skinsModifier == 4)
            {
                woodModifier = 1;
            }
            else if (skinsModifier == 5)
            {
                woodModifier = 0;
            }
        }
    }

    public void equip(GameObject item)
    {
        int itemType = (int)Enum.Parse(typeof(Item), item.GetComponent<ItemScript>().GetItem());
        inventory[itemType] = item;
        calculatePower();
    }

    public string getName()
    {
        return name;
    }
    public string getDescription()
    {
        return name + ", Level " + level + "\nGood at finding " + goodAt() + "\nBad at finding " + badAt();
    }

    string goodAt()
    {
        string temp = "";
        if (oreModifier > 3)
        {
            temp += "ore";
        }
        if (skinsModifier > 3)
        {
            if (oreModifier > 3)
            {
                temp += " and ";
            }
            temp += "skins";
        }
        if (woodModifier > 3)
        {
            if (skinsModifier > 3 || oreModifier > 3)
            {
                temp += " and ";
            }
            temp += "wood";
        }
        return temp;
    }

    string badAt()
    {
        string temp = "";
        if (oreModifier < 2)
        {
            temp += "ore";
        }
        if (skinsModifier < 2) 
        {
            if (oreModifier < 2)
            {
                temp += " and ";
            }
            temp += "skins";
        }
        if (woodModifier < 2)
        {
            if (skinsModifier < 2 || oreModifier < 2)
            {
                temp += " and ";
            }
            temp += "wood";
        }
        if (temp == "")
        {
            temp = "nothing";
        }
        return temp;
    }

    void calculatePower()
    {
        powerLevel = 0;
        foreach(GameObject item in inventory)
        {
            if (item != null)
            {
                powerLevel += item.GetComponent<ItemScript>().GetPower();
            }
        }
    }

    public int getOreLevel()
    {
        return oreModifier;
    }

    public int getSkinsLevel()
    {
        return skinsModifier;
    }

    public int getWoodLevel()
    {
        return woodModifier;
    }

    public void levelUp()
    {
        level++;
    }

    public int getLevel()
    {
        return level;
    }

    public bool sendOnAdventure()
    {
        if (isHome && !isReturned)
        {
            isHome = false;
            return true;
        }
        return false;
    }

    public bool collectFromAdventure()
    {
        if (isReturned)
        {
            isReturned = false;
            return true;
        }
        return false;
    }

    public bool getAdventuringState()//True: currently on an adventure, false: currently home
    {
        
        return !isHome;
    }

    public bool getReturnedState()//True: currently returned from adventure, false: currently not returned from adventure
    {
        return isReturned;
    }
}
