using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab;         // The weapon that the player will pick up
    public Transform weaponHolder;          // The player's weapon holder (a child object in front of the camera)
    public KeyCode pickupKey = KeyCode.E;   // The key to press for picking up weapons
    public float pickupRange = 2f;          // The range within which the player can pick up the weapon
    private bool isNearWeapon = false;

    private GameObject currentWeapon;       // To store the currently held weapon

    void Update()
    {
        // Detect if the player is near a weapon and presses the pickup key
        if (isNearWeapon && Input.GetKeyDown(pickupKey))
        {
            PickUpWeapon();
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
        // If the player already has a weapon, destroy the old one
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        // Instantiate the weapon at the player's weapon holder
        currentWeapon = Instantiate(weaponPrefab, weaponHolder.position, weaponHolder.rotation, weaponHolder);

        // Optionally disable the weapon on the ground (since it's now picked up)
        Destroy(gameObject);
    }
}
