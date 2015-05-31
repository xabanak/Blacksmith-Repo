using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarketConfirmYesNo : MonoBehaviour {

    private MarketRoutine marketRoutine;
    public GameObject confirmationBox;
    private GameController gameController;
    private CreateInventory createInventory;

	void Start () 
    {
        marketRoutine = GameObject.Find("GameController").GetComponent<MarketRoutine>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        createInventory = GameObject.Find("Inventory/InventoryController").GetComponent<CreateInventory>();

        confirmationBox = this.gameObject;

        if (name == "Market Confirmation Buy")
        {
            confirmationBox.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => selectYesBuy());
        }
        else if (name == "Market Confirmation Sell")
        {
            confirmationBox.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => selectYesSell());
        }

        confirmationBox.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => selectNo());

	}

    public void selectYesBuy()
    {
        if (gameController.decGold(marketRoutine.getCurrentPurchasePrice()))
        {
            Debug.Log("You have purchased " + marketRoutine.getCurrentPurchaseItem() + " for " + marketRoutine.getCurrentPurchasePrice() + " gold");
            marketRoutine.updateGold();
            createInventory.addItem(marketRoutine.getCurrentPurchaseItem(), 1);
            marketRoutine.setMarketWindow();
        }
        else
        {
            Debug.Log("Insufficient gold to purchase");
        }

        confirmationBox.SetActive(false);
    }

    public void selectYesSell()
    {
        gameController.incGold(marketRoutine.getCurrentSellPrice());
        Debug.Log("You have sold " + marketRoutine.getCurrentSellItem() + " for " + marketRoutine.getCurrentSellPrice() + " gold");
        marketRoutine.updateGold();
        if (marketRoutine.getCurrentSellCraftedItem() != null)
        {
            createInventory.deleteCraftedItem(marketRoutine.getCurrentSellCraftedItem());
            Debug.Log("Sell Crafted Item");
            marketRoutine.setCurrentSellCraftedItem(null);
        }
        else
        {
            createInventory.removeItem(marketRoutine.getCurrentSellItem(), 1);
            Debug.Log("Sell Basic Item");
        }
        marketRoutine.setMarketWindow();

        confirmationBox.SetActive(false);
    }

    public void selectNo()
    {
        Debug.Log("Purchase declined");
        confirmationBox.SetActive(false);
    }
}
