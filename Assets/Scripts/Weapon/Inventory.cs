using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public Weapon[] weapons;      // The array of weapons
    public GameObject player;                      // The player game object
    public Transform weaponHolder;                 // The transform where the weapon will be held

    private int equippedWeaponIndex = 0;           // Track the currently equipped weapon
    private GameObject currentWeaponObject;        // The currently instantiated weapon object in hand

    private void Start()
    {
        InitVariables();
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.weaponStyle;

        // If there is a weapon in index 0, move it to index 1
        if (weapons[0] != null)
        {
            if (weapons[1] != null)
            {
                Debug.LogWarning("Replacing weapon in index 1: " + weapons[1].name);
            }
            weapons[1] = weapons[0]; // Move current weapon in index 0 to index 1
            Debug.Log("Moved weapon from index 0 to index 1: " + weapons[1].name);
        }

        // Add the new weapon to index 0 and equip it
        weapons[0] = newItem;
        Debug.Log("New weapon added to index 0: " + newItem.name);

        // Equip the newly added weapon in index 0
        EquipWeapon(0);
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