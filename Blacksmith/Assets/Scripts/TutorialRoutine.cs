using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialRoutine : MonoBehaviour {

    private GameController gameController;
    private CraftRoutine craftRoutine;
    private GameObject textBox;
    private GameObject text;
    private Text message;
    private int tutorialStep;
    private bool tutorialDisplayed;
    private bool[] tutorials;
    private const int totalTutorials = 30;

	// Use this for initialization
	void Start () 
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        craftRoutine = GameObject.Find("Crafting/CraftingController").GetComponent<CraftRoutine>();
        textBox = GameObject.Find("Canvas/Tutorial/Image");
        text = GameObject.Find("Canvas/Tutorial/Text");
        message = text.GetComponent<Text>();
        tutorialStep = 0;
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
    }

    public void tutorialMachine(int step)
    {
        switch(step)
        {
            case 0:
                startCrafting();
                break;
            case 1:
                selectItemAndMaterialTypes();
                break;
            default:
                break;
        }
    }

    private void increaseTutorialStep()
    {
        tutorials[tutorialStep] = true;
        tutorialStep++;
    }
    // Step 0: Used to tell the player how to start crafting.
    void startCrafting()
    {
        toggleTutorialActive();
        message.text = "Welcome!\nTo start crafting click the start crafting button at the top of the screen.";
        increaseTutorialStep();
    }

    void selectItemAndMaterialTypes()
    {
        toggleTutorialActive();
        message.text = "Now select the type of item you want to craft by pressing the Select Type button and ";
        message.text += "also select the material you want to use by clicking the Select Material button.";
        increaseTutorialStep();
    }
}
