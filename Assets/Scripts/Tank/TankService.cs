using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    [SerializeField]
    private TankScriptableObject tankScriptableObject;
    [SerializeField]
    private CameraController cameraController;

    public bool playerDead;

    
    public Joystick joystick;


    private void Start()
    {
        GameObject tank = Instantiate(tankScriptableObject.tankPref, Vector3.zero, Quaternion.identity);
        tank.GetComponent<TankController>().InitializeValues(tankScriptableObject);
        cameraController.playerTransform = tank.transform;
        playerDead = false;
    }


    

    
    

}
