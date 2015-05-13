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
	
	}

    public void addAdventurer(Adventurer newHero)
    {
        if (numAdventurers == 3)
        {
            return; 
        }

        adventurers[numAdventurers] = newHero;

        numAdventurers++;
    }

    public Adventurer[] getAdventurers()
    {
        return adventurers;
    }
}

public class Adventurer
{
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
        this.name = "Billy bob";
        this.level = 1;
        powerLevel = 0;
        inventory = new GameObject[INV_OBJECTS];
        //UnityEngine.Random.seed = (int)System.DateTime.Now.Ticks;

        oreModifier = UnityEngine.Random.Range(0, 5);
        if (oreModifier == 0)
        {
            skinsModifier = 5;
            woodModifier = 5;
        }
        else if (oreModifier == 1)
        {
            skinsModifier = UnityEngine.Random.Range(4, 5);
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
            skinsModifier = UnityEngine.Random.Range(3, 5);
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
            skinsModifier = UnityEngine.Random.Range(2, 5);
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
            skinsModifier = UnityEngine.Random.Range(1, 5);
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
            skinsModifier = UnityEngine.Random.Range(0, 5);
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

    void equip(GameObject item)
    {
        int itemType = (int)Enum.Parse(typeof(Item), item.GetComponent<ItemScript>().GetItem());
    }

    string getDescription()
    {
        return name + ", Level " + level + ", Good at finding " + goodAt() + ", bad at finding " + badAt();
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
                temp += ", ";
            }
            temp += "skins";
        }
        if (woodModifier > 3)
        {
            if (skinsModifier > 3)
            {
                temp += ", ";
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
                temp += ", ";
            }
            temp += "skins";
        }
        if (woodModifier < 2)
        {
            if (skinsModifier < 2)
            {
                temp += ", ";
            }
            temp += "wood";
        }
        return temp;
    }
}
