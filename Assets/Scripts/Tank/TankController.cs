using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    [SerializeField]
    public Slider healthSlider;
    [SerializeField]
    private BulletController bulletController;

    [SerializeField]
    private ParticleSystem tankExplosionParticle;
    [SerializeField]
    private AudioSource tankExplosionAudio;

    public Transform fireTransform;

    private int bulletLayer = 8;
    private float fireSpeed = 15f;
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
            bulletController.Fire(fireTransform, this.gameObject);

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




    public void ApplyDamage(int damage)
    {
        health -= 10;
        healthSlider.value = health;

        if (health <= 0)
        {
            TankService.Instance.DestroyTankOrBullet(tankExplosionParticle, tankExplosionAudio);
            Destroy(gameObject);
            TankService.Instance.playerDead = true;
        }
    }


}
