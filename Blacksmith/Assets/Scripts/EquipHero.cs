using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EquipHero : MonoBehaviour {

    private HeroInterface heroInterface;

	void Start () 
    {
        heroInterface = GameObject.Find("GameController").GetComponent<HeroInterface>();
        
	}

    void OnMouseOver()
    {
        if (GetComponent<Image>().color != Color.gray)
            GetComponent<Image>().color = Color.gray;
    }

    void OnMouseExit()
    {
        if (GetComponent<Image>().color == Color.gray)
            GetComponent<Image>().color = Color.black;
    }

    public void OnMouseDown()
    {
        heroInterface.equipHero(GetComponent<SellItem>().getCraftedItem());
    }
}
