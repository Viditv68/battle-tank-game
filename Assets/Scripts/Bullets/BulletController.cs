using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosionParticle;
    [SerializeField]
    private AudioSource bulletExplosionAudio;
    [SerializeField]
    private ExplosionController explosionController;

    private void OnCollisionEnter(Collision other)
    {
        explosionController.Explode(explosionParticle, bulletExplosionAudio);
        
        Destroy(gameObject);

        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
        if(damagable !=null)
        {
            damagable.TakeDamage(10);
        }
         
    }

    


}
