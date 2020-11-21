using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankChasingState : TankState
{
    public GameObject playerTank;
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Tank is in Chasing State");

        
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTank.transform.position, 8 * Time.deltaTime);
    }



}
