using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarketRoutine : MonoBehaviour {

    public GameObject itemLine;
    public Canvas marketCanvas;
    public GameObject buyBackground;
    private int tier;

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

        tierOneNames = new string[totalTierOneItems];
        tierOneCosts = new int[totalTierOneItems];
        tierOneNames[0] = "Tin Ore";
        tierOneNames[1] = "Basic Wood";
        tierOneNames[2] = "Basic Skin";
        tierOneNames[3] = "Basic Leather Strap";
        tierOneNames[4] = "Basic Leather Padding";
        tierOneNames[5] = "Basic Leather Sheath";
        tierOneNames[6] = "Basic Hilt";
        tierOneNames[7] = "Basic Handle";
        tierOneCosts[0] = 50;
        tierOneCosts[1] = 25;
        tierOneCosts[2] = 20;
        tierOneCosts[3] = 3;
        tierOneCosts[4] = 3;
        tierOneCosts[5] = 5;
        tierOneCosts[6] = 5;
        tierOneCosts[7] = 2;

	}
	
	void Update () 
    {
	
	}

    public void createNewLine()
    {
        int totalItems = 0;
        totalItems = 8;

        GameObject tempObj;

        for (int i = 0; i < totalItems; i++)
        {
            tempObj = Instantiate(itemLine, buyBackground.transform.position, Quaternion.identity) as GameObject;
            tempObj.transform.SetParent(buyBackground.transform);
            tempObj.transform.localScale = new Vector3(1, 1, 1);
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
}
