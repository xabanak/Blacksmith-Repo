using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarketConfirmYesNo : MonoBehaviour {

    private MarketRoutine marketRoutine;
    private GameObject confirmationBox;
    private GameController gameController;
    private CreateInventory createInventory;

	void Start () 
    {
        marketRoutine = GameObject.Find("GameController").GetComponent<MarketRoutine>();
        confirmationBox = GameObject.Find("Town/Market Canvas/Market Confirmation");
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        createInventory = GameObject.Find("Inventory/InventoryController").GetComponent<CreateInventory>();
        confirmationBox.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => selectYes());
        confirmationBox.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => selectNo());

	}

    public void selectYes()
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

    public void selectNo()
    {
        Debug.Log("Purchase declined");
        confirmationBox.SetActive(false);
    }
}
