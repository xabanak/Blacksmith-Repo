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

    public string getCurrentPurhcaseItem()
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


    public void setMarketWindow()
    {
        buildBuyList();
        buildSellList();
        updateGold();
    }

    public void buildBuyList()
    {
        int totalItems = 0;
        totalItems = 8;

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

        for (int i = 0; i < createInventory.getConstantSize("fuel"); i++)
        {
            if (createInventory.fuelQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.fuelName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.fuelQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("ore"); i++)
        {
            if (createInventory.oreQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.oreName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.oreQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("ingot"); i++)
        {
            if (createInventory.ingotQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.ingotName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.ingotQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("skin"); i++)
        {
            if (createInventory.skinQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.skinName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.skinQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("leather"); i++)
        {
            if (createInventory.leatherQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.leatherName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.leatherQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("gem"); i++)
        {
            if (createInventory.gemQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.gemName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.gemQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("gemstone"); i++)
        {
            if (createInventory.gemstoneQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.gemstoneName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.gemstoneQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("wood"); i++)
        {
            if (createInventory.woodQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.woodName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.woodQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("lumber"); i++)
        {
            if (createInventory.oreQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.lumberName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.lumberQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("leather strap"); i++)
        {
            if (createInventory.leatherStrapQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.leatherStrapName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.leatherStrapQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("leather padding"); i++)
        {
            if (createInventory.leatherPaddingQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.leatherPaddingName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.leatherPaddingQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("hilt"); i++)
        {
            if (createInventory.hiltQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.hiltName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.hiltQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("sheath"); i++)
        {
            if (createInventory.sheathQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.sheathName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.sheathQty[i];
                totalItems++;
            }
        }

        for (int i = 0; i < createInventory.getConstantSize("handle"); i++)
        {
            if (createInventory.handleQty[i] > 0)
            {
                tempObj = Instantiate(itemLine, sellBackground.transform.position, Quaternion.identity) as GameObject;
                tempObj.transform.SetParent(sellBackground.transform);
                tempObj.transform.localScale = new Vector3(1, 1, 1);
                tempObj.transform.GetChild(0).GetComponent<Text>().text = createInventory.handleName[i];
                tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + createInventory.handleQty[i];
                totalItems++;
            }
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
}
