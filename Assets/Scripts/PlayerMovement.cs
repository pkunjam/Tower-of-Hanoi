using UnityEngine;
using System.Collections.Generic;
using System.Collections;

    public class PlayerMovement : MonoBehaviour
    {

    public CharacterController controller;

    public float speed;
    Vector2 rotation = Vector2.zero;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * speed, rotation.y * speed, 0);

    }

}
