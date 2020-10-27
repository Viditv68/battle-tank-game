using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    //public GameObject tankPref;
    public TankScriptableObject tankScriptableObject;
    public Joystick joystick;


    private void Start()
    {
        GameObject tank = Instantiate(tankScriptableObject.tankPref, Vector3.zero, Quaternion.identity);
    }

    
    

}
