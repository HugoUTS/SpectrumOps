using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject Bullet_Handgun_Blue;      
    public Transform bulletSpawnPoint;  
    public float bulletSpeed = 10f;      
    public float shootInterval = 2f;     
    
    private float nextShootTime = 0f;

    void Update()
    {
        
        if (Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootInterval;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(Bullet_Handgun_Blue, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        
        Destroy(bullet, 5f); 
    }
}
