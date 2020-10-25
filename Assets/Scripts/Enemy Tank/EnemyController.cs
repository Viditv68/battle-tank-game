﻿using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public TankScriptableObject tankScriptableObject;

    public Slider healthSlider;

    private int health;
    private int speed;
    private int damage;

    private int bulletLayer = 8;

    private void Start()
    {
        InitializeValues();
    }

    private void InitializeValues()
    {
        health = tankScriptableObject.health;
        speed = tankScriptableObject.speed;
        damage = tankScriptableObject.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == bulletLayer)
        {
            health -= 10;
            healthSlider.value = health;

            if(health <=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
