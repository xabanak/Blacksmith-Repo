using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialRoutine : MonoBehaviour {

    private GameController gameController;
    private CraftRoutine craftRoutine;
    private Transform textBoxTransform;
    private Transform textTransform;
    private GameObject textBox;
    private GameObject text;
    private GameObject[] pointersUpDown;
    private GameObject[] pointersLeftRight;
    private GameObject[] shimmers;
    private Text message;
    private int tutorialStep;
    private bool tutorialDisplayed;
    private bool[] tutorials;
    private const int totalTutorials = 30;
    private const int totalPointersUpDown = 10;
    private const int totalPointersLeftRight = 10;
    private const int totalShimmers = 5;
    private Camera craftingCamera;
    private Camera tutorialCamera;
    //private Camera townCamera;

    void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        craftRoutine = GameObject.Find("Crafting/CraftingController").GetComponent<CraftRoutine>();
        textBox = GameObject.Find("Tutorial/Tutorial Canvas/Message Background");
        textBox.SetActive(false);
        text = GameObject.Find("Tutorial/Tutorial Canvas/Message Box");
        text.SetActive(false);
        textBoxTransform = textBox.transform;
        textTransform = text.transform;
        craftingCamera = GameObject.Find("Crafting/Crafting Camera").GetComponent<Camera>();
        pointersUpDown = new GameObject[totalPointersUpDown];
        pointersLeftRight = new GameObject[totalPointersLeftRight];
        shimmers = new GameObject[totalShimmers];
        for (int i = 0; i < totalPointersUpDown; i++)
        {
            pointersUpDown[i] = GameObject.Find("Tutorial/Tutorial Canvas/Pointers/PointerUpDown " + (i + 1));
            pointersUpDown[i].SetActive(false);
        }
        for (int i = 0; i < totalPointersLeftRight; i++)
        {
            pointersLeftRight[i] = GameObject.Find("Tutorial/Tutorial Canvas/Pointers/PointerLeftRight " + (i + 1));
            pointersLeftRight[i].SetActive(false);
        }
        shimmers[0] = GameObject.Find("Tutorial/Shimmers/Component Shimmer");
        shimmers[1] = GameObject.Find("Tutorial/Shimmers/Bellows Shimmer");
        shimmers[2] = GameObject.Find("Tutorial/Shimmers/Hammer Shimmer");

        message = text.GetComponent<Text>();
        tutorialStep = 1;
        tutorialDisplayed = false;
        tutorials = new bool[totalTutorials];
        for (int i = 0; i < totalTutorials; i++)
        {
            tutorials[i] = false;
        }
    }

	// Use this for initialization
	void Start () 
    {

	}

    // Used to determine if a step of the totorial has been completed.
    public bool tutorialComplete(int tutorial)
    {
        return tutorials[tutorial];
    }

    // Used to enable or disable the text window.
    void showMessage()
    {
        textBox.SetActive(!textBox.activeSelf);
        text.SetActive(!text.activeSelf);
    }

    public bool isTutorialDisplayed()
    {
        return tutorialDisplayed;
    }

    public void toggleTutorialDispalyed()
    {
        tutorialDisplayed = !tutorialDisplayed;
    }

    public void toggleTutorialActive()
    {
        craftRoutine.Pause();
        showMessage();
        toggleTutorialDispalyed();
        disablePointers();
        disableShimmers();
        resetTextBox();
    }

    public void tutorialMachine(int step)
    {
        switch(step)
        {
            case 1:
                startCrafting();
                break;
            case 2:
                selectItemAndMaterialTypes();
                break;
            case 3:
                selectItemType();
                break;
            case 4:
                selectMaterialtype();
                break;
            case 5:
                initiateCrafting();
                break;
            case 6:
                shapingStage1();
                break;
            case 7:
                shapingStage2();
                break;
            case 8:
                shapingStage3();
                break;
            case 9:
                shapingStage4();
                break;
            case 10:
                shapingStage5();
                break;
            case 11:
                shapingStage6();
                break;
            case 12:
                shapingStage7();
                break;
            case 13:
                shapingStage8();
                break;
            case 14:
                shapingStage9();
                break;
            default:
                Debug.Log("Tutorial stage not found!");
                break;
        }
    }

    private void disablePointers()
    {
        for (int i = 0; i < totalPointersUpDown; i++)
        {
            pointersUpDown[i].SetActive(false);
        }
        for (int i = 0; i < totalPointersLeftRight; i++)
        {
            pointersLeftRight[i].SetActive(false);
        }
    }

    private void disableShimmers()
    {
        for (int i = 0; i < 3; i++)
        {
            shimmers[i].SetActive(false);
        }
    }

    private void resetTextBox()
    {
        text.transform.position = textTransform.position;
        textBox.transform.position = textBoxTransform.position;
    }

    private void increaseTutorialStep()
    {
        tutorials[tutorialStep] = true;
        tutorialStep++;
    }

    // Step 1: Used to tell the player how to start crafting.
    void startCrafting()
    {
        toggleTutorialActive();
        message.text = "Welcome to Blacksmith!\nTo start crafting click the craft button at the top of the screen.";
        pointersLeftRight[0].SetActive(true);
        increaseTutorialStep();
    }

    // Step 2: Shows the player how to select the item type and material.
    void selectItemAndMaterialTypes()
    {
        toggleTutorialActive();
        message.text = "Now select the type of item you want to craft and the material you want to use by clicking ";
        message.text += "the Type and Material buttons.";
        pointersUpDown[0].SetActive(true);
        pointersUpDown[1].SetActive(true);
        increaseTutorialStep();
    }

    // Step 3: Shows the player how to select the sword icon from item types.
    void selectItemType()
    {
        toggleTutorialActive();
        message.text = "Now select the sword icon. For now this is the only item type you can craft.";
        pointersLeftRight[1].SetActive(true);
        increaseTutorialStep();
    }

    // Step 4: Shows the player how to select the tin ingot from the material types.
    void selectMaterialtype()
    {
        toggleTutorialActive();
        message.text = "Now select the tin ingot material. For now this is the only type of material you can craft with.";
        pointersLeftRight[2].SetActive(true);
        increaseTutorialStep();
    }

    // Step 5: Shows the player how to initial crafting.
    void initiateCrafting()
    {
        toggleTutorialActive();
        message.text = "You are now ready to start crafting. Click the ready button to get started.";
        pointersLeftRight[0].SetActive(true);
        increaseTutorialStep();
    }

    // Step 6: Intro to the shaping stage.
    void shapingStage1()
    {
        toggleTutorialActive();
        message.text = "This is the stage indicator.\nYour first stage for crafting a sword is shaping. To start the timer you need to reach the \"sweet spot\" for both the the heat gauge and hammer gauge.";
        pointersLeftRight[5].SetActive(true);
        increaseTutorialStep();
    }

    // Step 7: Show the heat gauge.
    void shapingStage2()
    {
        toggleTutorialActive();
        message.text = "This is the heat gauge.\nYou want to keep the metal hot so that it can be wokred with the hammer.";
        pointersLeftRight[3].SetActive(true);
        increaseTutorialStep();
    }

    // Step 8: Show the hammer gauge.
    void shapingStage3()
    {
        toggleTutorialActive();
        message.text = "This is the hammer gauge.\nYou want to maintain the right amount of hammer hits, or the item will become mishapen.";
        pointersLeftRight[4].SetActive(true);
        increaseTutorialStep();
    }

    // Step 9: Show the component.
    void shapingStage4()
    {
        toggleTutorialActive();
        message.text = "This is the component you are currently shaping into a finished sword blade.";
        shimmers[0].SetActive(true);
        pointersUpDown[2].SetActive(true);
        increaseTutorialStep();
    }

    // Step 10: Show the forge.
    void shapingStage5()
    {
        toggleTutorialActive();
        message.text = "Now first you want to heat the component to the right temperature. Drag and drop the component into the forge found here.";
        pointersUpDown[3].SetActive(true);
        increaseTutorialStep();
    }

    // Step 11: Show the bellows.
    void shapingStage6()
    {
        toggleTutorialActive();
        message.text = "Now that the component is in the forge click on the top handle of the bellows and drag down then up to increase the heat. ";
        message.text += "Repeat this process to increase heat until the indicator nears the right end of the gauge.";
        text.transform.position = new Vector3(text.transform.position.x + 5, text.transform.position.y, text.transform.position.z);
        textBox.transform.position = new Vector3(textBox.transform.position.x + 5, textBox.transform.position.y, textBox.transform.position.z);
        shimmers[1].SetActive(true);
        increaseTutorialStep();
    }

    // Step 12: Show the player the anvil.
    void shapingStage7()
    {
        toggleTutorialActive();
        message.text = "You have now reached a good heat level. Now move the component from the forge to the anvil.";
        text.transform.position = new Vector3(text.transform.position.x - 5, text.transform.position.y + 5, text.transform.position.z);
        textBox.transform.position = new Vector3(textBox.transform.position.x - 5, textBox.transform.position.y + 5, textBox.transform.position.z);
        pointersUpDown[4].SetActive(true);
        increaseTutorialStep();
    }

    void shapingStage8()
    {
        toggleTutorialActive();
        message.text = "Good. Now click and drag the hammer onto the component.\nIncrease the hammer gauge indicator until it reaches the white section.\n";
        message.text += "In order to start the timer you must have both heat and hammer indicators in the white zone.";
        shimmers[2].SetActive(true);
        increaseTutorialStep();
    }

    void shapingStage9()
    {
        toggleTutorialActive();
        message.text = "Great job! The timer has now started. This stage will finish when the timer runs out. To get the best quality keep both gauges in the sweet spots.";
        increaseTutorialStep();
    }
}
