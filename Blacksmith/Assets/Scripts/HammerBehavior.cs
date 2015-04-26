using UnityEngine;
using System.Collections;

public class HammerBehavior : MonoBehaviour
{
    private int hammerLevel;

    private Vector3 screenPoint;
    public Vector3 offset;
    private Vector3 resetPoint;
    private const float angleChange = 35.0f;

    public GameObject anvil;
    public CraftRoutine craftController;

    public bool snapBack;
    private bool hasHit;
    private bool isDragged;
    // Use this for initialization
    void Start()
    {
        hammerLevel = 1;
        resetPoint = gameObject.transform.position;
        isDragged = false;
        hasHit = false;
    }

    void Update()
    {
        if (isDragged)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition + offset;
        }
        if (hasHit)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - angleChange);
            isDragged = false;
            transform.position = resetPoint;
        }

    }

    void OnTriggerEnter2D(Collider2D myCollider)
    {
        if (myCollider.gameObject.name == "Anvil")
        {
            hasHit = true;
            craftController.hammerHitOnAnvil();
        }

    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + angleChange);

        isDragged = true;
    }

    void OnMouseUp()
    {
        if (hasHit)
        {
            hasHit = false; ;
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - angleChange);
            isDragged = false;
            transform.position = resetPoint;
        }
    }

    void incrementHammerLevel()
    {
        hammerLevel++;
    }

    int getHammerLevel()
    {
        return hammerLevel;
    }
}