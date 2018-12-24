using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCastWeapn : weapons {

    public GameObject hitEffect;
    public GameObject bulletTrail;

    public float range = 100;

    public override void launchProjectiles()
    {
        base.launchProjectiles();
        RaycastHit hit;
        GameObject  trail = Instantiate(bulletTrail, bulletSpawn.position, Quaternion.identity);
        trail.transform.rotation = bulletSpawn.rotation;
        if(Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, range))
        {
            Instantiate(hitEffect, hit.point, Quaternion.identity);
            float distance = Vector3.Distance(bulletSpawn.position, hit.point);
            trail.transform.localScale = new Vector3(1, 1, distance);
            if (hit.collider.gameObject.GetComponent<hitBox>())
            {
                hit.collider.gameObject.GetComponent<hitBox>().onHit.Invoke(weaponDamage * bulletSpawn.forward);
            }
        }
        else
        {
            trail.transform.localScale = new Vector3(1, 1, range);
        }
    }
}
