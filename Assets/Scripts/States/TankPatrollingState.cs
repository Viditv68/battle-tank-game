using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrollingState : TankState
{
    
    private Vector3 tankStartingPosition;

    private Vector3 spot2;
    private Vector3 moveToSpot;

    private float timeElapsed = 0f;
    public float speed;
    private float speedRef;
    private int direction = 1;

    private bool isTurning = false;
    
    private void Awake()
    {
        tankStartingPosition = transform.position;
        spot2.z = transform.position.z + 18f;
        moveToSpot = spot2;
    }
    
    public override void OnEnterState()
    {
        base.OnEnterState();
               
    }

    public override void OnExitState()
    {
        base.OnExitState();
        
    }

    private void Update()
    {
        
        Move(speed);
        
        if (Mathf.Abs(moveToSpot.z - transform.position.z) < 0.1f)
        {
            ChangeSpot();
        }
       
    }

    private void ChangeSpot()
    {
        StartCoroutine(Turn());

        if (moveToSpot == spot2)
        {
            moveToSpot = tankStartingPosition;
            direction = -1;
        }
        else if (moveToSpot == tankStartingPosition)
        {
            moveToSpot = spot2;
            direction = 1;
        }
    }

    private void Move(float speed)
    {
        if(!isTurning)
            transform.Translate(Vector3.forward * speed * Time.deltaTime * direction, Space.World);
    }
    

    IEnumerator Turn()
    {
        isTurning = true;
        yield return new WaitForSeconds(2f);
        isTurning = false;
    }

}
