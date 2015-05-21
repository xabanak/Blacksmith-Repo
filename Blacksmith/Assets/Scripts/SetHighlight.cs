using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetHighlight : MonoBehaviour {

    public GameObject plains;
    public GameObject caves;
    public GameObject forest;
    public GameObject swamp;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "Plains":
                gameObject.GetComponent<Image>().color = Color.green;
                //plains.GetComponent<Image>().color = Color.black;
                caves.GetComponent<Image>().color = Color.black;
                forest.GetComponent<Image>().color = Color.black;
                swamp.GetComponent<Image>().color = Color.black;
                break;
            case "Caves":
                gameObject.GetComponent<Image>().color = Color.green;
                plains.GetComponent<Image>().color = Color.black;
                //caves.GetComponent<Image>().color = Color.black;
                forest.GetComponent<Image>().color = Color.black;
                swamp.GetComponent<Image>().color = Color.black;
                break;
            case "Forest":
                gameObject.GetComponent<Image>().color = Color.green;
                plains.GetComponent<Image>().color = Color.black;
                caves.GetComponent<Image>().color = Color.black;
                //forest.GetComponent<Image>().color = Color.black;
                swamp.GetComponent<Image>().color = Color.black;
                break;
            case "Swamp":
                gameObject.GetComponent<Image>().color = Color.green;
                plains.GetComponent<Image>().color = Color.black;
                caves.GetComponent<Image>().color = Color.black;
                forest.GetComponent<Image>().color = Color.black;
                //swamp.GetComponent<Image>().color = Color.black;
                break;
            default:
                Debug.Log("Object not found");
                break;
        }
    }
}
