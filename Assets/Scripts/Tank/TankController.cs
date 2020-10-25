using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    public TankScriptableObject tankScriptableObject;
    public Slider healthSlider;
    public GameObject bulletPref;
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

    private void Awake()
    {
        InitializeValues();
    }

    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();

        }
    }

    private void FixedUpdate()
    {
        Movement();
        Turn();
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPref, fireTransform.position, fireTransform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        bulletRigidbody.velocity = fireSpeed * transform.forward;


        
    }

    private void InitializeValues()
    {
        health = tankScriptableObject.health;
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




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == bulletLayer)
        {
            health -= 10;
            healthSlider.value = health;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


}
