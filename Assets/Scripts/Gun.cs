using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletObj;

    [SerializeField] float shootForce;
    [SerializeField] Transform bulletHandler;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletObj, transform.position, transform.rotation, bulletHandler);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * shootForce;
    }
}
