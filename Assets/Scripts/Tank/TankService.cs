﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    [SerializeField]
    private TankScriptableObject tankScriptableObject;

    public bool playerDead;

    
    
    public Joystick joystick;


    private void Start()
    {
        GameObject tank = Instantiate(tankScriptableObject.tankPref, Vector3.zero, Quaternion.identity);
        tank.GetComponent<TankController>().InitializeValues(tankScriptableObject);
        playerDead = false;
    }


    public void DestroyTankOrBullet(ParticleSystem explosionParticle, AudioSource explosionAudio)
    {
        explosionParticle.transform.parent = null;

        explosionParticle.Play();
        explosionAudio.Play();

        Destroy(explosionParticle.gameObject, 2f);
        
    }

    
    

}
