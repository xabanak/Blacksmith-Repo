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
    private GameObject component;
    private GameObject[] pointersUpDown;
    private GameObject[] pointersLeftRight;
    private GameObject[] shimmers;
    private Text message;
    private int tutorialStep;
    private bool tutorialDisplayed;
    private bool[] tutorials;
    private const int totalTutorials = 37;
    private const int totalPointersUpDown = 10;
    private const int totalPointersLeftRight = 10;
    private const int totalShimmers = 5;

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
        shimmers[0] = GameObject.Find("Tutorial/Tutorial Canvas/Shimmers/Component Shimmer");
        shimmers[1] = GameObject.Find("Tutorial/Tutorial Canvas/Shimmers/Bellows Shimmer");
        shimmers[2] = GameObject.Find("Tutorial/Tutorial Canvas/Shimmers/Hammer Shimmer");
        shimmers[3] = GameObject.Find("Tutorial/Tutorial Canvas/Shimmers/Grinding Shimmer");
        shimmers[4] = GameObject.Find("Tutorial/Tutorial Canvas/Shimmers/File Shimmer");

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
        if (craftRoutine.getComponent() != null)
        {
            if (!craftRoutine.getComponent().GetComponent<ComponentBehavior>().getInteractable())
            {
                craftRoutine.getComponent().GetComponent<ComponentBehavior>().toggleInteractable();
            }
        }
    }

    public void tutorialMachine(int step)
    {
        if (gameController.isTutorialActive())
        {
            switch (step)
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
                case 15:
                    hardeningStage1();
                    break;
                case 16:
                    hardeningStage2();
                    break;
                case 17:
                    hardeningStage3();
                    break;
                case 18:
                    hardeningStage4();
                    break;
                case 19:
                    grindingStage1();
                    break;
                case 20:
                    grindingStage2();
                    break;
                case 21:
                    grindingStage3();
                    break;
                case 22:
                    grindingStage4();
                    break;
                case 23:
                    temperingStage1();
                    break;
                case 24:
                    temperingStage2();
                    break;
                case 25:
                    temperingStage3();
                    break;
                case 26:
                    sharpeningStage1();
                    break;
                case 27:
                    sharpeningStage2();
                    break;
                case 28:
                    sharpeningStage3();
                    break;
                case 29:
                    polishingStage1();
                    break;
                case 30:
                    polishingStage2();
                    break;
                case 31:
                    polishingStage3();
                    break;
                case 32:
                    endOfCrafting1();
                    break;
                case 33:
                    endOfCrafting2();
                    break;
                case 34:
                    endOfCrafting3();
                    break;
                case 35:
                    endOfCrafting4();
                    break;
                case 36:
                    tutorialEnd();
                    break;
                default:
                    Debug.Log("Tutorial stage not found!");
                    break;
            }
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
        for (int i = 0; i < totalShimmers; i++)
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
        component = GameObject.Find("Component(Clone)");
        component.SetActive(false);
        craftRoutine.getComponent().GetComponent<ComponentBehavior>().toggleInteractable();
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
        component.SetActive(true);
        increaseTutorialStep();
    }

    // Step 10: Show the forge.
    void shapingStage5()
    {
        toggleTutorialActive();
        message.text = "Now first you want to heat the component to the right temperature. Drag and drop the component into the forge found here.";
        pointersUpDown[3].SetActive(true);
        craftRoutine.getComponent().GetComponent<ComponentBehavior>().toggleInteractable();
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

    // Step 13: Show player how to hammer.
    void shapingStage8()
    {
        toggleTutorialActive();
        message.text = "Good. Now click and drag the hammer onto the component.\nIncrease the hammer gauge indicator until it reaches the white section.\n";
        message.text += "In order to start the timer you must have both heat and hammer indicators in the white zone.";
        shimmers[2].SetActive(true);
        increaseTutorialStep();
    }

    // Step 14: Tell player timer has started.
    void shapingStage9()
    {
        toggleTutorialActive();
        message.text = "Great job! The timer has now started. This stage will finish when the timer runs out. To get the best quality keep both gauges in the sweet spots.";
        increaseTutorialStep();
    }

    // Step 15: Introduce the hardening stage.
    void hardeningStage1()
    {
        toggleTutorialActive();
        message.text = "The shaping stage is now complete. Next is the hardening stage. To get full quality on this stage, finish before the timer runs out.";
        increaseTutorialStep();
    }

    // Step 16: Tell player to reach max heat.
    void hardeningStage2()
    {
        toggleTutorialActive();
        message.text = "If your component is not already on the forge move it there and increase the heat until the heat gauge is full.";
        increaseTutorialStep();
    }

    // Step 17: Tell player to quench the component.
    void hardeningStage3()
    {
        toggleTutorialActive();
        message.text = "You have now reached the ideal heat level. Quickly drag the component into the cooling barrel.";
        pointersUpDown[5].SetActive(true);
        increaseTutorialStep();
    }

    // Step 18: Tell player to dip component into barrel.
    void hardeningStage4()
    {
        toggleTutorialActive();
        message.text = "Now click and drag the component into the barrel to quickly cool it.";
        increaseTutorialStep();
    }

    // Step 19: Introduce grinding stage.
    void grindingStage1()
    {
        toggleTutorialActive();
        message.text  = "The hardening stage is now complete. Next is the grinding stage.";
        text.transform.position = new Vector3(text.transform.position.x + 5, text.transform.position.y - 5, text.transform.position.z);
        textBox.transform.position = new Vector3(textBox.transform.position.x + 5, textBox.transform.position.y - 5, textBox.transform.position.z);
        increaseTutorialStep();
    }

    // Step 20: Tell player how to start grinding.
    void grindingStage2()
    {
        toggleTutorialActive();
        message.text = "Grab your component and put it onto the grinding wheel.";
        shimmers[3].SetActive(true);
        pointersLeftRight[6].SetActive(true);
        increaseTutorialStep();
    }

    // Step 21: Introduce balancing.
    void grindingStage3()
    {
        toggleTutorialActive();
        message.text = "Now the grinding wheel is fired up. You need to keep the component balanced while grinding.";
        increaseTutorialStep();
    }

    // Step 22: Tell player how to balance component and complete stage.
    void grindingStage4()
    {
        toggleTutorialActive();
        message.text = "Use the 'a' and 'd' keys to balance the component. You get the best quality by keeping it level. The stage will complete when the timer runs out.";
        increaseTutorialStep();
    }

    // Step 23: Introduce the tempering stage.
    void temperingStage1()
    {
        toggleTutorialActive();
        message.text = "The grinding stage is now complete. Next is the tempering stage.";
        increaseTutorialStep();
    }

    // Step 24: How to temper the blade.
    void temperingStage2()
    {
        toggleTutorialActive();
        message.text = "Move the component to the forge, then heat the it to reach green level on the heat gauge.";
        shimmers[0].SetActive(true);
        increaseTutorialStep();
    }

    // Step 25: How to cool the blade.
    void temperingStage3()
    {
        toggleTutorialActive();
        message.text = "That's the temperature you want. Now move the component into the cooling barrel and dip it in to quickly cool it.";
        text.transform.position = new Vector3(text.transform.position.x - 5, text.transform.position.y + 5, text.transform.position.z);
        textBox.transform.position = new Vector3(textBox.transform.position.x - 5, textBox.transform.position.y + 5, textBox.transform.position.z);
        increaseTutorialStep();
    }

    // Step 26: Introduction to sharpening.
    void sharpeningStage1()
    {
        toggleTutorialActive();
        message.text = "Now that the tempering is done, it's time to move onto sharpening the blade.";
        increaseTutorialStep();
    }

    // Step 27: How to sharpen one side of the blade.
    void sharpeningStage2()
    {
        toggleTutorialActive();
        message.text = "Grab the file and slide it across the points from right to left. To get the best quality hit each point with the center of the file shown here.";
        shimmers[4].SetActive(true);
        increaseTutorialStep();
    }

    // Step 28: How to finish sharpening.
    void sharpeningStage3()
    {
        toggleTutorialActive();
        message.text = "Great you have finished sharpening both sides of the blade. Repeat this process for both sides 4 more times.";
        increaseTutorialStep();
    }

    // Step 29: Introduce the polishing stage.
    void polishingStage1()
    {
        toggleTutorialActive();
        message.text = "Now that sharpening is done it's time to finish up and polish the blade.";
        increaseTutorialStep();
    }

    // Step 30: Tell player how to polish.
    void polishingStage2()
    {
        toggleTutorialActive();
        message.text = "Now grab the polishing stone and drag it across the point you see shining.";
        increaseTutorialStep();
    }
    
    // Step 31: Tell player how to finish polish stage.
    void polishingStage3()
    {
        toggleTutorialActive();
        message.text = "Well done. Now repeat this process until you have finished polishing or the time runs out.";
        increaseTutorialStep();
    }
    
    // Step 32: Explain crafting results.
    void endOfCrafting1()
    {
        toggleTutorialActive();
        message.text = "Congratulations you have finished crafing your first sword! Now you will see your crafting result. Your quality can range from poor, to excellent.";
        text.transform.position = new Vector3(text.transform.position.x + 5.5f, text.transform.position.y - 5.5f, text.transform.position.z);
        textBox.transform.position = new Vector3(textBox.transform.position.x + 5.5f, textBox.transform.position.y - 5.5f, textBox.transform.position.z);
        increaseTutorialStep();
    }

    // Step 33: Introduce inventory.
    void endOfCrafting2()
    {
        toggleTutorialActive();
        message.text = "Now that you have crafted your first item, take a look at it in your inventory by pressing the 'i' button.";
        increaseTutorialStep();
    }

    // Step 34: Show the weapons tab.
    void endOfCrafting3()
    {
        toggleTutorialActive();
        message.text = "Click the weapons tab to see the weapon you just crafted.";
        increaseTutorialStep();
    }

    // Step 35: Explain all tabs.
    void endOfCrafting4()
    {
        toggleTutorialActive();
        message.text = "Now you can see the weapon you crafted. This is the only tab that will have items in it. Later on you will have items under each tab to see.";
        increaseTutorialStep();
    }

    // Step 36: Finish demo.
    void tutorialEnd()
    {
        toggleTutorialActive();
        message.text = "This now concludes the tutorial for the demo.\nThank you for playing!\nYour feedback is greatly appreciated!";
        increaseTutorialStep();
    }
}
