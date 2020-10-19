using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoSingletonGeneric<TankController>
{
    private float movementSpeed = 12f;
    private float turnSpeed = 180f;
    public Joystick joystick;
    private Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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
