using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankChasingState : TankState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Tank is in Chasing State");
    }
    
}
