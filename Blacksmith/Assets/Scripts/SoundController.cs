using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

    // SOUNDS
    private AudioSource hammerHit;
    private AudioSource bellowsBlow;
    private AudioSource forgeAmbient;
    private AudioSource cooling;
    private AudioSource hammerHit1;
    private AudioSource hammerHit2;
    private AudioSource hammerHit3;
    private AudioSource hammerHit4;
    private AudioSource hammerHit5;
    private AudioSource button;
    private AudioSource grinding1;
    private AudioSource grinding2;
    private AudioSource polishing;
    private AudioSource sharpening;

    // MUSIC
    private AudioSource craftingMusic;
    private AudioSource workshopMusic;

    void Awake ()
    {
        // SOUNDS
        hammerHit = GameObject.Find("Sounds/HammerHit").GetComponent<AudioSource>();
        bellowsBlow = GameObject.Find("Sounds/BellowsBlow").GetComponent<AudioSource>();
        forgeAmbient = GameObject.Find("Sounds/ForgeAmbient").GetComponent<AudioSource>();
        cooling = GameObject.Find("Sounds/Cooling").GetComponent<AudioSource>();
        grinding1 = GameObject.Find("Sounds/Grinding1").GetComponent<AudioSource>();
        grinding2 = GameObject.Find("Sounds/Grinding2").GetComponent<AudioSource>();
        polishing = GameObject.Find("Sounds/Polishing").GetComponent<AudioSource>();
        sharpening = GameObject.Find("Sounds/Sharpening").GetComponent<AudioSource>();
        hammerHit1 = GameObject.Find("Sounds/HammerHit1").GetComponent<AudioSource>();
        hammerHit2 = GameObject.Find("Sounds/HammerHit2").GetComponent<AudioSource>();
        hammerHit3 = GameObject.Find("Sounds/HammerHit3").GetComponent<AudioSource>();
        hammerHit4 = GameObject.Find("Sounds/HammerHit4").GetComponent<AudioSource>();
        hammerHit5 = GameObject.Find("Sounds/HammerHit5").GetComponent<AudioSource>();
        button = GameObject.Find("Sounds/Button").GetComponent<AudioSource>();

        // MUSIC
        craftingMusic = GameObject.Find("Music/CraftingMusic").GetComponent<AudioSource>();
        workshopMusic = GameObject.Find("Music/WorkshopMusic").GetComponent<AudioSource>();

        Random.seed = (int)System.DateTime.Now.Ticks;
    }
	// Use this for initialization
	void Start () 
    {
      
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

    public void playBellowsBlow()
    {
        if (!bellowsBlow.isPlaying)
        {
            bellowsBlow.Play();
        }
    }

    public void playCooling()
    {
        if (!cooling.isPlaying)
        {
            cooling.Play();
        }
    }

    public bool isCoolingPlaying()
    {
        return cooling.isPlaying;
    }

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

    public void playButton()
    {
        button.Play();
    }

    public void StopAllCrafingNoise()
    {
        PlayForgeAmbient();
        PlayCraftingMusic();
    }

    public void playWorkshopMusic()
    {
        if (!workshopMusic.isPlaying)
        {
            workshopMusic.Play();
        }
        else
        {
            workshopMusic.Stop();
        }
    }

    public bool isWorkshopMusicPlaying()
    {
        return workshopMusic.isPlaying;
    }

    public void playPolishing()
    {
        if (!polishing.isPlaying)
        {
            polishing.Play();
        }
    }

    public void playGrinding()
    {
        if (!grinding1.isPlaying)
        {
            grinding1.Play();
        }
        else
        {
            grinding1.Stop();
        }
    }

    public void playSharpening()
    {
        if (!sharpening.isPlaying)
        {
            sharpening.Play();
        }
    }
}
