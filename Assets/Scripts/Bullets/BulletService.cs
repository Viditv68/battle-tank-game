using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public GameObject bulletPref;
    public float fireSpeed = 20f;

    public void Fire(Transform fireTransform)
    {
        GameObject bullet = Instantiate(bulletPref, fireTransform.position, fireTransform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        bulletRigidbody.velocity = fireSpeed * transform.forward;
    }
}
