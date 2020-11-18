using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrollingState : TankState
{
    private TankView tankView;
    private float timeElapsed = 0f;
    private void Start()
    {
        tankView = GetComponent<TankView>();
    }
    public override void OnEnterState()
    {
        
        base.OnEnterState();
        Debug.Log("tank is in patrolling state");
    }

    public override void OnExitState()
    {
        base.OnExitState();
        
    }

    
    
}
