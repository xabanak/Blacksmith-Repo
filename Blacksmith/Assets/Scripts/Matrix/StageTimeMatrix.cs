using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class StageTimeMatrix : MonoBehaviour 
{
    const int numItems = 9; // Total number of item types
    const int numMats = 10; // Total number of material types
    const int numStages = 6; // Total number of different crafting stages
    const string dir = "Assets/Resources/";

    int [] stageCount; // Number of total stages to craft each type of item
    int [,] stageListing; // Listing per item type of which number stage is what crafting stage
    int[] stageTimes; // Base time for each stage
    double[,] stageTimeMult; // Multiplier based on item type and material for the total stage time
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

    enum Stage // Listing of stages, currently unused Enum
    {
        Shaping = 0,
        Hardening,
        Tempering,
        Polishing,
        Sharpening,
        Grinding
    }
	void Start () 
    {
        stageCount = new int[numItems];
        stageListing = new int[numItems, numStages]; 
        stageTimes = new int[numStages];
        stageTimeMult = new double[numItems, numMats];
        readDataFile(dir + "stageTime.txt");
        readDataFile(dir + "stageCount.txt");
        readDataFile(dir + "stageListing.txt");
        readDataFile(dir + "stageTimeMult.txt");

        testInt = stageCount[0];
	}
    void readDataFile(string filePath)
    {
        StreamReader inputStream = new StreamReader(filePath);

        char fileIdentity = Convert.ToChar(inputStream.ReadLine());

        int i = 0;
                int j = 0;

        switch(fileIdentity)
        {
            case 'A':
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
                
            case 'B':
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

            case 'C':
                while (!inputStream.EndOfStream)
                {
                    string tempString = inputStream.ReadLine();
                    if (tempString[0] == '*')
                    {
                        continue;
                    }
                    if (j == numStages)
                    {
                        i++;
                        j = 0;
                    }
                    if (i < numItems)
                    {
                        if (j < numStages)
                        {
                            stageListing[i, j] = Convert.ToInt32(tempString);
                        }
                    }
                    else if (i == numItems)
                    {
                        break;
                    }
                }
                break;

            case 'D':
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
                        }
                    }
                    else if (i == numItems)
                    {
                        break;
                    }
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
        int itemValue = (int)Enum.Parse(typeof(Item), item);

        return stageListing[itemValue, stage];
    }

    public double getStageTime(int stage)
    {
        return stageTimes[stage];
    }
}
