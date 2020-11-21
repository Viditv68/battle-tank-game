using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour, IDamagable
{
    public TankView tankView;
    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private ParticleSystem tankExplosionParticle;
    [SerializeField]
    private ExplosionController explosionController;
    [SerializeField]
    private AudioSource tankExplosionAudio;

    private int health;
    private int speed;
    private int damage;

    private int bulletLayer = 8;

    private void Awake()
    {
        tankView.Initialize(this);
        
    }
    

    public void InitializeValues(TankScriptableObject tankScriptableObject)
    {
        health = tankScriptableObject.health;
        healthSlider.maxValue = health;

        speed = tankScriptableObject.speed;
        damage = tankScriptableObject.speed;
    }

    public void TakeDamage(int damage)
    {
        health -= 10;
        healthSlider.value = health;

        if (health <= 0)
        {
            explosionController.Explode(tankExplosionParticle, tankExplosionAudio);
            Destroy(gameObject);

        }
    }

    

}
