using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosionParticle;
    [SerializeField]
    private AudioSource bulletExplosionAudio;



    [SerializeField]
    private float fireSpeed = 20f;



    public void Fire(Transform fireTransform, GameObject tank)
    {

        GameObject bullet = Instantiate(gameObject, fireTransform.position, fireTransform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        bulletRigidbody.velocity = fireSpeed * tank.transform.forward;
    }


    private void OnCollisionEnter(Collision other)
    {
        TankService.Instance.DestroyTankOrBullet(explosionParticle, bulletExplosionAudio);
        Destroy(gameObject);

        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
        if(damagable !=null)
        {
            damagable.TakeDamage(10,other.gameObject);
        }
         
    }

    


}
