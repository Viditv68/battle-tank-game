using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class TankState : MonoBehaviour
{ 
    public virtual void OnEnterState()
    {
        this.enabled = true;
    }

    public virtual void OnExitState()
    {

        this.enabled = false;
    }

    

    
}
