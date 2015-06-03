using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighlighterTavern : MonoBehaviour
{
    private GameObject confirmationWindow;

    void OnMouseEnter()
    {
        if (GetComponent<Image>().color == Color.black)
            GetComponent<Image>().color = Color.gray;
    }

    void OnMouseExit()
    {
        if (GetComponent<Image>().color == Color.gray)
            GetComponent<Image>().color = Color.black;

    }
}
