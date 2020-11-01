using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAlongY : MonoBehaviour
{
    public float speed = 100;

    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
