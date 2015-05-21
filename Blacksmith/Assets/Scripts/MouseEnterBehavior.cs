using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseEnterBehavior : MonoBehaviour
{
    public GameObject mouseOver;
    public Text mouseOverText;
    private GameObject popUp;
    public Camera townCamera;
    private Adventurer[] adventurers;
    private AdventureRoutine adventureRoutine;

	// Use this for initialization
	void Start () 
    {
        adventureRoutine = GameObject.Find("GameController").GetComponent<AdventureRoutine>();
        adventurers = adventureRoutine.getAdventurers();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (popUp != null)
        {
            Vector3 temp = townCamera.ScreenToWorldPoint(Input.mousePosition);
            popUp.transform.position = new Vector3(temp.x + 1.1f, temp.y + 0.6f, -5);
        }
	}

    public void OnMouseEnter(string button)
    {
        switch(gameObject.name)
        {
            case "Plains":
                popUp = Instantiate(mouseOver, (townCamera.ScreenToWorldPoint(Input.mousePosition)), Quaternion.identity) as GameObject;
                popUp.transform.GetChild(0).GetComponent<Text>().text = "A plains are known for their general abundance of materials.";
                break;
            case "Caves":
                popUp = Instantiate(mouseOver, (townCamera.ScreenToWorldPoint(Input.mousePosition)), Quaternion.identity) as GameObject;
                popUp.transform.GetChild(0).GetComponent<Text>().text = "The caves are well known to be rich with minerals blacksmiths' need.";
                break;
            case "Forest":
                popUp = Instantiate(mouseOver, (townCamera.ScreenToWorldPoint(Input.mousePosition)), Quaternion.identity) as GameObject;
                popUp.transform.GetChild(0).GetComponent<Text>().text = "The forest is dense and lush with a wide variety of tree species.";
                break;
            case "Swamp":
                popUp = Instantiate(mouseOver, (townCamera.ScreenToWorldPoint(Input.mousePosition)), Quaternion.identity) as GameObject;
                popUp.transform.GetChild(0).GetComponent<Text>().text = "The creatures of the swamp are known to have some of the toughest skins.";
                break;
        }

        switch (button)
        {
            case "Hero 1":
                if (adventurers[0] != null)
                {
                    popUp = Instantiate(mouseOver, (townCamera.ScreenToWorldPoint(Input.mousePosition)), Quaternion.identity) as GameObject;
                    popUp.transform.GetChild(0).GetComponent<Text>().text = "Good at: " + adventurers[0].goodAt() + "\nBad at: " + adventurers[0].badAt();
                    Debug.Log("Hero 1");
                }
                break;
            case "Hero 2":
                if (adventurers[1] != null)
                {
                    popUp = Instantiate(mouseOver, (townCamera.ScreenToWorldPoint(Input.mousePosition)), Quaternion.identity) as GameObject;
                    popUp.transform.GetChild(0).GetComponent<Text>().text = "Good at: " + adventurers[1].goodAt() + "\nBad at: " + adventurers[1].badAt();
                    Debug.Log("Hero 2");
                }
                break;
            case "Hero 3":
                if (adventurers[2] != null)
                {
                    popUp = Instantiate(mouseOver, (townCamera.ScreenToWorldPoint(Input.mousePosition)), Quaternion.identity) as GameObject;
                    popUp.transform.GetChild(0).GetComponent<Text>().text = "Good at: " + adventurers[2].goodAt() + "\nBad at: " + adventurers[2].badAt();
                    Debug.Log("Hero 3");
                }
                break;
            default:
                break;
        }

        if (adventurers[0] != null && adventurers[1] != null && adventurers[2] != null)
        {
            popUp.SetActive(true);
            popUp.transform.SetParent(gameObject.transform);
            popUp.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void OnMouseExit()
    {
        if (popUp != null)
        //if (gameObject.name == "Plains" || gameObject.name == "Caves" || gameObject.name == "Forest" || gameObject.name == "Swamp")
        {
            Destroy(popUp);
        }
    }

}
