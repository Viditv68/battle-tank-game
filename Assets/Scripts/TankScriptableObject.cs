using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObjects", menuName = "Scriptable Objects/New Tank")]
public class TankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public GameObject tankPref;
    public int health;
    public int speed;
    public int damage;

}
