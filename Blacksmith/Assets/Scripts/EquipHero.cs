using UnityEngine;
using System.Collections;

public class EquipHero : MonoBehaviour {

    private GameObject tempObj;
    public GameObject itemLine;
    public GameObject weaponBackground;
    private CreateInventory createInventory;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showWeaponList()
    {
        int totalItems = 0;
        /*
        for (int i = 0; i < totalItems; i++)
        {
            tempObj = Instantiate(itemLine, weaponBackground.transform.position, Quaternion.identity) as GameObject;
            tempObj.transform.SetParent(weaponBackground.transform);
            tempObj.transform.localScale = new Vector3(1, 1, 1);
            tempObj.name = tierOneNames[i];
            tempObj.AddComponent<ConfirmPurchase>();
            tempObj.transform.GetChild(0).GetComponent<Text>().text = tierOneNames[i];
            tempObj.transform.GetChild(1).GetComponent<Text>().text = "" + tierOneCosts[i] + " gold";
        }*/
    }
}
