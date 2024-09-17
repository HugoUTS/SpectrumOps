using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Transform weaponHolder;          // Player's weapon holder (in front of the camera)
    public KeyCode pickupKey = KeyCode.E;   // Key to press for picking up a weapon
    public float pickupRange = 2f;          // Range within which the player can pick up the weapon
    public KeyCode switchWeapon1Key = KeyCode.Alpha1;  // Key to switch to weapon slot 1
    public KeyCode switchWeapon2Key = KeyCode.Alpha2;  // Key to switch to weapon slot 2

    private GameObject[] weapons = new GameObject[2];  // Store up to 2 weapons
    private int currentWeaponIndex = 0;    // Currently equipped weapon (0 or 1)
    private bool isNearWeapon = false;     // Detect if the player is near a weapon
    private GameObject currentWeapon;      // The weapon currently in hand

    private void Update()
    {
        // Handle weapon pickup
        if (isNearWeapon && Input.GetKeyDown(pickupKey))
        {
            PickUpWeapon();
        }

        // Switch weapons using number keys
        if (Input.GetKeyDown(switchWeapon1Key))
        {
            SwitchWeapon(0);  // Switch to weapon in slot 1
        }
        if (Input.GetKeyDown(switchWeapon2Key))
        {
            SwitchWeapon(1);  // Switch to weapon in slot 2
        }

        // Switch weapons using mouse scroll wheel
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f)
        {
            if (scrollInput > 0f)
            {
                // Scroll up
                SwitchToNextWeapon();
            }
            else if (scrollInput < 0f)
            {
                // Scroll down
                SwitchToPreviousWeapon();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect if the player is near a weapon
        if (other.CompareTag("Weapon"))
        {
            isNearWeapon = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // When the player moves away from the weapon
        if (other.CompareTag("Weapon"))
        {
            isNearWeapon = false;
        }
    }

    void PickUpWeapon()
    {
        GameObject newWeapon = Instantiate(gameObject, weaponHolder.position, weaponHolder.rotation, weaponHolder);
        newWeapon.tag = "Untagged";  // Untag the weapon to avoid picking it up again

        // Store the weapon in the first available slot (up to 2 weapons)
        if (weapons[0] == null)
        {
            weapons[0] = newWeapon;
            SwitchWeapon(0);  // Automatically switch to the first picked weapon
        }
        else if (weapons[1] == null)
        {
            weapons[1] = newWeapon;
            SwitchWeapon(1);  // Automatically switch to the second weapon if it's the only available slot
        }
        else
        {
            // If both weapon slots are full, replace the currently equipped weapon
            Destroy(weapons[currentWeaponIndex]);
            weapons[currentWeaponIndex] = newWeapon;
            SwitchWeapon(currentWeaponIndex);  // Keep the new weapon equipped
        }

        // Destroy the weapon on the ground after picking it up
        Destroy(gameObject);
    }

    void SwitchWeapon(int weaponIndex)
    {
        if (weapons[weaponIndex] == null)
        {
            return;  // No weapon in the selected slot
        }

        // Deactivate the currently equipped weapon
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false);
        }

        // Switch to the new weapon
        currentWeaponIndex = weaponIndex;
        currentWeapon = weapons[weaponIndex];
        currentWeapon.SetActive(true);  // Activate the new weapon
    }

    void SwitchToNextWeapon()
    {
        // Cycle forward through weapons
        int nextWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        if (weapons[nextWeaponIndex] != null)
        {
            SwitchWeapon(nextWeaponIndex);
        }
    }

    void SwitchToPreviousWeapon()
    {
        // Cycle backward through weapons
        int previousWeaponIndex = (currentWeaponIndex - 1 + weapons.Length) % weapons.Length;
        if (weapons[previousWeaponIndex] != null)
        {
            SwitchWeapon(previousWeaponIndex);
        }
    }
}
