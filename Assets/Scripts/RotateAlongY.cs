using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the cubes placed above each of the towers
// Script to rotate any object along y-axis

public class RotateAlongY : MonoBehaviour
{
    public float speed = 100;

    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
