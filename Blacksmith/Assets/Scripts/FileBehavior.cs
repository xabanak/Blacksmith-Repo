using UnityEngine;
using System.Collections;

public class FileBehavior : MonoBehaviour {

    private CraftRoutine craftingController;
    private Vector3 screenPoint;
    private Vector3 startLocation;
    private int fileSet;

    // Use this for initialization
    void Start()
    {
        craftingController = GameObject.Find("Crafting/CraftingController").GetComponent<CraftRoutine>();
        startLocation = this.transform.position;
        fileSet = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D fileSpot)
    {
        if (fileSpot.gameObject.name == "Shimmer " + fileSet + "(Clone)")
        {
            Destroy(fileSpot.gameObject);
            craftingController.updateFileStage();
            fileSet++;
            
            if (fileSet > 24)
            {
                fileSet = 1;
            }
        }

    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }

    void OnMouseUp()
    {
        this.transform.position = startLocation;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;
    }
}
