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
    private string[] tierTwoNames;
    private int[] tierTwoCosts;
    private const int totalTierTwoItems = 3;

    // TIER THREE MERCHANT ITEMS
    private string[] tierThreeNames;
    private int[] tierThreeCosts;
    private const int totalTierThreeItems = 8;

    // TIER FOUR MERCHANT ITEMS
    private string[] tierFourNames;
    private int[] tierFourCosts;
    private const int totalTierFourItems = 3;

    // TIER FIVE MERCHANT ITEMS
    private string[] tierFiveNames;
    private int[] tierFiveCosts;
    private const int totalTierFiveItems = 8;

    // TIER SIX MERCHANT ITEMS
    private string[] tierSixNames;
    private int[] tierSixCosts;
    private const int totalTierSixItems = 3;

    // TIER SEVEN MERCHANT ITEMS
    private string[] tierSevenNames;
    private int[] tierSevenCosts;
    private const int totalTierSevenItems = 8;

    // TIER EIGHT MERCHANT ITEMS
    private string[] tierEightNames;
    private int[] tierEightCosts;
    private const int totalTierEightItems = 3;

    // TIER NINE MERCHANT ITEMS
    private string[] tierNineNames;
    private int[] tierNineCosts;
    private const int totalTierNineItems = 8;

    // TIER TEN MERCHANT ITEMS
    private string[] tierTenNames;
    private int[] tierTenCosts;
    private const int totalTierTenItems = 3;

	void Start () 
    {

        tier = 1;
        confirm = false;
        createInventory = GameObject.Find("Inventory/InventoryController").GetComponent<CreateInventory>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        // TIER ONE DATA GATHER
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

        // TIER TWO DATA GATHER
        tierTwoNames = new string[totalTierTwoItems];
        tierTwoCosts = new int[totalTierTwoItems];
        tierTwoNames[0] = createInventory.oreName[1];
        tierTwoNames[1] = createInventory.woodName[1];
        tierTwoNames[2] = createInventory.skinName[1];
        tierTwoCosts[0] = createInventory.oreCost[1];
        tierTwoCosts[1] = createInventory.woodCost[1];
        tierTwoCosts[2] = createInventory.skinCost[1];

        // TIER THREE DATA GATHER
        tierThreeNames = new string[totalTierThreeItems];
        tierThreeCosts = new int[totalTierThreeItems];
        tierThreeNames[0] = createInventory.oreName[2];
        tierThreeNames[1] = createInventory.woodName[2];
        tierThreeNames[2] = createInventory.skinName[2];
        tierThreeNames[3] = createInventory.leatherStrapName[1];
        tierThreeNames[4] = createInventory.leatherPaddingName[1];
        tierThreeNames[5] = createInventory.sheathName[1];
        tierThreeNames[6] = createInventory.hiltName[1];
        tierThreeNames[7] = createInventory.handleName[1];
        tierThreeCosts[0] = createInventory.oreCost[2];
        tierThreeCosts[1] = createInventory.woodCost[2];
        tierThreeCosts[2] = createInventory.skinCost[2];
        tierThreeCosts[3] = createInventory.leatherStrapCost[1];
        tierThreeCosts[4] = createInventory.leatherPaddingCost[1];
        tierThreeCosts[5] = createInventory.sheathCost[1];
        tierThreeCosts[6] = createInventory.hiltCost[1];
        tierThreeCosts[7] = createInventory.handleCost[1];

        // TIER FOUR DATA GATHER
        tierFourNames = new string[totalTierFourItems];
        tierFourCosts = new int[totalTierFourItems];
        tierFourNames[0] = createInventory.oreName[3];
        tierFourNames[1] = createInventory.woodName[3];
        tierFourNames[2] = createInventory.skinName[3];
        tierFourCosts[0] = createInventory.oreCost[3];
        tierFourCosts[1] = createInventory.woodCost[3];
        tierFourCosts[2] = createInventory.skinCost[3];

        // TIER FIVE DATA GATHER
        tierFiveNames = new string[totalTierFiveItems];
        tierFiveCosts = new int[totalTierFiveItems];
        tierFiveNames[0] = createInventory.oreName[4];
        tierFiveNames[1] = createInventory.woodName[4];
        tierFiveNames[2] = createInventory.skinName[4];
        tierFiveNames[3] = createInventory.leatherStrapName[2];
        tierFiveNames[4] = createInventory.leatherPaddingName[2];
        tierFiveNames[5] = createInventory.sheathName[2];
        tierFiveNames[6] = createInventory.hiltName[2];
        tierFiveNames[7] = createInventory.handleName[2];
        tierFiveCosts[0] = createInventory.oreCost[4];
        tierFiveCosts[1] = createInventory.woodCost[4];
        tierFiveCosts[2] = createInventory.skinCost[4];
        tierFiveCosts[3] = createInventory.leatherStrapCost[2];
        tierFiveCosts[4] = createInventory.leatherPaddingCost[2];
        tierFiveCosts[5] = createInventory.sheathCost[2];
        tierFiveCosts[6] = createInventory.hiltCost[2];
        tierFiveCosts[7] = createInventory.handleCost[2];

        // TIER SIX DATA GATHER
        tierSixNames = new string[totalTierSixItems];
        tierSixCosts = new int[totalTierSixItems];
        tierSixNames[0] = createInventory.oreName[5];
        tierSixNames[1] = createInventory.woodName[5];
        tierSixNames[2] = createInventory.skinName[5];
        tierSixCosts[0] = createInventory.oreCost[5];
        tierSixCosts[1] = createInventory.woodCost[5];
        tierSixCosts[2] = createInventory.skinCost[5];

        // TIER SEVEN DATA GATHER
        tierSevenNames = new string[totalTierSevenItems];
        tierSevenCosts = new int[totalTierSevenItems];
        tierSevenNames[0] = createInventory.oreName[6];
        tierSevenNames[1] = createInventory.woodName[6];
        tierSevenNames[2] = createInventory.skinName[6];
        tierSevenNames[3] = createInventory.leatherStrapName[3];
        tierSevenNames[4] = createInventory.leatherPaddingName[3];
        tierSevenNames[5] = createInventory.sheathName[3];
        tierSevenNames[6] = createInventory.hiltName[3];
        tierSevenNames[7] = createInventory.handleName[3];
        tierSevenCosts[0] = createInventory.oreCost[6];
        tierSevenCosts[1] = createInventory.woodCost[6];
        tierSevenCosts[2] = createInventory.skinCost[6];
        tierSevenCosts[3] = createInventory.leatherStrapCost[3];
        tierSevenCosts[4] = createInventory.leatherPaddingCost[3];
        tierSevenCosts[5] = createInventory.sheathCost[3];
        tierSevenCosts[6] = createInventory.hiltCost[3];
        tierSevenCosts[7] = createInventory.handleCost[3];

        // TIER EIGHT DATA GATHER
        tierEightNames = new string[totalTierEightItems];
        tierEightCosts = new int[totalTierEightItems];
        tierEightNames[0] = createInventory.oreName[7];
        tierEightNames[1] = createInventory.woodName[7];
        tierEightNames[2] = createInventory.skinName[7];
        tierEightCosts[0] = createInventory.oreCost[7];
        tierEightCosts[1] = createInventory.woodCost[7];
        tierEightCosts[2] = createInventory.skinCost[7];

        // TIER NINE DATA GATHER
        tierNineNames = new string[totalTierNineItems];
        tierNineCosts = new int[totalTierNineItems];
        tierNineNames[0] = createInventory.oreName[8];
        tierNineNames[1] = createInventory.woodName[8];
        tierNineNames[2] = createInventory.skinName[8];
        tierNineNames[3] = createInventory.leatherStrapName[4];
        tierNineNames[4] = createInventory.leatherPaddingName[4];
        tierNineNames[5] = createInventory.sheathName[4];
        tierNineNames[6] = createInventory.hiltName[4];
        tierNineNames[7] = createInventory.handleName[4];
        tierNineCosts[0] = createInventory.oreCost[8];
        tierNineCosts[1] = createInventory.woodCost[8];
        tierNineCosts[2] = createInventory.skinCost[8];
        tierNineCosts[3] = createInventory.leatherStrapCost[4];
        tierNineCosts[4] = createInventory.leatherPaddingCost[4];
        tierNineCosts[5] = createInventory.sheathCost[4];
        tierNineCosts[6] = createInventory.hiltCost[4];
        tierNineCosts[7] = createInventory.handleCost[4];

        // TIER TEN DATA GATHER
        tierTenNames = new string[totalTierTenItems];
        tierTenCosts = new int[totalTierTenItems];
        tierTenNames[0] = createInventory.oreName[9];
        tierTenNames[1] = createInventory.woodName[9];
        tierTenNames[2] = createInventory.skinName[9];
        tierTenCosts[0] = createInventory.oreCost[9];
        tierTenCosts[1] = createInventory.woodCost[9];
        tierTenCosts[2] = createInventory.skinCost[9];

        
        // TEST METHOD
        /*GameObject tempSword = Instantiate(testSword) as GameObject;
        tempSword.GetComponent<ItemScript>().SetItemStats("Tin", "Sword", "Good", 110);
        createInventory.addCraftedItem(tempSword);
        GameObject tempSword1 = Instantiate(testSword) as GameObject;
        tempSword1.GetComponent<ItemScript>().SetItemStats("Tin", "Sword", "Good", 110);
        createInventory.addCraftedItem(tempSword1);
        GameObject tempSword2 = Instantiate(testSword) as GameObject;
        tempSword2.GetComponent<ItemScript>().SetItemStats("Tin", "Sword", "Good", 110);
        createInventory.addCraftedItem(tempSword2);*/
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

        for (int i = 0; i < totalTierOneItems; i++)
        {
            addBuyLine(tierOneNames, tierOneCosts, i);
        }

        if (gameController.checkProgression(2))
        {
            totalItems += totalTierTwoItems;
            for (int i = 0; i < totalTierTwoItems; i++)
            {
                addBuyLine(tierTwoNames, tierTwoCosts, i);
            }
        }

        if (gameController.checkProgression(3))
        {
            totalItems += totalTierThreeItems;
            for (int i = 0; i < totalTierThreeItems; i++)
            {
                addBuyLine(tierThreeNames, tierThreeCosts, i);
            }
        }

        if (gameController.checkProgression(4))
        {
            totalItems += totalTierFourItems;
            for (int i = 0; i < totalTierFourItems; i++)
            {
                addBuyLine(tierFourNames, tierFourCosts, i);
            }
        }

        if (gameController.checkProgression(5))
        {
            totalItems += totalTierFiveItems;
            for (int i = 0; i < totalTierFiveItems; i++)
            {
                addBuyLine(tierFiveNames, tierFiveCosts, i);
            }
        }

        if (gameController.checkProgression(6))
        {
            totalItems += totalTierSixItems;
            for (int i = 0; i < totalTierSixItems; i++)
            {
                addBuyLine(tierSixNames, tierSixCosts, i);
            }
        }

        if (gameController.checkProgression(7))
        {
            totalItems += totalTierSevenItems;
            for (int i = 0; i < totalTierSevenItems; i++)
            {
                addBuyLine(tierSevenNames, tierSevenCosts, i);
            }
        }

        if (gameController.checkProgression(8))
        {
            totalItems += totalTierEightItems;
            for (int i = 0; i < totalTierEightItems; i++)
            {
                addBuyLine(tierEightNames, tierEightCosts, i);
            }
        }

        if (gameController.checkProgression(9))
        {
            totalItems += totalTierNineItems;
            for (int i = 0; i < totalTierNineItems; i++)
            {
                addBuyLine(tierNineNames, tierNineCosts, i);
            }
        }

        if (gameController.checkProgression(10))
        {
            totalItems += totalTierTenItems;
            for (int i = 0; i < totalTierTenItems; i++)
            {
                addBuyLine(tierTenNames, tierTenCosts, i);
            }
        }

        for (int i = totalItems; i < 19; i++)
        {
            tempObj = Instantiate(itemLine, buyBackground.transform.position, Quaternion.identity) as GameObject;
            tempObj.transform.SetParent(buyBackground.transform);
            tempObj.transform.localScale = new Vector3(1, 1, 1);
            tempObj.transform.GetChild(0).GetComponent<Text>().text = "";
            tempObj.transform.GetChild(1).GetComponent<Text>().text = "";
            Destroy(tempObj.GetComponent<Highlighter>());
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
            Destroy(tempObj.GetComponent<Highlighter>());
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

    private void addBuyLine(string[] names, int[] cost, int index)
    {
        tempObj = Instantiate(itemLine, buyBackground.transform.position, Quaternion.identity) as GameObject;
        tempObj.transform.SetParent(buyBackground.transform);
        tempObj.transform.localScale = new Vector3(1, 1, 1);
        tempObj.name = names[index];
        tempObj.AddComponent<ConfirmPurchase>();
        tempObj.transform.GetChild(0).GetComponent<Text>().text = names[index];
        tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + cost[index] + " gold";
    }
}
