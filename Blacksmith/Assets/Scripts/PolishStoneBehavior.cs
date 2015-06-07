using UnityEngine;
using System.Collections;

public class PolishStoneBehavior : MonoBehaviour {

    private CraftRoutine craftingController;
    private Vector3 screenPoint;
    private Vector3 startLocation;
    private SoundController soundController;

	// Use this for initialization
	void Start () 
    {
        craftingController = GameObject.Find("Crafting/CraftingController").GetComponent<CraftRoutine>();
        soundController = GameObject.Find("GameController").GetComponent<SoundController>();
        startLocation = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    void OnTriggerEnter2D(Collider2D polishSpot)
    {
        craftingController.polishUpdateQuality();
        soundController.playPolishing();
    }

    void OnMouseDown()
    {
        if (craftingController.getCurrentStageAbsoluteValue() == 3)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        }
        else
        {
            transform.position = startLocation;
        }

        
    }

    void OnMouseUp()
    {
        this.transform.position = startLocation;
    }

    void OnMouseDrag()
    {
        if (craftingController.isCrafting())
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition;
        }
    }
}
