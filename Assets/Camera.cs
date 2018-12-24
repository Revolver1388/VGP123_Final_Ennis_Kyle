using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform target;
    public float lerpSpd = 10;
    public int rotateSpd = 5;

    public float offset = 20;
    public float offsetZ = 5;
    public float offsetY = 0;
    public float offsetX = 0;

    public float targeter;

	void Start () {
		
	}

    void Update()
    {
        Vector3 newPosition = target.position;
        transform.position = target.position - offset * target.forward;
        float look = rotateSpd * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, newPosition.normalized, lerpSpd * Time.deltaTime);
        transform.LookAt(target);

        newPosition += offsetX * target.right;
        newPosition += offsetY * target.up;
        newPosition += offsetZ * target.forward;
        //transform.position = target.position + offsetY * target.up;
       
    }

}
