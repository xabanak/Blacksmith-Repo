using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highlighter : MonoBehaviour 
{
    private GameObject confirmationWindow;
    private GameObject marketConfirmationBuy;
    private GameObject marketConfirmationSell;

    void Start()
    {
        marketConfirmationBuy = GameObject.Find("Town/Market Canvas/Market Confirmation Buy");
        marketConfirmationSell = GameObject.Find("Town/Market Canvas/Market Confirmation Sell");
    }
    void OnMouseEnter()
    {
        if (!marketConfirmationBuy.activeSelf && !marketConfirmationSell.activeSelf)
        {
            if (GetComponent<Image>().color == Color.black)
                GetComponent<Image>().color = Color.gray;
        }
    }

    void OnMouseExit()
    {
        if (GetComponent<Image>().color == Color.gray)
            GetComponent<Image>().color = Color.black;

    }
}
