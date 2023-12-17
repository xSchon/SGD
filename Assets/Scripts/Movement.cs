using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to control the movement speed
    public float jumpForce = 8f; // Adjust this value to control the jump force
    public bool isGrounded; // Flag to check if the camera is grounded

    void Update()
    {
        // Check if the camera is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Get input from arrow keys or WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the camera based on input
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space)) //&& isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }
}
