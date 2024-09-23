using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private Inventory inventory;  // Reference to the Inventory script
    private int currentWeaponIndex = 0;            // Start with weapon at index 0

    void Update()
    {
        // Listen for the 'Q' key input to switch weapons
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Directly switch to the weapon at index 1
            if (currentWeaponIndex == 0)
            {
                SwitchWeapon(1);
            }
            // Directly switch to the weapon at index 0
            else if (currentWeaponIndex == 1)
            {
                SwitchWeapon(0);
            }       
        }
    }

    // Method to switch the active weapon
    void SwitchWeapon(int newIndex)
    {
        // If the same weapon is already selected, don't do anything
        if (newIndex == currentWeaponIndex)
        {
            return;  // Skip switching if the same weapon is selected
        }

        // Get the current and new weapons from the inventory
        Weapon currentWeapon = inventory.GetItem(currentWeaponIndex);
        Weapon newWeapon = inventory.GetItem(newIndex);

        // Check if the new weapon is valid
        if (newWeapon != null)
        {
            // Set the new weapon as equipped (before equipping)
            currentWeaponIndex = newIndex;

            // Deactivate the current weapon (set it inactive)
            if (currentWeapon != null)
            {
                currentWeapon.prefab.SetActive(false);
            }

            // Equip the new weapon (set it active)
            inventory.EquipWeapon(newIndex);

            // Debug log to verify switching
            Debug.Log($"Switched to {newWeapon.name}");
        }
    }
}