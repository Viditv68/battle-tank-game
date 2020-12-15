using UnityEngine;

public class ExplosionController : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem tankExplosionParticle;
    
    [SerializeField]
    private ParticleSystem bulletExplosionParticle;


    public void Explode(ParticleSystem explosionParticle )
    {
        explosionParticle.transform.parent = null;
        explosionParticle.Play();
        Destroy(explosionParticle.gameObject, 2f);
    }

   
}
