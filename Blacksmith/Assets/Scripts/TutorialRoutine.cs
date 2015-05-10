using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialRoutine : MonoBehaviour {

    private GameController gameController;
    private CraftRoutine craftRoutine;
    private GameObject textBox;
    private GameObject text;
    private GameObject[] pointersUpDown;
    private GameObject[] pointersLeftRight;
    private Text message;
    private int tutorialStep;
    private bool tutorialDisplayed;
    private bool[] tutorials;
    private const int totalTutorials = 30;
    private const int totalPointersUpDown = 10;
    private const int totalPointersLeftRight = 10;
    private Camera craftingCamera;
    private Camera tutorialCamera;
    //private Camera townCamera;

	// Use this for initialization
	void Start () 
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        craftRoutine = GameObject.Find("Crafting/CraftingController").GetComponent<CraftRoutine>();
        textBox = GameObject.Find("Tutorial/Tutorial Canvas/Message Background");
        textBox.SetActive(false);
        text = GameObject.Find("Tutorial/Tutorial Canvas/Message Box");
        text.SetActive(false);
        craftingCamera = GameObject.Find("Crafting/Crafting Camera").GetComponent<Camera>();
        pointersUpDown = new GameObject[totalPointersUpDown];
        pointersLeftRight = new GameObject[totalPointersLeftRight];
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
            
        message = text.GetComponent<Text>();
        tutorialStep = 1;
        tutorialDisplayed = false;
        tutorials = new bool[totalTutorials];
        for (int i = 0; i < totalTutorials; i++)
        {
            tutorials[i] = false;
        }

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

    void shapingStage1()
    {
        toggleTutorialActive();
        message.text = "This is the shaping stage.\nTo start the timer you need to reach the \"sweet spot\" for both the the heat gauge and hammer gauge.";
        increaseTutorialStep();
    }

    void shapingStage2()
    {
        toggleTutorialActive();
        message.text = "This is the heat gauge.\nYou want to keep the metal hot so that it can be wokred with the hammer.";
        pointersLeftRight[3].SetActive(true);
        increaseTutorialStep();
    }

    void shapingStage3()
    {
        toggleTutorialActive();
        message.text = "This is the hammer gauge.\nYou want to maintain the right amount of hammer hits, or the item will become mishapen.";
        pointersLeftRight[4].SetActive(true);
        increaseTutorialStep();
    }

    void shapingStage4()
    {
        toggleTutorialActive();
        message.text = "This is the component you are currently shaping into a finished sword blade.";
        increaseTutorialStep();
    }

    void shapingStage5()
    {
        toggleTutorialActive();
        message.text = "Now first you want to heat the component to the right temperature. Drag and drop the component into the forge found here.";
        increaseTutorialStep();
    }

    void shapingStage6()
    {
        toggleTutorialActive();
        message.text = "Now that the component is in the forge you must pump the bellows to heat the forge and increase the temperature of the component.";
        increaseTutorialStep();
    }

    void shapingStage7()
    {
        toggleTutorialActive();
        message.text = "Click on the top handle of the bellows. While still holding down the left mouse button drag the bellows to close and open them again to heat the forge";
        increaseTutorialStep();
    }
}
