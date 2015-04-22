using UnityEngine;
using System.Collections;

public class HammerBehavior : MonoBehaviour {


    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 resetPoint;

    public GameObject anvil;
    public CraftRoutine craftController;

    public bool snapBack;

    private bool isDragged;
    // Use this for initialization
    void Start()
    {
        resetPoint = gameObject.transform.position;
        isDragged = false;
    }

    void Update()
    {
        if (isDragged)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D myCollider)
    {
        if (myCollider.gameObject.name == "Anvil")
        {
            craftController.hammerHitOnAnvil();
        }
    }

    void OnTriggerExit2D(Collider2D myCollider)
    {
        if(myCollider.gameObject.name == "Component")
        {
            if (snapBack)
            {
                isDragged = false;
                transform.position = resetPoint;
            }
        }
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        isDragged = true;
    }

    void OnMouseUp()
    {
        isDragged = false;
        transform.position = resetPoint;
    }

    /*void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;

        if (hitAnvil)
        {
            hitAnvil = !hitAnvil;
            transform.position = resetPoint;
            return;
        }
    }*/
}