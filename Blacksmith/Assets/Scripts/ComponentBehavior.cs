using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ComponentBehavior : MonoBehaviour 
{

    private GameObject room1Position;
    private GameObject room2Position;

    private Vector3 screenPoint;
    private Vector3 offset;
    //private Vector3 resetPoint;

    public Vector3 anvilOffset;
    public Vector3 forgeOffset;
    public Vector3 barrelOffset;
    public Vector3 grinderOffset;

    private GameObject anvil;
    private GameObject forge;
    private GameObject barrel;
    private GameObject grinder;
    private CraftRoutine craftController;

    private bool onAnvil;
    private bool onForge;
    private bool inBarrel;
    private bool onGrinder;

    private bool inRoom1;

    private bool mouseDrag;
    private bool interactable;

	// Use this for initialization
    void Awake()
    {
        mouseDrag = false;
        inRoom1 = true;
        room1Position = GameObject.Find("Crafting/Room1Position");
        room2Position = GameObject.Find("Crafting/Room2Position");
        anvil = GameObject.Find("Crafting/Anvil");
        forge = GameObject.Find("Crafting/Forge");
        barrel = GameObject.Find("Crafting/Barrel");
        grinder = GameObject.Find("Crafting/Grinder");
        craftController = GameObject.Find("Crafting/CraftingController").GetComponent<CraftRoutine>();
        transform.position = room1Position.transform.position;
        interactable = true;
    }

    public void setImage(Sprite image)
    {
        GetComponent<SpriteRenderer>().sprite = image;
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
        else if (myCollider.gameObject.name == "Barrel")
        {
            inBarrel = true;
        }
        else if (myCollider.gameObject.name == "Grinder")
        {
            onGrinder = true;
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
        else if (myCollider.gameObject.name == "Barrel")
        {
            inBarrel = false;
        }
        else if (myCollider.gameObject.name == "Grinder")
        {
            onGrinder = false;
        }
    }

    void OnMouseDown()
    {
        mouseDrag = true;
        if (onAnvil)
        {
            craftController.toggleComponentOnAnvil();
        }
        else if (onForge)
        {
            craftController.toggleComponentOnForge();
        }
        else if (inBarrel)
        {
            if (craftController.barrelSliderObject.GetComponent<Slider>().value == 0)
            {
                craftController.toggleComponentInBarrel();
                transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            }
        }
        else if (onGrinder)
        {
            craftController.toggleComponentOnGrinder();
        }
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseUp() 
    {
        mouseDrag = false;
        if (onAnvil && craftController.canUseAnvil())
        {
            transform.position = new Vector3(anvil.transform.position.x, anvil.transform.position.y, 0) + anvilOffset;
            craftController.toggleComponentOnAnvil();
        }
        else if (onForge && craftController.canUseForge())
        {
            transform.position = new Vector3(forge.transform.position.x, forge.transform.position.y, 0) + forgeOffset;
            craftController.toggleComponentOnForge();
        }
        else if(inBarrel && craftController.canUseBarrel())
        {
            transform.position = new Vector3(barrel.transform.position.x, barrel.transform.position.y, 0) + barrelOffset;
			transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90.0f);
            craftController.toggleComponentInBarrel();
        }
        else if(onGrinder && craftController.canUseGrinder())
        {
            transform.position = new Vector3(grinder.transform.position.x, grinder.transform.position.y, 0) + grinderOffset;
            craftController.toggleComponentOnGrinder();
        }
        else
        {
            if (inRoom1)
            {
                transform.position = room1Position.transform.position;
            }
            else
            {
                transform.position = room2Position.transform.position;
            }
            
        }
    }

    public void removeFromBarrel()
    {
        if (inBarrel)
        {
            inBarrel = false;
            //craftController.toggleComponentInBarrel();
            transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            transform.position = room1Position.transform.position;
        }
    }

    void OnMouseDrag()
    {
        if (interactable)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition;
        }
    }

    public void toggleInteractable()
    {
        interactable = !interactable;
    }

    public bool getInteractable()
    {
        return interactable;
    }

    public void switchRoom(bool room)
    {
        if (inRoom1 == room)
        {
            return;
        }
        else
        {
            if (room)
            {
                inRoom1 = true;
                transform.position = room1Position.transform.position;
            }
            else
            {
                inRoom1 = false;
                transform.position = room2Position.transform.position;
            }

            if (inBarrel)
            {
                craftController.toggleComponentInBarrel();
                inBarrel = false;
            }
            else if (onForge)
            {
                craftController.toggleComponentOnForge();
                onForge = false;
            }
            else if (onAnvil)
            {
                craftController.toggleComponentOnAnvil();
                onAnvil = false;
            }
            else if (onGrinder)
            {
                craftController.toggleComponentOnGrinder();
                onGrinder = false;
            }
        }
    }
}
