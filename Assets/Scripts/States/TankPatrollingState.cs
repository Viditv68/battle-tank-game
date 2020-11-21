using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrollingState : TankState
{
    
    private Vector3 tankStartingPosition;

    private Vector3 spot2;
    private Vector3 moveToSpot;

    private TankView tankView;
    private float timeElapsed = 0f;
    public float speed;


    private void Awake()
    {
        tankStartingPosition = transform.position;
        spot2.z = transform.position.z + 18f;
        moveToSpot = spot2;
    }
    private void Start()
    {

        tankView = GetComponent<TankView>();
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

        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        if(moveToSpot.z - transform.position.z < 0.2f)
        {

            
            if (moveToSpot == spot2)
            {
                moveToSpot = tankStartingPosition;
            }
            else
            {
                moveToSpot = spot2;
            }
        }

        
    }

}
