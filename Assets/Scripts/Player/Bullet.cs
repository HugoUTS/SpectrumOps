using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;        // The bullet prefab
    public Transform bulletSpawnPoint;     // The point where the bullet will be instantiated
    public float bulletSpeed = 20f;        // The speed of the bullet
    public float bulletLifetime = 1f;      // Time before the bullet is destroyed
    public KeyCode shootKey = KeyCode.Mouse0; // Key to fire the gun (left mouse button)
    public Animator gunAnim; // To access the held gun's animation
    public bool canShoot = false;

    void Update()
    {
        // Check if the player presses the fire button
        if (Input.GetKeyDown(shootKey))
        {
            gunAnim.SetTrigger("Shoot");
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the gun's bullet spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Get the Rigidbody component from the bullet and add velocity to it
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawnPoint.forward * bulletSpeed;

        // Destroy the bullet after some time to prevent it from persisting forever
        Destroy(bullet, bulletLifetime);

        
        void OnCollisionEnter(Collision collision)
        {
            // Destroy the bullet on impact
            Destroy(gameObject);
        }
    }
}