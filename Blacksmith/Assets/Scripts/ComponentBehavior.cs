﻿using UnityEngine;
using System.Collections;

public class ComponentBehavior : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 resetPoint;

    public Vector3 anvilOffset;
    public Vector3 forgeOffset;
    public Vector3 barrelOffset;
    public Vector3 grinderOffset;

    public GameObject anvil;
    public GameObject forge;
    public GameObject barrel;
    public GameObject grinder;
    public CraftRoutine craftController;

    public bool onAnvil;
    public bool onForge;
    public bool inBarrel;
    public bool onGrinder;

    public bool mouseDrag;

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
	// Update is called once per frame
	void Update () 
    {
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
            craftController.toggleComponentInBarrel();
			transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
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
