using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class DataScript : MonoBehaviour 
{
    const int numItems = 9; // Total number of item types
    const int numMats = 10; // Total number of material types
    const int numStages = 6; // Total number of different crafting stages
    const int numItemLevels = 3; // total number of different strengths of items in one tier
    //const string dir = "Assets/StreamingAssets/";
    const int numSurnames = 44;
    const int numFirstNames = 48;
    const int numLevels = 6;
    const int numLevelOptions = 5;
    const int itemTypes = 3;
    const int lootOptions = 8;

    int [] stageCount; // Number of total stages to craft each type of item
    int [,] stageListing; // Listing per item type of which number stage is what crafting stage
    int[] stageTimes; // Base time for each stage
    double[,] stageTimeMult; // Multiplier based on item type and material for the total stage time
    int[,] basePowerLevel; //Base power level for each item/material type combination
    string[] firstNames;
    string[] surnames;
    double[] adventureTimeMultiplier;
    double[] adventureLevelMultiplier;
    LootEntry[,,] lootTables;

    
    public int testInt;
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
    enum Material // Listing of materials
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

    enum ItemType
    {
        Ore,
        Wood,
        Skin
    }

    enum Stage // Listing of stages, currently unused Enum
    {
        Shaping = 0,
        Hardening,
        Tempering,
        Polishing,
        Sharpening,
        Grinding
    }

    enum ItemBaseLevels
    {
        Bracers = 0,
        Pauldrons = 0,
        Helm = 1,
        Gloves = 1,
        Boots = 1,
        Breastplate = 2,
        Greaves = 2,
        Sword = 2,
        Shield = 2
    }
	void Start () 
    {
        stageCount = new int[numItems];
        stageListing = new int[numItems, numStages]; 
        stageTimes = new int[numStages];
        stageTimeMult = new double[numItems, numMats];
        basePowerLevel = new int[numMats, numItemLevels];
        firstNames = new string[numFirstNames];
        surnames = new string[numSurnames];
        adventureTimeMultiplier = new double[numLevels];
        adventureLevelMultiplier = new double[numLevelOptions];
        lootTables = new LootEntry[numLevels, itemTypes, lootOptions];
        readDataFile("stageTime.dat");
        readDataFile("stageCount.dat");
        readDataFile("stageListing.dat");
        readDataFile("stageTimeMult.dat");
        readDataFile("basePower.dat");
        readDataFile("adventurerNames.dat");
        readDataFile("adventureTimeMultiplier.dat");
        readDataFile("adventureLevelMultiplier.dat");
        readDataFile("lootTables.dat");
	}
    void readDataFile(string filePath)
    {
        StreamReader inputStream = new StreamReader(Application.streamingAssetsPath + "/" + filePath);

        char fileIdentity = Convert.ToChar(inputStream.ReadLine());

        int i = 0;
        int j = 0;
        int m = 0;

        bool firstNamesRead = false;

        switch(fileIdentity)
        {
            case 'A': // Stage Time data input
                while (!inputStream.EndOfStream)
                {
                    string tempString = inputStream.ReadLine();
                    if (tempString[0] == '*')
                    {
                        continue;
                    }
                    if (i < numStages)
                    {
                        stageTimes[i] = Convert.ToInt32(tempString);
                    }
                    else
                    {
                        break;
                    }
                    i++;
                }
                break;
                
            case 'B': // Stage Count data input
                while (!inputStream.EndOfStream)
                {
                    string tempString = inputStream.ReadLine();
                    if (tempString[0] == '*')
                    {
                        continue;
                    }
                    if (i < numItems)
                    {
                        stageCount[i] = Convert.ToInt32(tempString);
                    }
                    else
                    {
                        break;
                    }
                    i++;
                }
                break;

            case 'C': // Stage Listing data input
                while (!inputStream.EndOfStream)
                {
                    string tempString = inputStream.ReadLine();
                    if (tempString[0] == '*')
                    {
                        continue;
                    }
                    if (j == numStages || tempString[0] == '+')
                    {
                        i++;
                        j = 0;
                        if (tempString[0] == '+')
                        {
                            continue;
                        }                       
                    }
                    if (i < numItems)
                    {
                        if (j < numStages)
                        {
                            stageListing[i, j] = Convert.ToInt32(tempString);
                            j++;
                        }
                    }
                    else if (i == numItems)
                    {
                        break;
                    }
                }
                break;

            case 'D': // Stage Time Multiplier data input
                while (!inputStream.EndOfStream)
                {
                    string tempString = inputStream.ReadLine();
                    if (tempString[0] == '*')
                    {
                        continue;
                    }
                    if (j == numMats)
                    {
                        i++;
                        j = 0;
                    }
                    if (i < numItems)
                    {
                        if (j < numMats)
                        {
                            stageTimeMult[i, j] = Convert.ToDouble(tempString);
                            j++;
                        }
                    }
                    else if (i == numItems)
                    {
                        break;
                    }
                }
                break;

            case 'E': // Item Power Level data input
                while (!inputStream.EndOfStream)
                {
                    string tempString = inputStream.ReadLine();
                    if (tempString[0] == '*')
                    {
                        continue;
                    }
                    if (j == numItemLevels)
                    {
                        i++;
                        j = 0;
                    }
                    if (i < numMats)
                    {
                        if (j < numItemLevels)
                        {
                            basePowerLevel[i, j] = Convert.ToInt32(tempString);
                            j++;
                        }
                    }
                    else if (i == numMats)
                    {
                        break;
                    }
                }
                break;

            case 'F': // Adventurer Names data input
                while (!inputStream.EndOfStream)
                {
                    string tempString = inputStream.ReadLine();
                    if (tempString[0] == '*')
                    {
                        continue;
                    }
                    if (i == numFirstNames && !firstNamesRead)
                    {
                        i = 0;
                        firstNamesRead = true;
                    }
                    if (i == numSurnames && firstNamesRead)
                    {
                        break;
                    }
                    if (!firstNamesRead)
                    {
                        firstNames[i] = tempString;
                        i++;
                    }
                    else
                    {
                        surnames[i] = tempString;
                        i++;
                    }
                }
                break;

            case 'G': //Adventure Time Multiplier data input
                while (!inputStream.EndOfStream)
                {
                    string tempString = inputStream.ReadLine();
                    if (tempString[0] == '*')
                    {
                        continue;
                    }
                    if (i == numLevels)
                    {
                        break;
                    }
                    adventureTimeMultiplier[i] = Convert.ToDouble(tempString);
                    i++;
                }
                break;

            case 'H':
                while (!inputStream.EndOfStream)
                {
                    string tempString = inputStream.ReadLine();
                    if (tempString[0] == '*')
                    {
                        continue;
                    }
                    if (i == numLevelOptions)
                    {
                        break;
                    }
                    adventureLevelMultiplier[i] = Convert.ToDouble(tempString);
                    i++;
                }
                break;

            case 'I':
                while (!inputStream.EndOfStream)
                {
                    string tempString = inputStream.ReadLine();
                    if (tempString[0] == '*')
                    {
                        continue;
                    }
                    if (i == numLevels)
                    {
                        break;
                    }
                    else if(j == itemTypes)
                    {
                        i++;
                        j = 0;
                        m = 0;
                    }
                    else if (m == lootOptions)
                    {
                        j++;
                        m = 0;
                    }
                    else if (tempString == "next item")
                    {
                        j++;
                        m = 0;
                        continue;
                    }

                    lootTables[i, j, m] = new LootEntry(tempString, Convert.ToInt32(inputStream.ReadLine()));
                    Debug.Log("LootEntry: Item: " + lootTables[i, j, m].getItem() + " \n Weight: " + lootTables[i, j, m].getWeight());
                    m++;
                }
                break;

            default:
                Debug.Log("Failed to load correct data file. " + filePath + " did not load.");
                break;
        }
        
    }

    public double getMult(string item, string material)
    {
        int itemValue = (int)Enum.Parse(typeof(Item), item);
        int matValue = (int)Enum.Parse(typeof(Material), material);

        return stageTimeMult[itemValue, matValue];
    }

    public int getStageCount(string item)
    {
        int itemValue = (int)Enum.Parse(typeof(Item), item);

        return stageCount[itemValue];
    }

    public int getStage(string item, int stage)
    {
        if (stage >= numStages)
        {
            return -1;
        }

        Debug.Log("Getting stage " + stage + " for " + item);
        int itemValue = (int)Enum.Parse(typeof(Item), item);

        Debug.Log("Stage value is" + stageListing[itemValue, stage]);
        return stageListing[itemValue, stage];
    }

    public double getStageTime(int stage)
    {
        return stageTimes[stage];
    }

    public int getBasePowerLevel(string item, string material)
    {
        int itemBaseLevel = (int)Enum.Parse(typeof(ItemBaseLevels), item);
        int matValue = (int)Enum.Parse(typeof(Material), material);

        return basePowerLevel[matValue, itemBaseLevel];
    }

    public string getAdventurerName()
    {
        //Debug.Log(firstNames[UnityEngine.Random.Range(0, numFirstNames)] + " " + surnames[UnityEngine.Random.Range(0, numSurnames)]);
        return firstNames[UnityEngine.Random.Range(0, numFirstNames)] + " " + surnames[UnityEngine.Random.Range(0, numSurnames)];
    }

    public double getAdvTimeMult(int level, int levelDecrementer)
    {
        return adventureTimeMultiplier[level] * adventureLevelMultiplier[levelDecrementer];
    }

    public LootEntry getLootItem(int level, int itemType, int position)
    {
        if (lootTables[level, itemType, position] != null)
        {
            return lootTables[level, itemType, position];
        }
        else return null;
    }
}

public class LootEntry
{
    string item;
    int weight;

    public LootEntry(string item, int weight)
    {
        this.item = item;
        this.weight = weight;
    }

    public string getItem()
    {
        return item;
    }
    public int getWeight()
    {
        return weight;
    }
}
