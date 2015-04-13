using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateInventory : MonoBehaviour {

    public GameObject background;

    public Text textBox1;
    public Text textBox2;

    private Text tempText;

    public Canvas inventoryCanvas;
    public GameObject singleLine;
    public GameObject tempLine;

    private float lineStartPosition = 2.95f;
    private float spacer = 0.375f;

    private int totalItems = 10;
    private int[] testInts;

    private string[] testStrings;


	// Use this for initialization
	void Start ()
    {
        testStrings = new string[10];
        testStrings[0] = "Iron Ore";
        testStrings[1] = "Copper Ore";
        testStrings[2] = "Bronze Alloy";
        testStrings[3] = "Brass Alloy";
        testStrings[4] = "Iron Ore";
        testStrings[5] = "Blackened Iron Alloy";
        testStrings[6] = "Steel Alloy";
        testStrings[7] = "Hardened Steel Alloy";
        testStrings[8] = "Silver Ore";
        testStrings[9] = "Dragon Bone";

        testInts = new int[10];
        testInts[0] = 5;
        testInts[1] = 15;
        testInts[2] = 25;
        testInts[3] = 35;
        testInts[4] = 45;
        testInts[5] = 55;
        testInts[6] = 65;
        testInts[7] = 75;
        testInts[8] = 85;
        testInts[9] = 95;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SetBackground()
    {

        for (int i = 0; i < totalItems; i++)
        {
            tempLine = Instantiate(singleLine, new Vector3(inventoryCanvas.transform.position.x, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as GameObject;
            tempLine.transform.SetParent(background.transform);
        }

    }

    public void SetText()
    {
        for (int i = 0; i < totalItems; i++)
        {
            tempText = Instantiate(textBox1, new Vector3(inventoryCanvas.transform.position.x - 1.0f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText.transform.SetParent(background.transform);
            tempText.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText.text = testStrings[i];
            tempText = Instantiate(textBox2, new Vector3(inventoryCanvas.transform.position.x + 3.9f, inventoryCanvas.transform.position.y + lineStartPosition - spacer * i, 0.0f), Quaternion.identity) as Text;
            tempText.transform.SetParent(background.transform);
            tempText.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            tempText.text = "" + testInts[i];
        }
    }
}
