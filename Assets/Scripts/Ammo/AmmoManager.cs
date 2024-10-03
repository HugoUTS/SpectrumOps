using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public AmmoBox[] ammoBoxes = new AmmoBox[2];  // Array to store two ammo boxes
    private int currentAmmoIndex = 0;             // Index of the currently selected ammo box
    public HUDController hudController;

    void Start()
    {
        hudController.UpdateAmmoHUD(ammoBoxes, currentAmmoIndex);
    }

    // Get the currently selected ammo box
    public AmmoBox GetCurrentAmmoBox()
    {
        return ammoBoxes[currentAmmoIndex];
    }

    // Switch between ammo boxes
    public void SwitchAmmoBox()
    {
        currentAmmoIndex = (currentAmmoIndex + 1) % 2;
        Debug.Log($"Switched to ammo box at index {currentAmmoIndex}");
        hudController.UpdateAmmoHUD(ammoBoxes, currentAmmoIndex);
    }

    // Add a new ammo box to the player's inventory
    public void AddAmmoBox(AmmoBox newAmmoBox)
    {
        if (ammoBoxes[0] == null)
        {
            ammoBoxes[0] = newAmmoBox;
            Debug.Log("Added new ammo box to slot 0.");
        }
        else if (ammoBoxes[1] == null)
        {
            ammoBoxes[1] = newAmmoBox;
            Debug.Log("Added new ammo box to slot 1.");
        }
        else
        {
            // Replace the currently selected ammo box if both slots are full
            ammoBoxes[currentAmmoIndex] = newAmmoBox;
            Debug.Log($"Replaced ammo box in slot {currentAmmoIndex}.");
        }

        // Ensure HUD is updated after adding the ammo box
        hudController.UpdateAmmoHUD(ammoBoxes, currentAmmoIndex);

        // Now destroy the ammo box in the scene after data is handled
        Destroy(newAmmoBox.gameObject);
    }


    // Drop the currently selected ammo box
    public void DropAmmoBox()
    {
        if (ammoBoxes[currentAmmoIndex] != null)
        {
            Debug.Log($"Dropped {ammoBoxes[currentAmmoIndex].ammoColor} ammo box.");
            ammoBoxes[currentAmmoIndex] = null;
            hudController.UpdateAmmoHUD(ammoBoxes, currentAmmoIndex);
        }
    }
}