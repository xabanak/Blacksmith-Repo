using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class StageTimeMatrix : MonoBehaviour 
{
    const int matrixLength = 1;
    const int matrixWidth = 9;

    double[,] stageTimeMatrix;
    enum Item
    {
        Sword = 0,
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
        SteelAlloy,
        Titanium
    }
	void Start () 
    {
	    stageTimeMatrix = new double[matrixLength, matrixWidth];
        readTextFile("Assets/Resources/stageTime.txt");
	}
    void readTextFile(string filePath)
    {
        StreamReader inputStream = new StreamReader(filePath);

        for (int i = 0; i < matrixLength; i++)
        {
            for (int j = 0; j < matrixWidth; j++)
            {
                stageTimeMatrix[0, j] = Convert.ToDouble(inputStream.ReadLine());
            }
        }
    }
    public double getMultiplier(string item, string material)
    {
        int arrayLength = (int)Enum.Parse(typeof(Item), item);
        int arrayWidth = (int)Enum.Parse(typeof(Material), material);

        return stageTimeMatrix[arrayLength, arrayWidth];
    }
}
