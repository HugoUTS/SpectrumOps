using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public GameObject[] ammoHUDSlots;  // Array of HUD slots for ammo
    public GameObject[] chamberHUDSlots;  // Array of HUD slots for chambers
    public Color[] HUDColor; // For storing a list of colors for the revolver chamber and ammo box

    // Update the HUD for ammo boxes
    public void UpdateAmmoHUD(string[] ammoTag, int selectedAmmoIndex)
    {
        for (int i = 0; i < ammoTag.Length; i++)
        {
            if (ammoTag[i] != null)
            {
                ammoHUDSlots[i].SetActive(true); // Display this slot

                switch (ammoTag[i])
                {
                    case "Red":
                        {
                            ammoHUDSlots[i].GetComponent<Image>().color = HUDColor[1];
                        }
                        break;

                    case "Yellow":
                        {
                            ammoHUDSlots[i].GetComponent<Image>().color = HUDColor[2];
                        }
                        break;

                    case "Green":
                        {
                            ammoHUDSlots[i].GetComponent<Image>().color = HUDColor[3];
                        }
                        break;

                    case "Blue":
                        {
                            ammoHUDSlots[i].GetComponent<Image>().color = HUDColor[4];
                        }
                        break;

                    default:
                        {
                            ammoHUDSlots[i].GetComponent<Image>().color = HUDColor[0];
                        }
                        break;
                }
            }
        }
    }

    // Update the HUD for the chambers (show which are loaded or empty)
    public void UpdateChamberHUD(int[] chambers, Color defaultColor)
    {
        for (int i = 0; i < chambers.Length; i++)
        {
            chamberHUDSlots[i].SetActive(chambers[i] == 1); // Show if loaded, hide if empty
            if (chamberHUDSlots[i].activeSelf == true)
            {
                chamberHUDSlots[i].GetComponent<Image>().color = defaultColor; // Set default color for loaded chamber
            }
        }
    }

    // NEW: Update a specific chamber (for firing or reloading)
    public void UpdateSpecificChamberHUD(int chamberIndex, bool isLoaded, Color chamberBulletColor)
    {
        chamberHUDSlots[chamberIndex].SetActive(isLoaded); // Set active if loaded, inactive if empty
        if (isLoaded)
        {
            chamberHUDSlots[chamberIndex].GetComponent<Image>().color = chamberBulletColor; // Set color based on ammo
        }
    }
}