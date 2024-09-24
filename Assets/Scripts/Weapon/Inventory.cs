using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public Weapon[] weapons;      // The array of weapons
    public GameObject player;                      // The player game object
    public Transform weaponHolder;                 // The transform where the weapon will be held

    public WeaponSwitcher weaponSwitcher;          // Public reference to WeaponSwitcher

    private int equippedWeaponIndex = 0;           // Track the currently equipped weapon
    private GameObject currentWeaponObject;        // The currently instantiated weapon object in hand

    private void Start()
    {
        InitVariables();
        // You can initialize WeaponSwitcher here if it's not manually assigned
        if (weaponSwitcher == null)
        {
            weaponSwitcher = player.GetComponent<WeaponSwitcher>();
        }
    }

    // Method to add a new item to the inventory
    public void AddItem(Weapon newItem)
    {
        // Ensure WeaponSwitcher is initialized properly
        if (weaponSwitcher == null)
        {
            Debug.LogError("WeaponSwitcher is not assigned!");
            return;
        }

        // Check if index 0 is empty
        if (weapons[0] == null)
        {
            weapons[0] = newItem;
            Debug.Log("Added weapon to index 0: " + newItem.name);
            EquipWeapon(0);  // Equip the weapon in index 0
            weaponSwitcher.UpdateCurrentWeaponIndex(0);  // Update the current weapon index to 0
        }
        // Check if index 0 is full but index 1 is empty
        else if (weapons[1] == null)
        {
            weapons[1] = newItem;
            Debug.Log("Added weapon to index 1: " + newItem.name);
            EquipWeapon(1);  // Equip the weapon in index 1
            weaponSwitcher.UpdateCurrentWeaponIndex(1);  // Update the current weapon index to 1
        }
        // If both index 0 and index 1 are full, replace the currently equipped weapon
        else
        {
            int currentItemIndex = equippedWeaponIndex;  // Get the index of the currently equipped weapon
            weapons[currentItemIndex] = newItem;
            Debug.Log("Replaced weapon in index " + currentItemIndex + " with: " + newItem.name);
            EquipWeapon(currentItemIndex);  // Equip the newly added weapon
            weaponSwitcher.UpdateCurrentWeaponIndex(currentItemIndex);  // Update the current weapon index
        }
    }

    // Equip the weapon in the specified index (0 or 1)
    public void EquipWeapon(int index)
    {
        if (weapons[index] != null)  // Ensure there is a weapon to equip
        {
            // Deactivate the current weapon if one is equipped
            if (currentWeaponObject != null)
            {
                Destroy(currentWeaponObject);  // Remove the currently held weapon
            }

            equippedWeaponIndex = index;  // Update equipped weapon index

            // Instantiate and attach the new weapon to the player's weapon holder
            currentWeaponObject = Instantiate(weapons[index].prefab, weaponHolder.position, weaponHolder.rotation);
            currentWeaponObject.transform.SetParent(weaponHolder); // Parent to the weapon holder
            currentWeaponObject.SetActive(true);  // Make sure it's visible and active

            Debug.Log("Equipped weapon: " + weapons[equippedWeaponIndex].name);
        }
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }

    private void InitVariables()
    {
        weapons = new Weapon[2];  // Initialize the weapon array (primary and secondary)
    }

    public int GetEquippedWeaponIndex()
    {
        return equippedWeaponIndex;
    }

    public bool CanShoot()
    {
        // Only allow shooting if there is a weapon equipped and it's set active
        return equippedWeaponIndex != -1 && weapons[equippedWeaponIndex] != null;
    }
}
