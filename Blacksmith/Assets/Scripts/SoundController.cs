using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

    private AudioSource hammerHit;
    private AudioSource bellowsDown;
    private AudioSource forgeAmbient;

	// Use this for initialization
	void Start () 
    {
        hammerHit = GameObject.Find("Sounds/HammerHit").GetComponent<AudioSource>();
        bellowsDown = GameObject.Find("Sounds/BellowsDown").GetComponent<AudioSource>();
        forgeAmbient = GameObject.Find("Sounds/ForgeAmbient").GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayHammerHit()
    {
        hammerHit.Play();
    }

    public void PlayBellowsDown()
    {
        bellowsDown.Play();
    }

    public void PlayForgeAmbient()
    {
        forgeAmbient.Play();
    }

    public void StopForgeAmbient()
    {
        forgeAmbient.mute = true;
    }
}
