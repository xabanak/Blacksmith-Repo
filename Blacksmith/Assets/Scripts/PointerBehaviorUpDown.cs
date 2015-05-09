using UnityEngine;
using System.Collections;

public class PointerBehaviorUpDown : MonoBehaviour {

    private bool isMovingDown;
    private int speed;
    private float step;
    private float timer;

	// Use this for initialization
	void Start () 
    {
        speed = 1;
        timer = 0.5f;
    }
	
	// Update is called once per frame
	void Update () 
    {
        step = speed * Time.deltaTime;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0.5f;
            isMovingDown = !isMovingDown;
        }

        if (isMovingDown)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - step, gameObject.transform.position.z);
        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + step, gameObject.transform.position.z);
        }
    }
}
