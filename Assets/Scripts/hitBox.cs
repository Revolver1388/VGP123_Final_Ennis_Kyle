using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyVectorEvent : UnityEvent<Vector3>
{

}

public class hitBox : MonoBehaviour
{
    public MyVectorEvent onHit;

    
}
