using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    public List<Rigidbody> wallPieaces;
    public float health = 6;
    private float currentHealth;
    public AudioSource src;
    public AudioClip explode;

    private void Start()
    {
        currentHealth = health;
        if (!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
        src = GetComponent<AudioSource>();
    }

    public void Break(Vector3 breakForce)
    {
        currentHealth -= breakForce.magnitude;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            foreach (Rigidbody rb in wallPieaces)
            {
            src.PlayOneShot(explode);
                rb.gameObject.transform.parent = null;
                rb.gameObject.SetActive(true);
                rb.isKinematic = false;
                rb.AddForce((breakForce.normalized + Random.Range(-1.0f, 1.0f) * Vector3.Cross(breakForce.normalized, Vector3.up)) * 100, ForceMode.Impulse);
            }
        }
    }
}
