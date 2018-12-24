using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour {

    public float initialSpeedForward;
    public float damage = 15f;

    private void OnCollisionEnter(Collision c)
    {
        Destroy(this.gameObject);
        if (c.rigidbody.gameObject.GetComponent<hitBox>()) ;
        {
            c.gameObject.GetComponent<hitBox>().onHit.Invoke(damage * transform.forward);
        }

    }
    public void GiveInitialVelocity()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * initialSpeedForward, ForceMode.Impulse);
    }
}
   
