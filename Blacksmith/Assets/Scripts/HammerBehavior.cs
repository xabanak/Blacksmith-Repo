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
    private GameObject craftingController;

    public bool snapBack;
    private bool hasHit;
    private bool isDragged;
    Vector2 currentVelocity;
    Vector2 currentPosition;

    // Use this for initialization
    void Start()
    {
        hammerLevel = 1;
        resetPoint = gameObject.transform.position;
        isDragged = false;
        //hasHit = false;
        craftingController = GameObject.Find("Crafting/CraftingController");
    }

    void Update()
    {
        Vector2 tempPosition = transform.position;
        currentVelocity = (tempPosition - currentPosition);
        //Debug.Log(currentVelocity);
        if (isDragged)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition + offset;
        }
        currentPosition = tempPosition;
        /*if (hasHit)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - angleChange);
            isDragged = false;
            transform.position = resetPoint;
        }*/

    }

    void OnTriggerEnter2D(Collider2D myCollider)
    {
        float magnitude = Mathf.Sqrt((currentVelocity.x * currentVelocity.x) + (currentVelocity.y * currentVelocity.y));
        //Debug.Log("Magnitude is:" + magnitude);
        Vector2 unitVector = new Vector2((currentVelocity.x / magnitude), currentVelocity.y / magnitude);
        //Debug.Log("UnitVector is: <" + unitVector.x + ", " + unitVector.y + ">");
        if (myCollider.gameObject.name == "Anvil")
        {
            //Debug.Log("Entered Anvil collider");
            if (magnitude > 0.75f)
            {
                //Debug.Log("Passed magnitude test");
                if (unitVector.x > Mathf.Cos(4.189f) && unitVector.x < Mathf.Cos(5.236f))
                {
                    //Debug.Log("Passed x angle test");
                    if (unitVector.y < Mathf.Sin(4.189f))
                    {
                        //Debug.Log("Passed y angle text");
                        craftController.hammerHitOnAnvil(magnitude);
                    }
                }
            }
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
        /*if (hasHit)
        {
            hasHit = false; ;
        }*/
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - angleChange);
        isDragged = false;
        transform.position = resetPoint;
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