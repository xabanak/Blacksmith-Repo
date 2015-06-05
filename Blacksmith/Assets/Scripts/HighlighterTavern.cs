using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighlighterTavern : MonoBehaviour
{
    public GameObject confirmationWindow;
    public GameObject topWindow;
    public GameObject middleWindow;
    public GameObject bottomWindow;

    void OnMouseOver()
    {
        if (!confirmationWindow.activeSelf)
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

    public void clearHighlights()
    {
        if (topWindow.GetComponent<Image>().color == Color.gray)
            topWindow.GetComponent<Image>().color = Color.black;
        if (middleWindow.GetComponent<Image>().color == Color.gray)
            middleWindow.GetComponent<Image>().color = Color.black;
        if (bottomWindow.GetComponent<Image>().color == Color.gray)
            bottomWindow.GetComponent<Image>().color = Color.black;
    }
}
