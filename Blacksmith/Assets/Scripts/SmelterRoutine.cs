using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SmelterRoutine : MonoBehaviour 
{
    GameObject smelter;
    GameController gameController;
    CreateInventory inventoryController;
    DataScript dataScript;

    bool isSmelting;
    string metalSmelting;
    GameObject smeltingSlider;
    double smelterTimer;
    double smelterTimerEnd;

    public Button[] oreButtons;

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

	void Start () 
    {
        smelter = GameObject.Find("Smelter");
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        //inventoryController = gameController.transform.parent.GetComponent<CreateInventory>();
        //dataScript = gameController.transform.parent.GetComponent<DataScript>();
        smeltingSlider = GameObject.Find("Furnace Timer Gauge");
        smeltingSlider.SetActive(false);
        isSmelting = false;
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
        inventoryController.addItem(metalSmelting + " Ore", 1);
    }

    public void enableOre(string ore)
    {
        oreButtons[(int)Enum.Parse(typeof(SmeltMats), ore)].interactable = true;
    }

    public void selectSmeltingMaterial(string ore)
    {
        
    }
}
