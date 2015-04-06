using UnityEngine;
using System.Collections;

public class ComponentMovement : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 resetPoint;
	// Use this for initialization
    void Start()
    {
        resetPoint = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseUp() 
    {
        transform.position = resetPoint;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;
    }
}
