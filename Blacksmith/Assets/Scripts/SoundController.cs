using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

    private AudioSource hammerHit;

	// Use this for initialization
	void Start () 
    {
        hammerHit = GameObject.Find("Sounds/HammerHit").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayHammerHit()
    {
        hammerHit.Play();
    }
}
