using UnityEngine;
using System.Collections;

public class GrinderTextBehavior : MonoBehaviour {

    int speed = 10;

	// Use this for initialization
	void Start () 
    {
        Destroy(this.gameObject, 2.0f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y * speed * Time.deltaTime, transform.position.z);
	}
}
