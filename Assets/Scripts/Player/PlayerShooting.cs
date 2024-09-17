using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Camera playerCamera;         // Reference to the player's camera
    public float shootingRange = 100f;  // Maximum range of the weapon
    public float bulletDamage = 20f;    // Damage dealt by the weapon
    public GameObject impactEffect;     // Effect to spawn on impact
    public float fireRate = 0.2f;       // Rate of fire for the weapon
    private float nextTimeToFire = 0f;  // Time when the player can shoot again

    void Update()
    {
        // Shoot when left mouse button is pressed and fire rate allows
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // Raycast from the camera to where the player is looking
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, shootingRange))
        {
            Debug.Log("Hit: " + hit.transform.name);  // Debug message to see what is hit

            // If the object hit has an EnemyHealth component, deal damage
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bulletDamage);
            }

            // Instantiate the impact effect at the point of impact
            if (impactEffect != null)
            {
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }
}