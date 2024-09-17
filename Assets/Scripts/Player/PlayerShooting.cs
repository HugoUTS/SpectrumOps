using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Camera playerCamera;           // Reference to the player's camera
    public float shootingRange = 100f;    // Maximum range of the weapon
    public float bulletDamage = 20f;      // Damage dealt by the weapon
    public GameObject impactEffect;       // Effect to spawn on impact
    public float fireRate = 0.2f;         // Rate of fire for the weapon
    private float nextTimeToFire = 0f;    // Time when the player can shoot again

    public string weaponColor;            // Either "Red" or "Blue" depending on the weapon

    void Update()
    {
        // Shoot when left mouse button is pressed and fire rate allows
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            AttemptShoot();
        }
    }

    void AttemptShoot()
    {
        // Raycast from the camera to where the player is looking
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, shootingRange))
        {
            Debug.Log("Hit: " + hit.transform.name);  // For debugging

            // Check if the object hit is an enemy
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                string enemyColor = enemyHealth.enemyColor;  // Check the enemy's color

                // Only shoot if the weapon color matches the enemy color
                if (weaponColor == enemyColor)
                {
                    // Correct color, proceed with shooting and dealing damage
                    Shoot(hit, enemyHealth);
                }
                else
                {
                    // Provide feedback for targeting the wrong color
                    Debug.Log("Wrong weapon color! Cannot shoot.");
                }
            }
            else
            {
                // If not an enemy, still shoot (for non-enemy targets like walls, etc.)
                Shoot(hit, null);
            }
        }
    }

    void Shoot(RaycastHit hit, EnemyHealth enemyHealth)
    {
        // Deal damage if an enemy was hit
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(bulletDamage);
        }

        // Instantiate impact effect at the point of impact
        if (impactEffect != null)
        {
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
