using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcontrol : MonoBehaviour {

    public Animator AIController;
    public float detectionRange = 30;
    public float visionAngle = 60;
    public float shootingRange = 15;
    public float speed = 5;
    const float seperation = 2.5f;
    const float approach = 5.0f;

  
    

    public GameObject playerObject;
    public GameObject alertGameObject;
    public weapons weapon;
    public GameObject fire;
    public Animator anim;

    void Update()
    {
        //check if player detected

        Vector3 toPlayer = playerObject.transform.position - transform.position;
        bool Detected = toPlayer.magnitude < detectionRange && Vector3.Angle(toPlayer, transform.forward) < visionAngle;
        AIController.SetBool("Detected", Detected);
        bool InRange = toPlayer.magnitude < shootingRange;
        AIController.SetBool("inRange", InRange);
       

    }
    public void closeIn()
    {

        transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, speed * Time.deltaTime);
    }

}
