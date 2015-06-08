using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AdventureRoutine : MonoBehaviour 
{
    private HeroInterface heroInterface;
    private Adventurer[] adventurers;
    private string[] adventureZone;
    private int[] adventureDecriment;
    const int NUM_ADVENTURERS = 3;
    private int numAdventurers;
    public GameController gameController;
    public CreateInventory inventoryController;
    private DataScript dataScript;

    private Text[] heroIndicators;
    private Button[] heroStatus;
    private Image[] heroPortraits;

    double[] adventureTimers;
    const double baseTimer = 60.0f;

	void Start () 
    {
        heroIndicators = new Text[NUM_ADVENTURERS];
        heroPortraits = new Image[NUM_ADVENTURERS];
        heroStatus = new Button[NUM_ADVENTURERS];
        heroIndicators[0] = GameObject.Find("Overlay Canvas/Hero Background/Status One Button/Status One").GetComponent<Text>();
        heroIndicators[1] = GameObject.Find("Overlay Canvas/Hero Background/Status Two Button/Status Two").GetComponent<Text>();
        heroIndicators[2] = GameObject.Find("Overlay Canvas/Hero Background/Status Three Button/Status Three").GetComponent<Text>();
        heroStatus[0] = GameObject.Find("Overlay Canvas/Hero Background/Status One Button").GetComponent<Button>();
        heroStatus[1] = GameObject.Find("Overlay Canvas/Hero Background/Status Two Button").GetComponent<Button>();
        heroStatus[2] = GameObject.Find("Overlay Canvas/Hero Background/Status Three Button").GetComponent<Button>();
        heroPortraits[0] = GameObject.Find("Overlay Canvas/Hero Background/Portrait One").GetComponent<Image>();
        heroPortraits[1] = GameObject.Find("Overlay Canvas/Hero Background/Portrait Two").GetComponent<Image>();
        heroPortraits[2] = GameObject.Find("Overlay Canvas/Hero Background/Portrait Three").GetComponent<Image>();
        dataScript = gameController.GetComponent<DataScript>();
	    adventurers = new Adventurer[NUM_ADVENTURERS];
        adventureZone = new string[NUM_ADVENTURERS];
        adventureDecriment = new int[NUM_ADVENTURERS];
        adventureTimers = new double[NUM_ADVENTURERS];
        adventurers[0] = null;
        adventurers[1] = null; 
        adventurers[2] = null;
        heroInterface = gameController.GetComponent<HeroInterface>();

        numAdventurers = 0;
	}

	void Update () 
    {
        if (adventurers[0] != null)
        {
            if (adventurers[0].getAdventuringState())
            {
                updateAdventure(0);
            }
        }
        if (adventurers[1] != null)
        {
            if (adventurers[1].getAdventuringState())
            {
                updateAdventure(1);
            }
        }
        if (adventurers[2] != null)
        {
            if (adventurers[2].getAdventuringState())
            {
                updateAdventure(2);
            }
        }
    }

    public int getNumAdventurers()
    {
        return numAdventurers;
    }

    private void updateAdventure(int adventureIter)
    {
        adventureTimers[adventureIter] -= Time.deltaTime;
        //Debug.Log(adventureTimers[adventureIter]);
        if (adventureTimers[adventureIter] <= 0)
        {
            endAdventure(adventureIter);
            return;
        }
        heroIndicators[adventureIter].text = "Returns: " + (int)adventureTimers[adventureIter];
    }

    public bool addAdventurer(Adventurer newHero)
    {
        if (adventurers[0] == null)
        {
            adventurers[0] = newHero;
            heroStatus[0].interactable = true;
            heroPortraits[0].sprite = newHero.getPortrait();
            heroIndicators[0].text = "Ready to adventure";
            numAdventurers++;
            return true;
        }
        else if (adventurers[1] == null)
        {
            adventurers[1] = newHero;
            heroStatus[1].interactable = true;
            heroPortraits[1].sprite = newHero.getPortrait();
            heroIndicators[1].text = "Ready to adventure";
            numAdventurers++;
            return true;
        }
        else if (adventurers[2] == null)
        {
            adventurers[2] = newHero;
            heroStatus[2].interactable = true;
            heroPortraits[2].sprite = newHero.getPortrait();
            heroIndicators[2].text = "Ready to adventure";
            numAdventurers++;
            return true;
        }
        return false;
    }

    private void removeAdventurer(Adventurer hero)
    {
        for (int i = 0; i < NUM_ADVENTURERS; i++)
        {
            if (adventurers[i] == hero)
            {
                adventurers[i] = null;
                heroStatus[i].interactable = false;
                heroPortraits[i].sprite = null;
                heroIndicators[i].text = "Deceased";
                numAdventurers--;
            }
        }
    }

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

    public bool sendOnAdventure(Adventurer adventurer, string adventureZone, int levelDecrimentor)
    {
        //Debug.Log("Send on adventure called");
        int adventurerIter;
        if (adventurers[0] == adventurer)
        {
            adventurerIter = 0;
        }
        else if(adventurers[1] == adventurer)
        {
            adventurerIter = 1;
        }
        else if(adventurers[2] == adventurer)
        {
            adventurerIter = 2;
        }
        else
        {
            return false;
        }

        if (adventurer.sendOnAdventure(adventureZone))
        {
            //adventureTimers[adventurerIter] = dataScript.getAdvTimeMult(adventurer.getLevel(), levelDecrimentor);
            heroStatus[adventurerIter].interactable = false;
            this.adventureZone[adventurerIter] = adventureZone;
            adventureDecriment[adventurerIter] = levelDecrimentor;
            Debug.Log(adventureDecriment[adventurerIter]);
            adventureTimers[adventurerIter] = baseTimer * dataScript.getAdvTimeMult(adventurers[adventurerIter].getLevel(), adventureDecriment[adventurerIter]);
            Debug.Log(adventureTimers[adventurerIter]);
            return true;
        }
        return false;
    }

    private void endAdventure(int adventurerIter)
    {
        int level = adventurers[adventurerIter].getLevel();
        int chanceToSucceedInt;
        double chanceToSucceedDbl = ((5.0f * Convert.ToDouble(level - adventureDecriment[adventurerIter])) + adventurers[adventurerIter].getPowerLevel()) / (15.0f * Convert.ToDouble(level - adventureDecriment[adventurerIter]));

        if (chanceToSucceedDbl >= 1.0f)
        {
            //Debug.Log("Guaranteed success");
            returnFromAdventure(adventurerIter);
        }
        else
        {
            chanceToSucceedDbl *= 100.0f;
            chanceToSucceedInt = Convert.ToInt32(chanceToSucceedDbl);
            int randomNumber = UnityEngine.Random.Range(0, 101);
            if (randomNumber >= chanceToSucceedInt)
            {
                removeAdventurer(adventurers[adventurerIter]);
                return;
            }
        }
        returnFromAdventure(adventurerIter);
    }

    private void returnFromAdventure(int adventurerIter)
    {
        heroIndicators[adventurerIter].text = "Returned.";
        adventurers[adventurerIter].returnFromAdventure();
        heroStatus[adventurerIter].interactable = true;
    }

    public void collectFromAdventurer(Adventurer adventurer)
    {
        if (adventurer == null)
        {
            return;
        }

        int adventurerIter = 0;
        if (adventurers[0] == adventurer)
        {
            adventurerIter = 0;
        }
        else if (adventurers[1] == adventurer)
        {
            adventurerIter = 1;
        }
        else if (adventurers[2] == adventurer)
        {
            adventurerIter = 2;
        }
        if (adventurer.collectFromAdventure(adventureDecriment[adventurerIter]))
        {
            heroIndicators[adventurerIter].text = "Ready to adventure";
        }
    }

    public void destroyInventory(GameObject[] inventory)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                GameObject tempObject = inventory[i];
                inventory[i] = null;
                GameObject.Destroy(tempObject);
            }
        }
    }
}

public class Adventurer
{
    bool isHome; // Tracks if the adventurer is home and not waiting to interact with the adventurer
    bool isReturned; // Tracks if the adventurer has returned from an adventure but has not been interacted by the player yet
    private string name;
    private int level;
    private int powerLevel;
    private int adventures;
    private int oreModifier;
    private int skinsModifier;
    private int woodModifier;
    private AdventureRoutine adventureRoutine;
    private GameObject[] inventory;
    private Sprite portrait;
    private DataScript dataScript;
    private GameObject gameController;
    private HeroInterface heroInterface;
    private CreateInventory inventoryController;
    AdventureZone adventureZone;

    private const int INV_OBJECTS = 9;
    private const int LOOT_OPTIONS = 8;
    private const int ITEM_TYPES = 3;

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

    enum AdventureZone
    {
        Plains = 0,
        Caves,
        Forest,
        Swamp
    }

    public Adventurer()
    {
        gameController = GameObject.Find("GameController");
        adventureRoutine = gameController.GetComponent<AdventureRoutine>();
        heroInterface = gameController.GetComponent<HeroInterface>();
        inventoryController = GameObject.Find("Inventory/InventoryController").GetComponent<CreateInventory>();
        dataScript = gameController.GetComponent<DataScript>();
        name = dataScript.getAdventurerName();
        this.level = 1;
        powerLevel = 1;
        isHome = true;
        isReturned = false;
        inventory = new GameObject[INV_OBJECTS];
        portrait = Resources.Load("Images/First_warrior_trans", typeof(Sprite)) as Sprite;
        adventures = 0;
        //Debug.Log(portrait);

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

   /* ~Adventurer()
    {
        adventureRoutine.destroyInventory(inventory);
    }*/

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

    public string goodAt()
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

    public string badAt()
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
        powerLevel = level;
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
        calculatePower();
    }

    public int getLevel()
    {
        return level;
    }

    public int getPowerLevel()
    {
        return powerLevel;
    }

    public bool sendOnAdventure(string adventureZone)
    {
        //Debug.Log(isHome + " " + isReturned);
        if (isHome && !isReturned)
        {
            this.adventureZone = (AdventureZone)Enum.Parse(typeof(AdventureZone), adventureZone);
            isHome = false;
            return true;
        }
        return false;
    }

    public bool collectFromAdventure(int adventureDecriment)
    {
        if (isReturned)
        {
            for (int i = 0; i < ITEM_TYPES; i++)
            {
                int totalWeight = 0;
                int roll;
                int totalRolls = 0;

                switch(i)
                {
                    case 0:
                        {
                            totalRolls += oreModifier;
                            break;
                        }
                    case 1:
                        {
                            totalRolls += woodModifier;
                            break;
                        }
                    case 2:
                        {
                            totalRolls += skinsModifier;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                
                switch (adventureZone)
                {
                    case AdventureZone.Plains:
                        {
                            totalRolls += 2;
                            break;
                        }
                    case AdventureZone.Caves:
                        {
                            if (i == 0)
                            {
                                totalRolls += 4;
                            }
                            break;
                        }
                    case AdventureZone.Forest:
                        {
                            if (i == 1)
                            {
                                totalRolls += 4;
                            }
                            break;
                        }
                    case AdventureZone.Swamp:
                        {
                            if (i == 2)
                            {
                                totalRolls += 4;
                            }
                            break;
                        }
                }

                LootEntry[] lootOptions = new LootEntry[LOOT_OPTIONS];

                //Debug.Log(level + " " + adventureDecriment);
                
                for(int j = 0; j < LOOT_OPTIONS; j++)
                {
                    lootOptions[j] = dataScript.getLootItem((level - adventureDecriment - 1), i, j);
                   /* if (lootOptions[j] != null)
                    {
                        Debug.Log(lootOptions[j].getItem() + ", " + lootOptions[j].getWeight());
                    }*/
                    if (lootOptions[j] == null)
                    {
                        //Debug.Log("Null lootOption found, breaking loop");
                        break;
                    }
                    totalWeight += lootOptions[j].getWeight();
                }

                for (int j = 0; j < totalRolls; j++)
                {
                    int currentWeight = 0;
                    roll = UnityEngine.Random.Range(0, totalWeight);
                    //Debug.Log("Total length of LootOptions: " + LOOT_OPTIONS + ", items in LootOptions: " + lootOptions.Length);
                    for (int k = 0; k < lootOptions.Length; k++)
                    {
                        if (lootOptions[k] == null)
                        {
                            //Debug.Log("Null lootOption found, breaking loop");
                            break;
                        }
                        if (roll > lootOptions[k].getWeight())
                        {
                            currentWeight += lootOptions[k].getWeight();
                            continue;
                        }
                        inventoryController.addItem(lootOptions[k].getItem(), 1);
                        heroInterface.setLootItems(lootOptions[k].getItem(), 1);
                        //Debug.Log("Added " + lootOptions[k].getItem() + " to inventory.");
                        break;
                    }
                }
            }

            if (adventureDecriment == 0)
            {
                levelUp();
            }
            isReturned = false;
            adventures++;
            return true;
        }
        return false;
    }

    public int getAdventures()
    {
        return adventures;
    }

    public void returnFromAdventure()
    {
        isHome = true;
        isReturned = true;
    }

    public bool getAdventuringState()//True: currently on an adventure, false: currently home
    {
        return !isHome;
    }

    public bool getReturnedState()//True: currently returned from adventure, false: currently not returned from adventure
    {
        return isReturned;
    }

    public bool canAdventure()
    {
        if (isHome && !isReturned)
        {
            return true;
        }

        return false;
    }

    public Sprite getPortrait()
    {
        return portrait;
    }

    public GameObject getEquipment(string item)
    {
        switch (item)
        {
            case "sword":
                return inventory[0];
        }

        return null;
    }
}
