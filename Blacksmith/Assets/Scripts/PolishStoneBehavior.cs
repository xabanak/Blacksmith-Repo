using UnityEngine;
using System.Collections;

public class PolishStoneBehavior : MonoBehaviour {

    private CraftRoutine craftingController;
    private Vector3 screenPoint;

	// Use this for initialization
	void Start () 
    {
        craftingController = GameObject.Find("Crafting/CraftingController").GetComponent<CraftRoutine>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D polishSpot)
    {
        Debug.Log("Triggered");
        craftingController.polishUpdateQuality();
        /*if (polishSpot.gameObject.name == "Shimmer 1(Clone)" || polishSpot.gameObject.name == "Shimmer 2(Clone)" ||
            polishSpot.gameObject.name == "Shimmer 3(Clone)" || polishSpot.gameObject.name == "Shimmer 4(Clone)" ||
            polishSpot.gameObject.name == "Shimmer 5(Clone)" || polishSpot.gameObject.name == "Shimmer 6(Clone)" ||
            polishSpot.gameObject.name == "Shimmer 7(Clone)" || polishSpot.gameObject.name == "Shimmer 8(Clone)" ||
            polishSpot.gameObject.name == "Shimmer 9(Clone)" || polishSpot.gameObject.name == "Shimmer 10(Clone)" ||
            polishSpot.gameObject.name == "Shimmer 11(Clone)" || polishSpot.gameObject.name == "Shimmer 12(Clone)")
        {
            Debug.Log("collider hit");
            craftingController.polishUpdateQuality();
        }*/
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;
    }
}
