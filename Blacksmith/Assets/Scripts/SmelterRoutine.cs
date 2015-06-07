using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SmelterRoutine : MonoBehaviour 
{
    CraftRoutine craftingController;
    GameObject smelter;
    GameObject gameController;
    CreateInventory inventoryController;
    DataScript dataScript;
    const int numOreButtons = 10;
    const int numIngots = 10;

    bool isSmelting;
    string metalSmelting;
    GameObject smeltingSlider;
    double smelterTimer;
    double smelterTimerEnd;

    public Button[] oreButtons;

    private bool[] discoveredOres;
    private bool[] createdIngots;

    enum SmeltMats
    {
        Tin,
        Copper,
        Zinc,
        Iron,
        Charcoal,
        Chromium,
        Manganese,
        Cobalt,
        Tungsten,
        Titanium
    }

    void Start()
    {
        discoveredOres = new bool[numOreButtons] { false, false, false, false, false, false, false, false, false, false };
        createdIngots = new bool[numIngots] { false, false, false, false, false, false, false, false, false, false };
        discoveredOres[0] = true; // Initializes with Tin Ore discovered and all other ores undiscovered
        smelter = GameObject.Find("Smelter");
        gameController = GameObject.Find("GameController");
        smeltingSlider = GameObject.Find("Furnace Timer Gauge");
        smeltingSlider.SetActive(false);
        isSmelting = false;
        craftingController = GameObject.Find("CraftingController").GetComponent<CraftRoutine>();
    }

    void startSmelter(string metal)
    {
        smeltingSlider.SetActive(true);
        inventoryController.removeItem(metal + " Ore", 1);
        metalSmelting = metal;
        smelterTimer = 0;
        smelterTimerEnd = dataScript.getSmelterMult(metal);
        smeltingSlider.GetComponent<Slider>().maxValue = (float)smelterTimerEnd;
        smeltingSlider.GetComponent<Slider>().value = 0.0f;
        isSmelting = true;
    }

	void Update () 
    {
        if (smelterTimer < smelterTimerEnd)
        {
            endSmelting();
        }
        if (isSmelting)
        {
            smeltingSlider.GetComponent<Slider>().value = (float)smelterTimer;
            smelterTimer += Time.deltaTime;
        }
	}

    void endSmelting()
    {
        smeltingSlider.SetActive(false);
        isSmelting = false;
        inventoryController.addItem(metalSmelting + " Ingot", 1);
        if(!createdIngots[(int)Enum.Parse(typeof(SmeltMats), metalSmelting)])
        {
            craftingController.GetComponent<CraftRoutine>().enableNewIngot((int)Enum.Parse(typeof(SmeltMats), metalSmelting));
        }
    }

    public void checkForNewOres()
    {
        for (int i = 0; i < numOreButtons; i++)
        {
            if (!discoveredOres[i])
            {
                if (gameController.GetComponent<CreateInventory>().oreQty[i] > 0)
                {
                    discoveredOres[i] = true;
                }
            }
        }
    }

    public void selectSmeltingMaterial(string ore)
    {
        checkForNewOres();
    }
}
