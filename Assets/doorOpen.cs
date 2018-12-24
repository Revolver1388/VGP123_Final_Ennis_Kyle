using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour {
    public AudioSource src;
    public AudioClip Door;
    public Animator anim;
    public string open;
    // Use this for initialization

    void Start () {
        if (!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
        src = GetComponent<AudioSource>();
    }



    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
            anim.SetBool(open, true);
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
            anim.SetBool(open, false);
    }

}

