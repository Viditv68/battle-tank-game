using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public GameObject tankPref;

    private void Start()
    {
        GameObject tank = Instantiate(tankPref, Vector3.zero, Quaternion.identity);
    }
    

}
