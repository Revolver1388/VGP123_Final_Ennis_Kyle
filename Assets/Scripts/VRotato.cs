using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRotato : MonoBehaviour
{
    public Transform player;
    private float currentAngle = 0;
    public float maxAngleDown = 3;
    public float maxAngleUp = 45;
    public float rotateSpd = 15;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        float deltaRotation = Input.GetAxis("Mouse Y") * rotateSpd * Time.deltaTime;
        currentAngle += deltaRotation;
        currentAngle = Mathf.Clamp(currentAngle, -maxAngleDown, maxAngleUp);

        float angleInRadians = currentAngle * Mathf.Deg2Rad;

        //Vector3 newLookAtDirection = Mathf.Cos(currentAngle) * player.forward + Mathf.Sin(angleInRadians) * player.up; //can look around the room with this feature

        Vector3 newLookAtDirection = Mathf.Cos(angleInRadians) * player.forward + Mathf.Sin(angleInRadians)* player.up;
        Vector3 newlookatPoint = transform.position + newLookAtDirection;
        transform.LookAt(newlookatPoint);
    }
}