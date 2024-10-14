using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public string[] ammoTag; // Array to store ammo box tags
    private int currentAmmoIndex = 0; // Index of the currently selected ammo box

    public GameObject[] ammoBoxPrefabs;
    public Transform boxSpawnPoint;
    public HUDController hudController;

    // Sound Variables
    public AudioSource audioSource;        // AudioSource for playing sound
    public AudioClip ammoSwitchClip;       // Sound to play when ammo box is switched

    void Start()
    {
        hudController.UpdateAmmoHUD(ammoTag, currentAmmoIndex);
    }

    // Get the currently selected ammo box
    public string GetCurrentAmmoBox()
    {
        return ammoTag[currentAmmoIndex];
    }

    // Check if the player has any ammo
    public bool HasAmmo()
    {
        return !string.IsNullOrEmpty(ammoTag[0]) || !string.IsNullOrEmpty(ammoTag[1]);
    }

    // Switch between ammo boxes
    public void SwitchAmmoBox()
    {
        // Check if there are any ammo boxes before switching
        if (HasAmmo())
        {
            System.Array.Reverse(ammoTag);
            Debug.Log($"Switched to ammo box at index {currentAmmoIndex}");
            hudController.UpdateAmmoHUD(ammoTag, currentAmmoIndex);

            // Play ammo switch sound only if there's ammo
            if (ammoSwitchClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(ammoSwitchClip);
            }
        }
        else
        {
            Debug.Log("No ammo boxes to switch.");
        }
    }

    // Add a new ammo box to the player's inventory
    public void AddAmmoBox(AmmoBoxPickup newAmmoBoxPickup, string newColorTag)
    {
        if (ammoTag[0] == "")
        {
            ammoTag[0] = newColorTag;
            Debug.Log("Added new ammo box to slot 0.");
        }
        else if (ammoTag[1] == "")
        {
            ammoTag[1] = newColorTag;
            Debug.Log("Added new ammo box to slot 1.");
        }
        else
        {
            switch (ammoTag[0])
            {
                case "Red":
                    {
                        Instantiate(ammoBoxPrefabs[0], boxSpawnPoint.position, boxSpawnPoint.rotation);
                    }
                    break;
                case "Yellow":
                    {
                        Instantiate(ammoBoxPrefabs[1], boxSpawnPoint.position, boxSpawnPoint.rotation);
                    }
                    break;
                case "Green":
                    {
                        Instantiate(ammoBoxPrefabs[2], boxSpawnPoint.position, boxSpawnPoint.rotation);
                    }
                    break;
                case "Blue":
                    {
                        Instantiate(ammoBoxPrefabs[3], boxSpawnPoint.position, boxSpawnPoint.rotation);
                    }
                    break;
            }

            // Replace the currently selected ammo box if both slots are full
            ammoTag[currentAmmoIndex] = newColorTag;
            Debug.Log($"Replaced ammo box in slot {currentAmmoIndex}.");
        }

        // Ensure HUD is updated after adding the ammo box
        hudController.UpdateAmmoHUD(ammoTag, currentAmmoIndex);
    }

    // Drop the currently selected ammo box
    public void DropAmmoBox()
    {
        if (!string.IsNullOrEmpty(ammoTag[currentAmmoIndex]))
        {
            Debug.Log($"Dropped {ammoTag[currentAmmoIndex]} ammo box.");
            ammoTag[currentAmmoIndex] = "";
            hudController.UpdateAmmoHUD(ammoTag, currentAmmoIndex);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchAmmoBox();
        }
    }
}
