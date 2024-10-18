using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMace : MonoBehaviour
{
    public Transform rotationCenter;

    public float rotationSpeed = 100f; 

    void Update()
    {
        transform.RotateAround(rotationCenter.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }


}
