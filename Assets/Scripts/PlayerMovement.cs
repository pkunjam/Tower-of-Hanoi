using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// This script is attached to the player gameobject
// Responsible for first person movement operations

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller; // controls the movement of the player
    public float speed; // movement speed
    Vector2 rotation = Vector2.zero; // rotation value

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // horizontal input value
        float z = Input.GetAxis("Vertical"); // vertical input value

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // hold right click to look around
        if (Input.GetMouseButton(1))
        {
            rotation.y += Input.GetAxis("Mouse X");
            Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * speed, rotation.y * speed, 0);
        }

    }

}
