using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateInventory : MonoBehaviour {

    public GameObject background;
    public Text textBox1;
    public Text textBox2;
    public Text tempText;
    public Canvas inventoryCanvas;

	// Use this for initialization
	void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetBackground()
    {
        Instantiate(background, new Vector3(-70f, 97f, -1), Quaternion.identity);
    }

    public void SetText()
    {
        tempText = Instantiate(textBox1, new Vector3(-70f, 97.0f, -2), Quaternion.identity) as Text;
        //tempText.transform.parent = inventoryCanvas.transform;
        tempText.transform.parent = inventoryCanvas.transform;
        Instantiate(textBox2, new Vector3(-70f, 90.0f, -2), Quaternion.identity);
    }
}
