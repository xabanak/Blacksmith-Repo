using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseEnterBehavior : MonoBehaviour {

    public GameObject mouseOver;
    public Text mouseOverText;
    private GameObject popUp;
    public Camera travelCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (popUp != null)
        {
            Vector3 temp = travelCamera.ScreenToWorldPoint(Input.mousePosition);
            popUp.transform.position = new Vector3(temp.x + 1.1f, temp.y + 0.6f, -5);
        }
	}

    void OnMouseEnter()
    {
        switch(gameObject.name)
        {
            case "Plains":
                Debug.Log("Plains");
                popUp = Instantiate(mouseOver, (travelCamera.ScreenToWorldPoint(Input.mousePosition)), Quaternion.identity) as GameObject;
                popUp.transform.GetChild(0).GetComponent<Text>().text = "A plains are known for their general abundance of materials.";
                break;
            case "Caves":
                Debug.Log("Caves");
                popUp = Instantiate(mouseOver, new Vector2(Input.mousePosition.x, Input.mousePosition.y), Quaternion.identity) as GameObject;
                popUp.transform.GetChild(0).GetComponent<Text>().text = "The caves are well known to be rich with minerals blacksmiths' need.";
                break;
            case "Forest":
                Debug.Log("Forest");
                popUp = Instantiate(mouseOver, new Vector2(Input.mousePosition.x, Input.mousePosition.y), Quaternion.identity) as GameObject;
                popUp.transform.GetChild(0).GetComponent<Text>().text = "The forest is dense and lush with a wide variety of tree species.";
                break;
            case "Swamp":
                Debug.Log("Swamp");
                popUp = Instantiate(mouseOver, new Vector2(Input.mousePosition.x, Input.mousePosition.y), Quaternion.identity) as GameObject;
                popUp.transform.GetChild(0).GetComponent<Text>().text = "";
                popUp.transform.GetChild(0).GetComponent<Text>().text = "The creatures of the swamp are known to have some of the toughest skins.";
                break;
            default:
                Debug.Log("Zone not found");
                break;
        }

        popUp.SetActive(true);
        popUp.transform.SetParent(gameObject.transform);
        popUp.transform.localScale = new Vector3(1, 1, 1);
    }

    void OnMouseExit()
    {
        if (gameObject.name == "Plains" || gameObject.name == "Caves" || gameObject.name == "Forest" || gameObject.name == "Swamp")
        {
            Destroy(popUp);
        }
    }
}
