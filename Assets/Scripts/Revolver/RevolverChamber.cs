using UnityEngine;

public class RevolverChamber : MonoBehaviour
{
    public RectTransform chamberIcon; // Reference to gun chamber
    public int totalChambers = 6;    // Number of chambers in the revolver
    private int[] chambers;  // Store the bullet info for each chamber
    public int currentChamber = 0;   // The currently active chamber
    public Color[] chamberColor; // Stored colors for bullet chamber
    public Transform bulletSpawnPoint;   // Where the bullet is fired from
    public AmmoManager ammoManager;    // Reference to the player's ammo manager
    public HUDController hudController;  // Reference to the HUD Controller for UI updates
    public Animator gunAnim;  // To trigger shooting animation
    public float bulletSpeed = 20f;  // Speed of the fired bullet
    public float bulletLifetime = 1f; // Lifetime of the fired bullet

    private void Start()
    {
        chambers = new int[totalChambers];   // Initialize all chambers as empty (0 means empty, 1 means filled)
        hudController.UpdateChamberHUD(chambers, chamberColor[0]);
    }

    // Load a bullet into the active chamber
    public void LoadBullet()
    {
        if (chambers[currentChamber] == 0)
        {
            AmmoBox selectedAmmo = ammoManager.GetCurrentAmmoBox();  // Get selected ammo box
            
            if (selectedAmmo != null)
            {
                chambers[currentChamber] = 1;  // Mark the chamber as filled

                Color chamberBulletColor = chamberColor[0];  // Default color
                switch (selectedAmmo.ammoColor) // Change color of chamber depending on the ammo box's color
                {
                    case "Red":
                        chamberBulletColor = chamberColor[1];
                        break;
                    case "Yellow":
                        chamberBulletColor = chamberColor[2];
                        break;
                    case "Green":
                        chamberBulletColor = chamberColor[3];
                        break;
                    case "Blue":
                        chamberBulletColor = chamberColor[4];
                        break;
                }

                hudController.UpdateSpecificChamberHUD(currentChamber, true, chamberBulletColor);  // Only update the current chamber
                Debug.Log($"Loaded {selectedAmmo.ammoColor} bullet into chamber {currentChamber}.");
            }
        }
        else
        {
            Debug.Log($"Chamber {currentChamber} is already filled.");
        }
    }

    // Fire the bullet from the active chamber
    public void FireBullet()
    {
        if (chambers[currentChamber] == 1)
        {
            // Play the shooting animation
            gunAnim.SetTrigger("Shoot");

            // Get the selected ammo box and its bullet prefab
            AmmoBox selectedAmmo = ammoManager.GetCurrentAmmoBox();
            if (selectedAmmo != null)
            {
                // Instantiate the bullet at the bullet spawn point
                GameObject bullet = Instantiate(selectedAmmo.bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

                // Get the Rigidbody component from the bullet and add velocity to it
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.velocity = bulletSpawnPoint.forward * bulletSpeed;

                // Destroy the bullet after some time to prevent it from persisting forever
                Destroy(bullet, bulletLifetime);

                chambers[currentChamber] = 0;  // Mark the chamber as empty after firing
                Debug.Log($"Fired bullet from chamber {currentChamber}.");

                hudController.UpdateSpecificChamberHUD(currentChamber, false, chamberColor[0]);  // Update only the fired chamber to empty

                // Rotate to the next chamber after firing
                RotateChamberRight();
            }
        }
        else
        {
            Debug.Log($"Chamber {currentChamber} is empty.");
        }
    }

    public void RotateChamberLeft()
    {
        currentChamber = (currentChamber - 1 + totalChambers) % totalChambers;
        chamberIcon.transform.Rotate(0, 0, 60);
        Debug.Log($"Revolver rotated to chamber {currentChamber}.");
    }

    // Rotate to the next chamber (anticlockwise)
    public void RotateChamberRight()
    {
        currentChamber = (currentChamber + 1) % totalChambers;
        chamberIcon.transform.Rotate(0, 0, -60);
        Debug.Log($"Revolver rotated to chamber {currentChamber}.");
    }

    void Update()
    {
        // Fire the bullet when the player presses the left mouse button
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireBullet();
        }

        // Load a bullet when the player presses 'R' (if the chamber is empty)
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadBullet();
        }

        // Optional chamber rotation for testing
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RotateChamberLeft();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RotateChamberRight();
        }
    }
}
