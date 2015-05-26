using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarketConfirmYesNo : MonoBehaviour {

    private MarketRoutine marketRoutine;
    private GameObject confirmationBox;
    private GameController gameController;

	void Start () 
    {
        marketRoutine = GameObject.Find("GameController").GetComponent<MarketRoutine>();
        confirmationBox = GameObject.Find("Town/Market Canvas/Market Confirmation");
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        confirmationBox.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => selectYes());
        confirmationBox.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => selectNo());

	}

    public void selectYes()
    {
        Debug.Log("You have purchased " + marketRoutine.getCurrentPurhcaseItem() + " for " + marketRoutine.getCurrentPurchasePrice() + " gold");
        gameController.decGold(marketRoutine.getCurrentPurchasePrice());
        marketRoutine.updateGold();
        confirmationBox.SetActive(false);
    }

    public void selectNo()
    {
        Debug.Log("Purchase declined");
        confirmationBox.SetActive(false);
    }
}
