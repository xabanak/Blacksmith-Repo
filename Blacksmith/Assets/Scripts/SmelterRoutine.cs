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
    const double baseSmelterTime = 60.0f;

    bool isSmelting;
    string metalSmelting;
    GameObject smeltingSlider;
    double smelterTimer;
    double smelterTimerEnd;

    bool smelterWindowOpen;

    public Button[] oreButtons;
    public Sprite[] oreButtonImages;

    private bool[] discoveredOres;
    private bool[] createdIngots;
    private bool[] activeOreButtons;

    public Canvas smeltingCanvas;
    public GameObject smeltingWindow;
    public Button smeltButton;
    public Button cancelButton;
    public Text requiredMat1;
    public Text requiredMat2;
    public Text ingotName;
    public Camera standbyCamera;
    public Camera workshopCamera;
    public GameObject oreButton;
    public GameObject startCraftingButton;
    public GameObject changeRoomButton;

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

    enum IngotTypes
    {
        Tin,
        Copper,
        Bronze,
        Brass,
        Iron,
        BlackenedIron,
        Steel,
        SteelAlloyl1,
        SteelAlloyl2,
        Titanium
    }

    void Start()
    {
        discoveredOres = new bool[numOreButtons] { false, false, false, false, false, false, false, false, false, false };
        createdIngots = new bool[numIngots] { false, false, false, false, false, false, false, false, false, false };
        discoveredOres[0] = true; // Initializes with Tin Ore discovered and all other ores undiscovered
        smelter = GameObject.Find("Smelter");
        gameController = GameObject.Find("GameController");
        dataScript = gameController.GetComponent<DataScript>();
        inventoryController = GameObject.Find("InventoryController").GetComponent<CreateInventory>();
        smeltingSlider = GameObject.Find("Furnace Timer Gauge");
        smeltingSlider.SetActive(false);
        isSmelting = false;
        craftingController = GameObject.Find("CraftingController").GetComponent<CraftRoutine>();
        activeOreButtons = new bool[numOreButtons] { false, false, false, false, false, false, false, false, false, false };
        smelterWindowOpen = false;
        smeltingCanvas.worldCamera = standbyCamera;
        oreButton.SetActive(false);

        //startSmelter("Tin");
    }

    public void startSmelter()
    {
        smeltingSlider.SetActive(true);
        switch(metalSmelting)
        { 
            case "Tin":
                inventoryController.removeItem("Tin Ore", 5);
                break;
            case "Copper":
                inventoryController.removeItem("Copper Ore", 5);
                break;
            case "Bronze":
                inventoryController.removeItem("Copper Ore", 9);
                inventoryController.removeItem("Tin Ore", 1);
                break;
            case "Brass":
                inventoryController.removeItem("Copper Ore", 9);
                inventoryController.removeItem("Zinc Ore", 1);
                break;
        }
        smelterTimer = 0;
        smelterTimerEnd = baseSmelterTime * dataScript.getSmelterMult(metalSmelting);
        smeltingSlider.GetComponent<Slider>().maxValue = (float)smelterTimerEnd;
        smeltingSlider.GetComponent<Slider>().value = 0.0f;
        isSmelting = true;
        closeSmeltingInterface();
    }

    void OnMouseUp()
    {
        if (craftingController.isCrafting())
        {
            return;
        }
        //Debug.Log("OnMouseUp");
        if (smeltingCanvas.worldCamera == standbyCamera)
        {
            openSmeltingInterface();
        }
        else
        {
            closeSmeltingInterface();
        }
    }

	void Update () 
    {
        if (isSmelting)
        {
            if (smelterTimer > smelterTimerEnd)
            {
                endSmelting();
            }
            smeltingSlider.GetComponent<Slider>().value = (float)smelterTimer;
            smelterTimer += Time.deltaTime;
        }
	}

    void endSmelting()
    {
        smeltingSlider.SetActive(false);
        isSmelting = false;
        int ingotQty;
        if (metalSmelting == "Brass" || metalSmelting == "Bronze")
        {
            ingotQty = 2;
        }
        else
        {
            ingotQty = 1;
        }
        inventoryController.addItem(metalSmelting + " Ingot", ingotQty);
        if(!createdIngots[(int)Enum.Parse(typeof(IngotTypes), metalSmelting)])
        {
            craftingController.GetComponent<CraftRoutine>().enableNewIngot((int)Enum.Parse(typeof(IngotTypes), metalSmelting));
        }
    }

    public void checkForNewOres()
    {
        for (int i = 0; i < numOreButtons; i++)
        {
            if (!discoveredOres[i])
            {
                if (inventoryController.oreQty[i] > 0)
                {
                    discoveredOres[i] = true;
                    oreButtons[i].image.overrideSprite = oreButtonImages[i];
                    oreButtons[i].interactable = true;  
                }

            }
        }
    }

    private void openSmeltingInterface()
    {
        if (isSmelting)
        {
            return;
        }
        checkForNewOres();
        startCraftingButton.SetActive(false);
        changeRoomButton.SetActive(false);
        //Debug.Log("Opening smelter interface");
        smeltingCanvas.worldCamera = workshopCamera;
        oreButton.SetActive(true);
    }

    private void closeSmeltingInterface()
    {

        oreButton.SetActive(false);
        if (smeltingWindow.activeSelf == true)
        {
            closeSmelterWindow();
        }
        smeltingCanvas.worldCamera = standbyCamera;
        startCraftingButton.SetActive(true);
        changeRoomButton.SetActive(true);
        for (int i = 0; i < numOreButtons; i++)
        {
            if (activeOreButtons[i] == true)
            {
                activeOreButtons[i] = false;
            }
        }
    }

    public void toggleOreButton(string ore)
    {
        activeOreButtons[(int)Enum.Parse(typeof(SmeltMats), ore)] = !activeOreButtons[(int)Enum.Parse(typeof(SmeltMats), ore)];
        
        updateSmelterWindow();
    }

    private void updateSmelterWindow()
    {
        if (activeOreButtons[0] || activeOreButtons[1] || activeOreButtons[2])
        {
            if (!smelterWindowOpen)
            {
                openSmelterWindow();
            }
        }
        if (!activeOreButtons[0] && !activeOreButtons[1] && !activeOreButtons[2]) // Closing window
        {
            closeSmelterWindow();
        }
        else if (activeOreButtons[0] && !activeOreButtons[1] && !activeOreButtons[2]) // Tin Selected
        {
            metalSmelting = "Tin";
            ingotName.text = "Tin Ingot";
            requiredMat1.text = "Tin Ore X 5";
            requiredMat2.text = "";
            if (inventoryController.getQuantity("Tin Ore") >= 5)
            {
                smeltButton.interactable = true;
            }
            else
            {
                smeltButton.interactable = false;
            }
        }
        else if (activeOreButtons[0] && activeOreButtons[1] && !activeOreButtons[2]) // Tin and Copper selected
        {
            metalSmelting = "Bronze";
            ingotName.text = "Bronze Ingot";
            requiredMat1.text = "Tin Ore X 1";
            requiredMat2.text = "Copper Ore X 9";
            if (inventoryController.getQuantity("Tin Ore") >= 1 && inventoryController.getQuantity("Copper Ore") >= 9)
            {
                smeltButton.interactable = true;
            }
            else
            {
                smeltButton.interactable = false;
            }
        }
        else if (!activeOreButtons[0] && activeOreButtons[1] && !activeOreButtons[2]) // Copper selected
        {
            metalSmelting = "Copper";
            ingotName.text = "Copper Ingot";
            requiredMat1.text = "Copper Ore X 5";
            requiredMat2.text = "";
            if (inventoryController.getQuantity("Copper Ore") >= 5)
            {
                smeltButton.interactable = true;
            }
            else
            {
                smeltButton.interactable = false;
            }
        }
        else if (!activeOreButtons[0] && activeOreButtons[1] && activeOreButtons[2]) // Copper and Zinc selected
        {
            metalSmelting = "Brass";
            ingotName.text = "Brass Ingot";
            requiredMat1.text = "Copper Ore X 9";
            requiredMat2.text = "Zinc Ore X 1";
            if (inventoryController.getQuantity("Zinc Ore") >= 1 && inventoryController.getQuantity("Copper Ore") >= 9)
            {
                smeltButton.interactable = true;
            }
            else
            {
                smeltButton.interactable = false;
            }
        }
        else // No Combination 
        {
            ingotName.text = "No combination";
            requiredMat1.text = "";
            requiredMat2.text = "";
            smeltButton.interactable = false;
        }
    }

    public void cancelButtonPress()
    {
        closeSmeltingInterface();
    }

    private void openSmelterWindow()
    {
        smeltingWindow.SetActive(true);
        smelterWindowOpen = true;
    }

    private void closeSmelterWindow()
    {
        smeltingWindow.SetActive(false);
        smelterWindowOpen = false;
    }

    public void selectSmeltingMaterial(string ore)
    {
        checkForNewOres();
    }
}
