using UnityEngine;
using System.Collections;

public class FileBehavior : MonoBehaviour {

    public double pointDistance;
    public double halfPointDistance;
    public double quarterPointDistance;

    private CraftRoutine craftingController;
    private Vector3 screenPoint;
    private Vector3 startLocation;
    private int fileSet;
    private Vector3 origin;
    private SoundController soundController;

    void Start()
    {
        soundController = GameObject.Find("GameController").GetComponent<SoundController>();
        craftingController = GameObject.Find("Crafting/CraftingController").GetComponent<CraftRoutine>();
        startLocation = this.transform.position;
        fileSet = 1;
    }

    void OnTriggerEnter2D(Collider2D fileSpot)
    {
        origin = transform.position;
        soundController.playSharpening();

        if (fileSpot.gameObject.name == "Shimmer " + fileSet + "(Clone)")
        {
            Destroy(fileSpot.gameObject);

            double distance = Vector3.Distance(fileSpot.gameObject.transform.position, origin);

            distance -= 4.3f;
            distance *= 100;

            if (distance < pointDistance)
            {
                //Debug.Log("Full point, distance: " + distance);
                craftingController.updateFileStage(1.0f);
            }
            else if (distance >= pointDistance && distance < halfPointDistance)
            {
                //Debug.Log("Half point, distance: " + distance);
                craftingController.updateFileStage(0.5f);
            }
            else if (distance >= halfPointDistance && distance < quarterPointDistance)
            {
                //Debug.Log("Quarter point, distance: " + distance);
                craftingController.updateFileStage(0.25f);
            }
            else if (distance > quarterPointDistance)
            {
               // Debug.Log("No point, distance: " + distance);
                craftingController.updateFileStage(0.0f);
            }
            else
            {
               Debug.Log("Error!?!@");
            }

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

    public int getFileSet()
    {
        return fileSet;
    }
}
