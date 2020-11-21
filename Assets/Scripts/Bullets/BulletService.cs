using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public GameObject BulletPrefab;

    [SerializeField]
    private float fireSpeed = 20f;

    public void Fire(Transform fireTransform, Transform tank)
    {

        GameObject bullet = Instantiate(BulletPrefab, fireTransform.position, fireTransform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        bulletRigidbody.velocity = fireSpeed * tank.transform.forward;
    }
}
