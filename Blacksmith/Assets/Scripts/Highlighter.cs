using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highlighter : MonoBehaviour 
{

    void OnMouseEnter()
    {
        //objColor = Color.blue;
        GetComponent<Image>().color = Color.gray;
    }

    void OnMouseExit()
    {
        //objColor = Color.black;
        GetComponent<Image>().color = Color.black;
    }
}
