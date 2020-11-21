using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public void Explode(ParticleSystem explosionParticle, AudioSource explosionAudio)
    {
        explosionParticle.transform.parent = null;

        explosionParticle.Play();
        explosionAudio.Play();

        Destroy(explosionParticle.gameObject, 2f);

    }
}
