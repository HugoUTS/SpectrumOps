using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private Inventory inventory;  // Reference to the Inventory script
    private int currentWeaponIndex = 0;            // Start with weapon at index 0
    private int maxWeapons = 2;                    // Assuming you have 2 weapon slots

    void Update()
    {
        // Listen for scroll wheel input to switch weapons
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f)  // Scroll up
        {
            // Switch to the next weapon
            SwitchWeapon((currentWeaponIndex + 1) % maxWeapons);
        }
        else if (scrollInput < 0f)  // Scroll down
        {
            // Switch to the previous weapon
            SwitchWeapon((currentWeaponIndex - 1 + maxWeapons) % maxWeapons);
        }

        // Listen for the '1' and '2' key inputs to switch weapons
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Directly switch to the weapon at index 0
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Directly switch to the weapon at index 1
            SwitchWeapon(1);
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
    
    public void UpdateCurrentWeaponIndex(int index)
    {
        currentWeaponIndex = index;
    }
}
