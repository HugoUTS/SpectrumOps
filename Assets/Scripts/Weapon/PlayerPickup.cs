using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;

    private Camera cam;
    private Inventory inventory;

    public GameObject interact;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
        {
            interact.SetActive(true);
        }
        else
        {
            interact.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))  // Press 'E' to pick up the weapon
        {
            if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
            {
                Debug.Log("Hit: " + hit.transform.name);
                Weapon newItem = hit.transform.GetComponent<ItemObject>().item as Weapon;
                inventory.AddItem(newItem);  // Add the new weapon to the inventory
                Destroy(hit.transform.gameObject);  // Remove the weapon from the scene
            }
        }
    }

    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
    }
}