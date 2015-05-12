using UnityEngine;
using System.Collections;

public class AdventureRoutine : MonoBehaviour 
{
    private Adventurer[] adventurers;
    const int NUM_ADVENTURERS = 3;
    private int numAdventurers;

	void Start () 
    {
	    adventurers = new Adventurer[NUM_ADVENTURERS];
        numAdventurers = 0;
	}

	void Update () 
    {
	
	}

    public void addAdventurer(Adventurer newHero)
    {
        if (numAdventurers == 3)
        {
            return; 
        }

        adventurers[numAdventurers] = newHero;

        numAdventurers++;
    }
}

public class Adventurer
{
    private string name;
    private int level;
    private int powerLevel;

    Adventurer(string name, int level)
    {
        this.name = name;
        this.level = level;
        powerLevel = 0;
    }
}
