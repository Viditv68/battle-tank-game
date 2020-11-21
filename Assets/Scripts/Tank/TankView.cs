using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankState currentState;

    [SerializeField]
    private TankState startingState;
    [SerializeField]
    private TankChasingState tankChasingState;
    private EnemyController enemyController;

    private void Start()
    {
        if(!GetComponent<TankController>())
            ChangeState(startingState);

        
    }

 
    public void Initialize(EnemyController enemyController)
    {
        this.enemyController = enemyController;
        

    }

    public void ChangeState(TankState newState)
    {
        if (currentState != null)
        {
            currentState.OnExitState();
        }
        
        currentState = newState;
        
        currentState.OnEnterState();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TankController>())
        {
            ChangeState(tankChasingState);
        }
    }

}
