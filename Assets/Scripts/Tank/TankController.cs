using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private float movementSpeed = 12f;
    private float turnSpeed = 180f;
    private Joystick joystick;
    private Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
        Turn();
    }

    private void Turn()
    {
        if (joystick.Horizontal > .2f || joystick.Horizontal < -.2f)
        {

            float turn = joystick.Horizontal * turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
        }
    }

    private void Movement()
    {
        if (joystick.Vertical > .2f || joystick.Vertical < -.2f)
        {
            Vector3 movement = transform.forward * joystick.Vertical * movementSpeed * Time.deltaTime;
            rigidbody.MovePosition(rigidbody.position + movement);
        }
    }

    
}
