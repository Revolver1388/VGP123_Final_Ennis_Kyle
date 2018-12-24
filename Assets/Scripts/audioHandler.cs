using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioHandler : MonoBehaviour {

    public AudioSource src;
    public AudioClip footstep;

	// Use this for initialization
	void Start () {
        if (!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
        src = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playFootstep()
    {
        src.PlayOneShot(footstep);
    }
}
