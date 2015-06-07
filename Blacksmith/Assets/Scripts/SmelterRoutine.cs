using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	void Start () 
    {
        smelter = GameObject.Find("Smelter");
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        inventoryController = gameController.transform.parent.gameObject.GetComponent<CreateInventory>();
        dataScript = gameController.transform.parent.gameObject.GetComponent<DataScript>();
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
}
