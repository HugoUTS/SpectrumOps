using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public string[] ammoTag; // Array to store ammo box tags
    private int currentAmmoIndex = 0; // Index of the currently selected ammo box
    public HUDController hudController;

    void Start()
    {
        hudController.UpdateAmmoHUD(ammoTag, currentAmmoIndex);
    }

    // Get the currently selected ammo box
    public string GetCurrentAmmoBox()
    {
        return ammoTag[currentAmmoIndex];
    }

    // Switch between ammo boxes
    public void SwitchAmmoBox()
    {
        currentAmmoIndex = (currentAmmoIndex + 1) % 2;
        Debug.Log($"Switched to ammo box at index {currentAmmoIndex}");
        hudController.UpdateAmmoHUD(ammoTag, currentAmmoIndex);
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
            // Replace the currently selected ammo box if both slots are full
            ammoTag[currentAmmoIndex] = newColorTag;
            Debug.Log($"Replaced ammo box in slot {currentAmmoIndex}.");
        }

        // Ensure HUD is updated after adding the ammo box
        hudController.UpdateAmmoHUD(ammoTag, currentAmmoIndex);

        // Now destroy the ammo box in the scene after data is handled
        Destroy(newAmmoBoxPickup.gameObject);
    }


    // Drop the currently selected ammo box
    public void DropAmmoBox()
    {
        if (ammoTag[currentAmmoIndex] != null)
        {
            Debug.Log($"Dropped {ammoTag[currentAmmoIndex]} ammo box.");
            ammoTag[currentAmmoIndex] = "";
            hudController.UpdateAmmoHUD(ammoTag, currentAmmoIndex);
        }
    }
}