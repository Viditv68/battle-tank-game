using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    [SerializeField]
    private TankScriptableObject tankScriptableObject;

    [SerializeField]
    private CameraController camera;

    public bool playerDead;
    
    public Joystick joystick;


    private void Start()
    {
        GameObject tank = Instantiate(tankScriptableObject.tankPref, Vector3.zero, Quaternion.identity);
        tank.GetComponent<TankController>().InitializeValues(tankScriptableObject);
        camera.player = tank;
        playerDead = false;
    }


    public void DestroyTankOrBullet(ParticleSystem explosionParticle, AudioSource explosionAudio)
    {
        explosionParticle.transform.parent = null;

        explosionParticle.Play();
        explosionAudio.Play();

        Destroy(explosionParticle.gameObject, 2f);
        
    }

    
    

}
