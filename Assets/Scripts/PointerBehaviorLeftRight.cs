using UnityEngine;
using System.Collections;

public class PointerBehaviorLeftRight : MonoBehaviour {

    private bool isMovingLeft;
    private int speed;
    private float step;
    private float timer;

    // Use this for initialization
    void Start()
    {
        speed = 1;
        timer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0.5f;
            isMovingLeft = !isMovingLeft;
        }

        if (isMovingLeft)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - step, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + step, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}
