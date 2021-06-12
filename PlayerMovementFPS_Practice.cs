using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFPS_Practice : MonoBehaviour
{

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;

    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.9f;
    public LayerMask groundMask;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {   

        isGrounded = Physics.CheckSphere(groundCheck.position , groundDistance , groundMask);

        Debug.Log(isGrounded);
        

        if ( isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        //! Implementing Player Movement

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //! Implementing Jumps

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * gravity * -2f);
        }

        //! Implementing Free Fall Gravity

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
