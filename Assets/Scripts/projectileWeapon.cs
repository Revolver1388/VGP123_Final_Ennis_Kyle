using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileWeapon : weapons {

    public GameObject projectiles;

    public override void launchProjectiles()
    {
        base.launchProjectiles();
        GameObject spawnProjectile = Instantiate(projectiles, bulletSpawn.transform.position, Quaternion.identity);
        spawnProjectile.transform.rotation = bulletSpawn.transform.rotation;
        spawnProjectile.GetComponent<Projectile>().GiveInitialVelocity();
    }
}
