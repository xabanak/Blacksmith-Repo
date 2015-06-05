using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighlighterTravel : MonoBehaviour {

    public GameObject plains;
    public GameObject caves;
    public GameObject forest;
    public GameObject swamp;

    void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "Plains":
                gameObject.GetComponent<Image>().color = Color.green;
                caves.GetComponent<Image>().color = Color.black;
                forest.GetComponent<Image>().color = Color.black;
                swamp.GetComponent<Image>().color = Color.black;
                break;
            case "Caves":
                gameObject.GetComponent<Image>().color = Color.green;
                plains.GetComponent<Image>().color = Color.black;
                forest.GetComponent<Image>().color = Color.black;
                swamp.GetComponent<Image>().color = Color.black;
                break;
            case "Forest":
                gameObject.GetComponent<Image>().color = Color.green;
                plains.GetComponent<Image>().color = Color.black;
                caves.GetComponent<Image>().color = Color.black;
                swamp.GetComponent<Image>().color = Color.black;
                break;
            case "Swamp":
                gameObject.GetComponent<Image>().color = Color.green;
                plains.GetComponent<Image>().color = Color.black;
                caves.GetComponent<Image>().color = Color.black;
                forest.GetComponent<Image>().color = Color.black;
                break;
            default:
                Debug.Log("Object not found");
                break;
        }
    }

    void OnMouseOver()
    {
        if (GetComponent<Image>().color == Color.black)
            GetComponent<Image>().color = Color.gray;
    }

    void OnMouseExit()
    {
        if (GetComponent<Image>().color == Color.gray)
            GetComponent<Image>().color = Color.black;
    }

    public void clearHighlights()
    {
        if (plains.GetComponent<Image>().color == Color.gray || plains.GetComponent<Image>().color == Color.green)
        {
            plains.GetComponent<Image>().color = Color.black;
        }

        if (caves.GetComponent<Image>().color == Color.gray || caves.GetComponent<Image>().color == Color.green)
        {
            caves.GetComponent<Image>().color = Color.black;
        }

        if (forest.GetComponent<Image>().color == Color.gray || forest.GetComponent<Image>().color == Color.green)
        {
            forest.GetComponent<Image>().color = Color.black;
        }

        if (swamp.GetComponent<Image>().color == Color.gray || swamp.GetComponent<Image>().color == Color.green)
        {
            swamp.GetComponent<Image>().color = Color.black;
        }
    }
}
