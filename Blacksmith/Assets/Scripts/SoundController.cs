﻿using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

    private AudioSource hammerHit;
    private AudioSource bellowsDown;
    private AudioSource forgeAmbient;
    //private AudioSource cooling;
    private AudioSource craftingMusic;

    private AudioSource hammerHit1;
    private AudioSource hammerHit2;
    private AudioSource hammerHit3;
    private AudioSource hammerHit4;
    private AudioSource hammerHit5;

	// Use this for initialization
	void Start () 
    {
        hammerHit = GameObject.Find("Sounds/HammerHit").GetComponent<AudioSource>();
        bellowsDown = GameObject.Find("Sounds/BellowsDown").GetComponent<AudioSource>();
        forgeAmbient = GameObject.Find("Sounds/ForgeAmbient").GetComponent<AudioSource>();
        craftingMusic = GameObject.Find("Music/CraftingMusic").GetComponent<AudioSource>();
        //cooling = GameObject.Find("Sounds/Cooling").GetComponent<AudioSource>();

        hammerHit1 = GameObject.Find("Sounds/HammerHit1").GetComponent<AudioSource>();
        hammerHit2 = GameObject.Find("Sounds/HammerHit2").GetComponent<AudioSource>();
        hammerHit3 = GameObject.Find("Sounds/HammerHit3").GetComponent<AudioSource>();
        hammerHit4 = GameObject.Find("Sounds/HammerHit4").GetComponent<AudioSource>();
        hammerHit5 = GameObject.Find("Sounds/HammerHit5").GetComponent<AudioSource>();

        Random.seed = (int)System.DateTime.Now.Ticks;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayHammerHit()
    {
        int hammerHit = Random.Range(1, 5);
        
        switch(hammerHit)
        {
            case 1:
                hammerHit1.Play();
                break;
            case 2:
                hammerHit2.Play();
                break;
            case 3:
                hammerHit3.Play();
                break;
            case 4:
                hammerHit4.Play();
                break;
            case 5:
                hammerHit5.Play();
                break;
        }
    }

    public void PlayBellowsDown()
    {
        bellowsDown.Play();
    }

    public void PlayForgeAmbient()
    {
        if (!forgeAmbient.isPlaying)
        {
            forgeAmbient.Play();
        }
        else
        {
            forgeAmbient.Stop();
        }
    }

    /*public void PlayCooling()
    {
        cooling.Play();
    }

    public bool IsCoolingPlaying()
    {
        return cooling.isPlaying;
    }*/

    public void PlayCraftingMusic()
    {
        if (!craftingMusic.isPlaying)
        {
            craftingMusic.Play();
        }
        else
        {
            craftingMusic.Stop();
        }
    }

    public void StopAllCrafingNoise()
    {
        PlayForgeAmbient();
        PlayCraftingMusic();
    }
}
