using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttackState : TankState
{

    [SerializeField]
    private Transform fireTransfrom;
    private Transform playerTankPosition;

    private float nextFire = 3f;
    
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Tank is in attack State");
        
    }

    public override void OnExitState()
    {
        base.OnExitState();
        
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        nextFire += Time.deltaTime;
        if (nextFire > 3f)
        {
            BulletService.Instance.Fire(fireTransfrom);
            nextFire = 0f;
        }
    }

  



}
