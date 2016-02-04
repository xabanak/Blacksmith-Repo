using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HireHeroRoutine : MonoBehaviour {

    private TownBehavior townBehavior;
    private string window;
    public GameObject confirmationWindow;

	// Use this for initialization
	void Start () 
    {
        townBehavior = GameObject.Find("GameController").GetComponent<TownBehavior>();
        window = gameObject.name;
	}

    void OnMouseDown()
    {
        if (!confirmationWindow.activeSelf)
        {
            switch (window)
            {
                case "Top Window":
                    townBehavior.confirmHero(1);
                    break;
                case "Middle Window":
                    townBehavior.confirmHero(2);
                    break;
                case "Bottom Window":
                    townBehavior.confirmHero(3);
                    break;
                default:
                    break;
            }

        }
    }
}
