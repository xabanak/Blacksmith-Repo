using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConfirmSell : MonoBehaviour {

    private int itemCost;
    private string itemName;
    private CreateInventory createInventory;
    private MarketRoutine marketRoutine;
    private GameController gameController;
    public GameObject confirmationBox;
    public Text confirmationText;


    // Use this for initialization
    void Start()
    {
        createInventory = GameObject.Find("Inventory/InventoryController").GetComponent<CreateInventory>();
        marketRoutine = GameObject.Find("GameController").GetComponent<MarketRoutine>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        itemName = gameObject.name;
        confirmationBox = GameObject.Find("Town/Market Canvas/Market Confirmation Sell");
    }

    public void OnMouseUp()
    {
        if (!confirmationBox.activeSelf)
        {
            Debug.Log(name);
            switch (name)
            {
                case "Basic Fuel":
                    itemCost = createInventory.fuelCost[0];
                    break;
                case "Standard Fuel":
                    itemCost = createInventory.fuelCost[1];
                    break;
                case "Good Fuel":
                    itemCost = createInventory.fuelCost[2];
                    break;
                case "Excellent Fuel":
                    itemCost = createInventory.fuelCost[3];
                    break;
                case "Expert Fuel":
                    itemCost = createInventory.fuelCost[4];
                    break;
                case "Tin Ore":
                    itemCost = createInventory.oreCost[0];
                    break;
                case "Copper Ore":
                    itemCost = createInventory.oreCost[1];
                    break;
                case "Zinc Ore":
                    itemCost = createInventory.oreCost[2];
                    break;
                case "Iron Ore":
                    itemCost = createInventory.oreCost[3];
                    break;
                case "Black Ore":
                    itemCost = createInventory.oreCost[4];
                    break;
                case "Nickel Ore":
                    itemCost = createInventory.oreCost[5];
                    break;
                case "Carbon Ore":
                    itemCost = createInventory.oreCost[6];
                    break;
                case "Manganese Ore":
                    itemCost = createInventory.oreCost[7];
                    break;
                case "Chromium Ore":
                    itemCost = createInventory.oreCost[8];
                    break;
                case "Dragon Ore":
                    itemCost = createInventory.oreCost[9];
                    break;
                case "Tin Ingot":
                    itemCost = createInventory.ingotCost[0];
                    break;
                case "Copper Ingot":
                    itemCost = createInventory.ingotCost[1];
                    break;
                case "Bronze Ingot":
                    itemCost = createInventory.ingotCost[2];
                    break;
                case "Brass Ingot":
                    itemCost = createInventory.ingotCost[3];
                    break;
                case "Iron Ingot":
                    itemCost = createInventory.ingotCost[4];
                    break;
                case "Blackened Iron Ingot":
                    itemCost = createInventory.ingotCost[5];
                    break;
                case "Steel Ingot":
                    itemCost = createInventory.ingotCost[6];
                    break;
                case "Low Grade Steel Alloy Ingot":
                    itemCost = createInventory.ingotCost[7];
                    break;
                case "High Grade Steel Alloy Ingot":
                    itemCost = createInventory.ingotCost[8];
                    break;
                case "Titanium Ingot":
                    itemCost = createInventory.ingotCost[9];
                    break;
                case "Sheep Skin":
                    itemCost = createInventory.skinCost[0];
                    break;
                case "Goat Skin":
                    itemCost = createInventory.skinCost[1];
                    break;
                case "Buffalo Skin":
                    itemCost = createInventory.skinCost[2];
                    break;
                case "Dodo Skin":
                    itemCost = createInventory.skinCost[3];
                    break;
                case "Serpent Skin":
                    itemCost = createInventory.skinCost[4];
                    break;
                case "Wolf Skin":
                    itemCost = createInventory.skinCost[5];
                    break;
                case "Ogre Skin":
                    itemCost = createInventory.skinCost[6];
                    break;
                case "Troll Skin":
                    itemCost = createInventory.skinCost[7];
                    break;
                case "Wyvern Skin":
                    itemCost = createInventory.skinCost[8];
                    break;
                case "Dragon Skin":
                    itemCost = createInventory.skinCost[9];
                    break;
                case "Sheep Leather":
                    itemCost = createInventory.leatherCost[0];
                    break;
                case "Goat Leather":
                    itemCost = createInventory.leatherCost[1];
                    break;
                case "Buffalo Leather":
                    itemCost = createInventory.leatherCost[2];
                    break;
                case "Dodo Leather":
                    itemCost = createInventory.leatherCost[3];
                    break;
                case "Serpent Leather":
                    itemCost = createInventory.leatherCost[4];
                    break;
                case "Wolf Leather":
                    itemCost = createInventory.leatherCost[5];
                    break;
                case "Ogre Leather":
                    itemCost = createInventory.leatherCost[6];
                    break;
                case "Troll Leather":
                    itemCost = createInventory.leatherCost[7];
                    break;
                case "Wyvern Leather":
                    itemCost = createInventory.leatherCost[8];
                    break;
                case "Dragon Leather":
                    itemCost = createInventory.leatherCost[9];
                    break;
                case "Rough Malachite":
                    itemCost = createInventory.gemCost[0];
                    break;
                case "Rough Lapis Lazuli":
                    itemCost = createInventory.gemCost[1];
                    break;
                case "Rough Turquoise":
                    itemCost = createInventory.gemCost[2];
                    break;
                case "Rough Coral":
                    itemCost = createInventory.gemCost[3];
                    break;
                case "Rough Agate":
                    itemCost = createInventory.gemCost[4];
                    break;
                case "Rough Jasper":
                    itemCost = createInventory.gemCost[5];
                    break;
                case "Rough Opal":
                    itemCost = createInventory.gemCost[6];
                    break;
                case "Rough Ruby":
                    itemCost = createInventory.gemCost[7];
                    break;
                case "Rough Pearl":
                    itemCost = createInventory.gemCost[8];
                    break;
                case "Rough Moonstone":
                    itemCost = createInventory.gemCost[9];
                    break;
                case "Polished Malachite":
                    itemCost = createInventory.gemstoneCost[0];
                    break;
                case "Polished Lapis Lazuli":
                    itemCost = createInventory.gemstoneCost[1];
                    break;
                case "Polished Turquoise":
                    itemCost = createInventory.gemstoneCost[2];
                    break;
                case "Polished Coral":
                    itemCost = createInventory.gemstoneCost[3];
                    break;
                case "Polished Agate":
                    itemCost = createInventory.gemstoneCost[4];
                    break;
                case "Polished Jasper":
                    itemCost = createInventory.gemstoneCost[5];
                    break;
                case "Polished Opal":
                    itemCost = createInventory.gemstoneCost[6];
                    break;
                case "Polished Ruby":
                    itemCost = createInventory.gemstoneCost[7];
                    break;
                case "Polished Pearl":
                    itemCost = createInventory.gemstoneCost[8];
                    break;
                case "Polished Moonstone":
                    itemCost = createInventory.gemstoneCost[9];
                    break;
                case "Raw Elm":
                    itemCost = createInventory.woodCost[0];
                    break;
                case "Raw Alder":
                    itemCost = createInventory.woodCost[1];
                    break;
                case "Raw Maple":
                    itemCost = createInventory.woodCost[2];
                    break;
                case "Raw Sandlewood":
                    itemCost = createInventory.woodCost[3];
                    break;
                case "Raw Ash":
                    itemCost = createInventory.woodCost[4];
                    break;
                case "Raw Fir":
                    itemCost = createInventory.woodCost[5];
                    break;
                case "Raw Cedar":
                    itemCost = createInventory.woodCost[6];
                    break;
                case "Raw Ironwood":
                    itemCost = createInventory.woodCost[7];
                    break;
                case "Raw Rosewood":
                    itemCost = createInventory.woodCost[8];
                    break;
                case "Raw Ebony":
                    itemCost = createInventory.woodCost[9];
                    break;
                case "Elm Lumber":
                    itemCost = createInventory.lumberCost[0];
                    break;
                case "Alder Lumber":
                    itemCost = createInventory.lumberCost[1];
                    break;
                case "Maple Lumber":
                    itemCost = createInventory.lumberCost[2];
                    break;
                case "Sandlewood Lumber":
                    itemCost = createInventory.lumberCost[3];
                    break;
                case "Ash Lumber":
                    itemCost = createInventory.lumberCost[4];
                    break;
                case "Fir Lumber":
                    itemCost = createInventory.lumberCost[5];
                    break;
                case "Cedar Lumber":
                    itemCost = createInventory.lumberCost[6];
                    break;
                case "Ironwood Lumber":
                    itemCost = createInventory.lumberCost[7];
                    break;
                case "Rosewood Lumber":
                    itemCost = createInventory.lumberCost[8];
                    break;
                case "Ebony Lumber":
                    itemCost = createInventory.lumberCost[9];
                    break;
                case "Basic Leather Strap":
                    itemCost = createInventory.leatherStrapCost[0];
                    break;
                case "Standard Leather Strap":
                    itemCost = createInventory.leatherStrapCost[1];
                    break;
                case "Good Leather Strap":
                    itemCost = createInventory.leatherStrapCost[2];
                    break;
                case "Excellent Leather Strap":
                    itemCost = createInventory.leatherStrapCost[3];
                    break;
                case "Expert Leather Strap":
                    itemCost = createInventory.leatherStrapCost[4];
                    break;
                case "Basic Leather Padding":
                    itemCost = createInventory.leatherPaddingCost[0];
                    break;
                case "Standard Leather Padding":
                    itemCost = createInventory.leatherPaddingCost[1];
                    break;
                case "Good Leather Padding":
                    itemCost = createInventory.leatherPaddingCost[2];
                    break;
                case "Excellent Leather Padding":
                    itemCost = createInventory.leatherPaddingCost[3];
                    break;
                case "Expert Leather Padding":
                    itemCost = createInventory.leatherPaddingCost[4];
                    break;
                case "Basic Hilt":
                    itemCost = createInventory.hiltCost[0];
                    break;
                case "Standard Hilt":
                    itemCost = createInventory.hiltCost[1];
                    break;
                case "Good Hilt":
                    itemCost = createInventory.hiltCost[2];
                    break;
                case "Excellent Hilt":
                    itemCost = createInventory.hiltCost[3];
                    break;
                case "Expert Hilt":
                    itemCost = createInventory.hiltCost[4];
                    break;
                case "Basic Sheath":
                    itemCost = createInventory.sheathCost[0];
                    break;
                case "Standard Sheath":
                    itemCost = createInventory.sheathCost[1];
                    break;
                case "Good Sheath":
                    itemCost = createInventory.sheathCost[2];
                    break;
                case "Excellent Sheath":
                    itemCost = createInventory.sheathCost[3];
                    break;
                case "Expert Sheath":
                    itemCost = createInventory.sheathCost[4];
                    break;
                case "Basic Handle":
                    itemCost = createInventory.handleCost[0];
                    break;
                case "Standard Handle":
                    itemCost = createInventory.handleCost[1];
                    break;
                case "Good Handle":
                    itemCost = createInventory.handleCost[2];
                    break;
                case "Excellent Handle":
                    itemCost = createInventory.handleCost[3];
                    break;
                case "Expert Handle":
                    itemCost = createInventory.handleCost[4];
                    break;
                default:
                    itemCost = GetComponent<SellItem>().getCraftedItem().GetComponent<ItemScript>().GetPower() * 10;
                    marketRoutine.setCurrentSellCraftedItem(GetComponent<SellItem>().getCraftedItem());
                    Debug.Log("Not a basic item");
                    break;
            }

            if (marketRoutine.getCurrentSellCraftedItem() == null)
            {
                itemCost = (int)(itemCost * 0.2f);
            }
            marketRoutine.setCurrentSellItem(itemName);
            marketRoutine.setCurrentSellPrice(itemCost);
            confirmationBox.SetActive(true);
            if (confirmationText == null)
            {
                confirmationText = confirmationBox.transform.GetChild(0).GetComponent<Text>();
            }
            confirmationText.text = "You want to sell your " + itemName + " for " + itemCost + "?";
        }
    }
}
