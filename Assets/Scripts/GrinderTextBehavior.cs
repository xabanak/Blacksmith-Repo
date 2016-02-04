using UnityEngine;
using System.Collections;

public class GrinderTextBehavior : MonoBehaviour {

    int speed = 1;
    float step;

	// Use this for initialization
	void Start () 
    {
        Destroy(this.gameObject, 2.0f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        step = speed * Time.deltaTime;
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + step, transform.position.z);
	}
}
