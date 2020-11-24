using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttackState : TankState
{
    [SerializeField]
    private GameObject turret;
    [SerializeField]
    private Transform fireTransfrom;
    private Transform playerTankPosition;

    private float nextFire = 3;
    
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
        if(playerTankPosition != null)
        {
            turret.transform.LookAt(playerTankPosition);

            nextFire += Time.deltaTime;
            if(nextFire > 3)
            {
                BulletService.Instance.Fire(fireTransfrom);
                nextFire = 0;
            }
        }
    }

    public void InitilaizePlayerTank(Transform playerTankPosition)
    {
        this.playerTankPosition = playerTankPosition;
    }



}
