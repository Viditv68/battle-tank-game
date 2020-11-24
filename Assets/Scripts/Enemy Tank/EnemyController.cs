using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private ParticleSystem tankExplosionParticle;
    [SerializeField]
    private ExplosionController explosionController;
    [SerializeField]
    private AudioSource tankExplosionAudio;

    [SerializeField]
    private TankState startingState;
    [SerializeField]
    private TankAttackState tankAttackState;

    private int health;
    private int speed;
    private int damage;

    private TankState currentState;


    private void Start()
    {
        ChangeState(startingState);
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
        health -= damage;
        healthSlider.value = health;

        if (health <= 0)
        {
            explosionController.Explode(tankExplosionParticle, tankExplosionAudio);
            Destroy(gameObject);
        }
    }

    public void ChangeState(TankState newState)
    {
        if (currentState != null)
        {
            currentState.OnExitState();
        }

        currentState = newState;
        Debug.Log(currentState);
        currentState.OnEnterState();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TankController>())
        {
            ChangeState(tankAttackState);
            gameObject.GetComponent<TankAttackState>().InitilaizePlayerTank(other.gameObject.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<TankController>())
        {
            ChangeState(startingState);
        }
    }



}
