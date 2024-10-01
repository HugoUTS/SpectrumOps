using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public float pickupRange = 2f; // How close the player must be to pick up the item
    public LayerMask pickupLayer; // The layer of objects that can be picked up (e.g., ammo boxes)
    public Transform playerCamera; // The player's camera for raycasting
    public AmmoManager ammoManager; // Reference to the AmmoManager for adding ammo boxes

    void Update()
    {
        // Use raycasting to detect items the player is aiming at within pickup range
        if (Input.GetKeyDown(KeyCode.E)) // Press 'E' to interact
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, pickupRange, pickupLayer))
            {
                AmmoBox ammoBox = hit.collider.GetComponent<AmmoBox>();
                if (ammoBox != null)
                {
                    // Add the picked-up ammo box to the player's inventory
                    ammoManager.AddAmmoBox(ammoBox);
                    Debug.Log($"Picked up {ammoBox.ammoColor} ammo box.");
                    Destroy(hit.collider.gameObject); // Remove the ammo box from the world after picking up
                }
            }
        }
    }
}