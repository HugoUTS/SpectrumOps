using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public float pickupRange = 2f; // How close the player must be to pick up the item
    public GameObject interactBox;
    public LayerMask pickupLayer; // The layer of objects that can be picked up (e.g., ammo boxes)
    public Transform playerCamera; // The player's camera for raycasting
    public AmmoManager ammoManager; // Reference to the AmmoManager for adding ammo boxes

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, pickupRange, pickupLayer))
        {
            interactBox.SetActive(true);
        }
        else
        {
            interactBox.SetActive(false);
        }

        // Use raycasting to detect items the player is aiming at within pickup range
        if (Input.GetKeyDown(KeyCode.E)) // Press 'E' to interact
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, pickupRange, pickupLayer))
            {

                AmmoBoxPickup ammoBoxPickup = hit.collider.GetComponent<AmmoBoxPickup>();
                if (ammoBoxPickup != null)
                {
                    ammoManager.AddAmmoBox(ammoBoxPickup, ammoBoxPickup.boxColor);
                    Debug.Log($"Picked up {ammoBoxPickup.boxColor} ammo box.");
                    Destroy(hit.collider.gameObject); // Remove the ammo box from the world after picking up
                }
            }
        }
    }
}