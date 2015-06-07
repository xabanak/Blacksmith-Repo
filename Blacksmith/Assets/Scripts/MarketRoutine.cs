using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarketRoutine : MonoBehaviour {

    public Canvas marketCanvas;
    public Text goldText;
    public Scrollbar marketScrollbar;
    public GameObject itemLine;
    public GameObject buyBackground;
    public GameObject sellBackground;
    public GameObject marketWindow;
    private GameObject tempObj;
    private CreateInventory createInventory;
    private GameController gameController;
    private int tier;
    private bool confirm;
    private string currentPurchaseItem;
    private int currentPurchasePrice;
    private string currentSellItem;
    private int currentSellPrice;
    private GameObject currentSellCraftedItem;

    public GameObject testSword;
    
    // TIER ONE MERCHANT ITEMS
    private string[] tierOneNames;
    private int[] tierOneCosts;
    private const int totalTierOneItems = 8;

    // TIER TWO MERCHANT ITEMS

    // TIER THREE MERCHANT ITEMS

    // TIER FOUR MERCHANT ITEMS

    // TIER FIVE MERCHANT ITEMS

	void Start () 
    {

        tier = 1;
        confirm = false;
        createInventory = GameObject.Find("Inventory/InventoryController").GetComponent<CreateInventory>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        tierOneNames = new string[totalTierOneItems];
        tierOneCosts = new int[totalTierOneItems];
        tierOneNames[0] = createInventory.oreName[0];
        tierOneNames[1] = createInventory.woodName[0];
        tierOneNames[2] = createInventory.skinName[0];
        tierOneNames[3] = createInventory.leatherStrapName[0];
        tierOneNames[4] = createInventory.leatherPaddingName[0];
        tierOneNames[5] = createInventory.sheathName[0];
        tierOneNames[6] = createInventory.hiltName[0];
        tierOneNames[7] = createInventory.handleName[0];
        tierOneCosts[0] = createInventory.oreCost[0];
        tierOneCosts[1] = createInventory.woodCost[0];
        tierOneCosts[2] = createInventory.skinCost[0];
        tierOneCosts[3] = createInventory.leatherStrapCost[0];
        tierOneCosts[4] = createInventory.leatherPaddingCost[0];
        tierOneCosts[5] = createInventory.sheathCost[0];
        tierOneCosts[6] = createInventory.hiltCost[0];
        tierOneCosts[7] = createInventory.handleCost[0];

        /*
        // TEST METHOD
        GameObject tempSword = Instantiate(testSword) as GameObject;
        tempSword.GetComponent<ItemScript>().SetItemStats("Tin", "Sword", "Good", 11);
        createInventory.addCraftedItem(tempSword);*/
	}
	
    public bool getConfirm()
    {
        return confirm;
    }

    public void setConfirm()
    {
        confirm = !confirm;
    }

    public void setCurrentPurchaseItem(string item)
    {
        currentPurchaseItem = item;
    }

    public string getCurrentPurchaseItem()
    {
        return currentPurchaseItem;
    }

    public void setCurrentPurchasePrice(int price)
    {
        currentPurchasePrice = price;
    }

    public int getCurrentPurchasePrice()
    {
        return currentPurchasePrice;
    }

    public void setCurrentSellItem(string item)
    {
        currentSellItem = item;
    }

    public string getCurrentSellItem()
    {
        return currentSellItem;
    }

    public void setCurrentSellPrice(int price)
    {
        currentSellPrice = price;
    }

    public int getCurrentSellPrice()
    {
        return currentSellPrice;
    }

    public void setCurrentSellCraftedItem(GameObject craftedItem)
    {
        currentSellCraftedItem = craftedItem;
    }

    public void clearCurrentSellCraftedItem()
    {
        currentSellCraftedItem = null;
    }

    public GameObject getCurrentSellCraftedItem()
    {
        return currentSellCraftedItem;
    }

    public void setMarketWindow()
    {
        clearMarket();
        buildBuyList();
        buildSellList();
        updateGold();
    }

    public void buildBuyList()
    {
        int totalItems = 0;
        totalItems += totalTierOneItems;

        for (int i = 0; i < totalItems; i++)
        {
            tempObj = Instantiate(itemLine, buyBackground.transform.position, Quaternion.identity) as GameObject;
            tempObj.transform.SetParent(buyBackground.transform);
            tempObj.transform.localScale = new Vector3(1, 1, 1);
            tempObj.name = tierOneNames[i];
            tempObj.AddComponent<ConfirmPurchase>();
            tempObj.transform.GetChild(0).GetComponent<Text>().text = tierOneNames[i];
            tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + tierOneCosts[i] + " gold";
        }

        for (int i = totalItems; i < 19; i++)
        {
            tempObj = Instantiate(itemLine, buyBackground.transform.position, Quaternion.identity) as GameObject;
            tempObj.transform.SetParent(buyBackground.transform);
            tempObj.transform.localScale = new Vector3(1, 1, 1);
            tempObj.transform.GetChild(0).GetComponent<Text>().text = "";
            tempObj.transform.GetChild(1).GetComponent<Text>().text = "";
        }
    }

    public void buildSellList()
    {
        int totalItems = 0;

        // ADD IN WEAPON GAME OBJECTS
        for (int i = 0; i < createInventory.getItemType("sword").GetCurrentSize(); i++)
        {
            addSellLine(createInventory.getItemType("sword").GetItem(i).GetComponent<ItemScript>().GetItemDescription(), 0, createInventory.getItemType("sword").GetItem(i));
            totalItems++;
        }

        for (int i = 0; i < createInventory.getConstantSize("fuel"); i++)
        {
            if (createInventory.fuelQty[i] > 0)
            {
                addSellLine(createInventory.fuelName[i], createInventory.fuelQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("ore"); i++)
        {
            if (createInventory.oreQty[i] > 0)
            {
                addSellLine(createInventory.oreName[i], createInventory.oreQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("ingot"); i++)
        {
            if (createInventory.ingotQty[i] > 0)
            {
                addSellLine(createInventory.ingotName[i], createInventory.ingotQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("skin"); i++)
        {
            if (createInventory.skinQty[i] > 0)
            {
                addSellLine(createInventory.skinName[i], createInventory.skinQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("leather"); i++)
        {
            if (createInventory.leatherQty[i] > 0)
            {
                addSellLine(createInventory.leatherName[i], createInventory.leatherQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("gem"); i++)
        {
            if (createInventory.gemQty[i] > 0)
            {
                addSellLine(createInventory.gemName[i], createInventory.gemQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("gemstone"); i++)
        {
            if (createInventory.gemstoneQty[i] > 0)
            {
                addSellLine(createInventory.gemstoneName[i], createInventory.gemstoneQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("wood"); i++)
        {
            if (createInventory.woodQty[i] > 0)
            {
                addSellLine(createInventory.woodName[i], createInventory.woodQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("lumber"); i++)
        {
            if (createInventory.lumberQty[i] > 0)
            {
                addSellLine(createInventory.lumberName[i], createInventory.lumberQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("leather strap"); i++)
        {
            if (createInventory.leatherStrapQty[i] > 0)
            {
                addSellLine(createInventory.leatherStrapName[i], createInventory.leatherStrapQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("leather padding"); i++)
        {
            if (createInventory.leatherPaddingQty[i] > 0)
            {
                addSellLine(createInventory.leatherPaddingName[i], createInventory.leatherPaddingQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("hilt"); i++)
        {
            if (createInventory.hiltQty[i] > 0)
            {
                addSellLine(createInventory.hiltName[i], createInventory.hiltQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("sheath"); i++)
        {
            if (createInventory.sheathQty[i] > 0)
            {
                addSellLine(createInventory.sheathName[i], createInventory.sheathQty[i]);
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("handle"); i++)
        {
            if (createInventory.handleQty[i] > 0)
            {
                addSellLine(createInventory.handleName[i], createInventory.handleQty[i]);
                totalItems++;
            }
        }

        for (int i = totalItems; i < 19; i++)
        {
            tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
            tempObj.transform.SetParent(sellBackground.transform);
            tempObj.transform.localScale = new Vector3(1, 1, 1);
            if (i == 0)
            {
                tempObj.transform.GetChild(0).GetComponent<Text>().text = "You current have no items.";
            }
            else
            {
                tempObj.transform.GetChild(0).GetComponent<Text>().text = "";
            }
            tempObj.transform.GetChild(1).GetComponent<Text>().text = "";
        }
    }

    public void toggleBuyWindow()
    {
        buyBackground.SetActive(true);
        sellBackground.SetActive(false);
        marketWindow.GetComponent<ScrollRect>().content = buyBackground.GetComponent<RectTransform>();
        resetScrollbarValue();
    }

    public void toggleSellWindow()
    {
        sellBackground.SetActive(true);
        buyBackground.SetActive(false);
        marketWindow.GetComponent<ScrollRect>().content = sellBackground.GetComponent<RectTransform>();
        resetScrollbarValue();
    }

    public void resetScrollbarValue()
    {
        Canvas.ForceUpdateCanvases();
        marketWindow.GetComponent<ScrollRect>().verticalScrollbar.value = 0.0f;
        Canvas.ForceUpdateCanvases();
        marketWindow.GetComponent<ScrollRect>().verticalScrollbar.value = 1f;
    }

    public void updateGold()
    {
        goldText.text = gameController.getGold() + " gold";
    }

    private void clearMarket()
    {
        foreach(Transform child in buyBackground.transform)
        {
            Destroy(child.gameObject);
        }

        foreach(Transform child in sellBackground.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void addSellLine(string item, int qty)
    {
        tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
        tempObj.transform.SetParent(sellBackground.transform);
        tempObj.transform.localScale = new Vector3(1, 1, 1);
        tempObj.name = item;
        tempObj.AddComponent<ConfirmSell>();
        tempObj.transform.GetChild(0).GetComponent<Text>().text = item;
        tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + qty;
    }

    private void addSellLine(string item, int qty, GameObject type)
    {
        tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
        tempObj.transform.SetParent(sellBackground.transform);
        tempObj.transform.localScale = new Vector3(1, 1, 1);
        tempObj.name = item;
        tempObj.AddComponent<ConfirmSell>();
        tempObj.AddComponent<SellItem>();
        tempObj.GetComponent<SellItem>().setCraftedItem(type);
        tempObj.transform.GetChild(0).GetComponent<Text>().text = item;
        tempObj.transform.GetChild(1).GetComponent<Text>().text = "";
    }
}
