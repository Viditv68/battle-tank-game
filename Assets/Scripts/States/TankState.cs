using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankView))]
public class TankState : MonoBehaviour
{
    protected TankView tankView;
    private void Awake()
    {
        tankView = GetComponent<TankView>();
    }
    public virtual void OnEnterState()
    {
        this.enabled = true;
    }

    public virtual void OnExitState()
    {

        this.enabled = false;
    }

    

    
}
