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
    private int turretSpeed = 20;

    private TankState currentState;

    [SerializeField]
    private GameObject tankTurret;

    private bool rotateTurret;

    private void Start()
    {
        rotateTurret = true;
        ChangeState(startingState);
    }

    private void Update()
    {
        if(rotateTurret)
        {
            tankTurret.transform.Rotate(Vector3.up * turretSpeed * Time.deltaTime);
        }
            
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
            EventService.Instance.InvokeEnemyKilledEvent();
            explosionController.Explode(tankExplosionParticle);
            
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

    private bool IsEnemyTurretFacingPlayer(GameObject player)
    {
        float cosAngle = Vector3.Dot((player.transform.position - this.transform.position).normalized, tankTurret.transform.forward);
        float angle = Mathf.Acos(cosAngle) * Mathf.Rad2Deg;

        return angle <= 5;

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<TankController>())
        {
            
            if(IsEnemyTurretFacingPlayer(other.gameObject))
            {
                rotateTurret = false;
                Debug.Log("Fire player");
                ChangeState(tankAttackState);
            }

            else
            {
                rotateTurret = true;
            }
            
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
