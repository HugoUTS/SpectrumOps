using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    // Assuming you have references to your HUD elements in the Unity Editor
    public GameObject[] ammoHUDSlots;  // Array of HUD slots for ammo
    public GameObject[] chamberHUDSlots;  // Array of HUD slots for chambers
    public Color[] HUDColor; // For storing a list of colors for the revolver chamber and ammo box

    // Update the HUD for ammo boxes
    public void UpdateAmmoHUD(AmmoBox[] ammoBoxes, int selectedAmmoIndex)
    {
        for (int i = 0; i < ammoBoxes.Length; i++)
        {
            if (ammoBoxes[i] != null)
            {
                // Set the HUD icon to display the ammo color, size, etc.
                ammoHUDSlots[i].SetActive(true); // Display this slot
            }
            else
            {
                ammoHUDSlots[i].SetActive(false); // Hide this slot if empty
            }

            // Highlight the currently selected ammo box
            ammoHUDSlots[i].transform.localScale = (i == selectedAmmoIndex) ? Vector3.one : Vector3.one;
        }
    }

    // Update the HUD for the chambers (show which are loaded or empty)
    public void UpdateChamberHUD(int[] chambers, Color chColor)
    {
        for (int i = 0; i < chambers.Length; i++)
        {
            chamberHUDSlots[i].SetActive(chambers[i] == 1); // Show if loaded, hide if empty
            if (chamberHUDSlots[i].activeSelf == true)
            {
                chamberHUDSlots[i].GetComponent<Image>().color = chColor;
            }
        }
    }
}