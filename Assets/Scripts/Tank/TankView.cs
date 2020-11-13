using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour, IDamagable
{

    public void TakeDamage(int damage, GameObject gameObject)
    {
        if(gameObject.GetComponent<EnemyController>())
        {
            gameObject.GetComponent<EnemyController>().ApplyDamage(damage);
        }
        else
        {
            gameObject.GetComponent<TankController>().ApplyDamage(damage);
        }
    }
}
