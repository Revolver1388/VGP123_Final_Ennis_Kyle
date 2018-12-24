using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour {

    public float fireRate = 10;
    public int magazineSize = 30;
    public int reloadTime = 1;
    public float weaponDamage;

    public Transform bulletSpawn;

    private bool firing = false;
    public bool reloading = false;
    private int bulletsRemaining;
    private float timer;


    //audio
    public AudioSource src;
    public AudioClip fireSound;
    public AudioClip imFireMyLazer;
    public AudioClip reloadSound;
	// Use this for initialization
	void Start () {
        bulletsRemaining = magazineSize;
        if (!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
        src = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (firing)
        {
            if (timer <= 0 && !reloading)
            {
                if (bulletsRemaining > 0)
                {
                    launchProjectiles();
                    timer = 1 / fireRate;
                }
                else
                {
                    reload();
                }
            }
            
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
	}
    public void Fire(bool toggle)
    {
        firing = toggle;
    }

    public virtual void launchProjectiles()
    {
       
        bulletsRemaining--;
        src.PlayOneShot(fireSound);
    }
    
    void reload()
    {
        reloading = true;
        src.PlayOneShot(reloadSound);
        StartCoroutine("reloadCoroutine");
    }

    IEnumerator reloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        bulletsRemaining = magazineSize;
        reloading = false;
    }


}
