using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float fireSpeed = 20f;
    public void Fire(Transform fireTransform, GameObject tank)
    {
        GameObject bullet = Instantiate(gameObject, fireTransform.position, fireTransform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        bulletRigidbody.velocity = fireSpeed * tank.transform.forward;
    }



    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
