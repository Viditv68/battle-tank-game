using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour, IDamagable
{
    [SerializeField]
    public Slider healthSlider;

    [SerializeField]
    private ParticleSystem tankExplosionParticle;
    [SerializeField]
    private AudioSource tankExplosionAudio;
    [SerializeField]
    private ExplosionController explosionController;

    public Transform fireTransform;

    private float movementSpeed = 12f;
    private float turnSpeed = 180f;
    private Joystick joystick;
    private Rigidbody rigidbody;

    private int health;
    private int speed;
    private int damage;

   
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        joystick = TankService.Instance.joystick.GetComponent<FixedJoystick>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            BulletService.Instance.Fire(fireTransform);
            EventService.Instance.InvokeFireEvent();

        }
    }

    private void FixedUpdate()
    {
        Movement();
        Turn();
    }

    

    public void InitializeValues(TankScriptableObject tankScriptableObject)
    {
        health = tankScriptableObject.health;
        healthSlider.maxValue = health;
        speed = tankScriptableObject.speed;
        damage = tankScriptableObject.damage;

    }

    private void Turn()
    {
        if (joystick.Horizontal > .2f || joystick.Horizontal < -.2f)
        {

            float turn = joystick.Horizontal * turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
        }
    }

    private void Movement()
    {
        if (joystick.Vertical > .2f || joystick.Vertical < -.2f)
        {
            Vector3 movement = transform.forward * joystick.Vertical * movementSpeed * Time.deltaTime;
            rigidbody.MovePosition(rigidbody.position + movement);
        }
    }




    public void TakeDamage(int damage)
    {
        health -= damage;
        healthSlider.value = health;

        if (health <= 0)
        {
            explosionController.Explode(tankExplosionParticle);
            Destroy(gameObject);
            TankService.Instance.playerDead = true;
        }
    }

    


}
