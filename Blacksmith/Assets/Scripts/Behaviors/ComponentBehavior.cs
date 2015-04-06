using UnityEngine;
using System.Collections;

public class ComponentBehavior : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 resetPoint;

    public GameObject anvil;
    public GameObject forge;

    public bool onAnvil;
    public bool onForge;

	// Use this for initialization
    void Start()
    {
        resetPoint = gameObject.transform.position;
    }
	
    void OnTriggerEnter2D(Collider2D myCollider)
    {
        if (myCollider.gameObject.name == "Anvil")
        {
            onAnvil = true;
        }
        else if (myCollider.gameObject.name == "Forge")
        {
            onForge = true;
        }
    }

    void OnTriggerExit2D(Collider2D myCollider)
    {
        if (myCollider.gameObject.name == "Anvil")
        {
            onAnvil = false;
        }
        else if (myCollider.gameObject.name == "Forge")
        {
            onForge = false;
        }
    }
	// Update is called once per frame
	void Update () 
    {
        
	
	}

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseUp() 
    {
        if (onAnvil)
        {
            transform.position = new Vector3(anvil.transform.position.x, anvil.transform.position.y, 0);
        }
        else if (onForge)
        {
            transform.position = new Vector3(forge.transform.position.x, forge.transform.position.y, 0);
        }
        else
        {
            transform.position = resetPoint;
        }
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;
    }
}
