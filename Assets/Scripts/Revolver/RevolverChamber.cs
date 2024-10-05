using UnityEngine;
using UnityEngine.UI;

public class RevolverChamber : MonoBehaviour
{
    public RectTransform chamberIcon; // Reference to gun chamber
    public int totalChambers = 6;    // Number of chambers in the revolver
    [SerializeField] private int[] chambers;  // Store the bullet info for each chamber
    public int currentChamber = 0;   // The currently active chamber
    public Color[] chamberColor; // Stored colors for bullet chamber
    public string[] chamberTag;
    public GameObject[] bulletprefabs;

    public Transform bulletSpawnPoint;   // Where the bullet is fired from
    public AmmoManager ammoManager;    // Reference to the player's ammo manager
    public HUDController hudController;  // Reference to the HUD Controller for UI updates
    public Animator gunAnim;  // To trigger shooting animation
    public float bulletSpeed = 20f;  // Speed of the fired bullet
    public float bulletLifetime = 3f; // Lifetime of the fired bullet

    public GameObject[] gunMeshes;
    public Material[] gunMaterials;

    private void Start()
    {
        chambers = new int[totalChambers];   // Initialize all chambers as empty (0 means empty, 1 means filled)
        hudController.UpdateChamberHUD(chambers, chamberColor[0]);
    }

    // Load a bullet into the active chamber
    public void LoadBullet()
    {
        if (chambers[currentChamber] == 0)
        {
            string selectedAmmoColor = ammoManager.GetCurrentAmmoBox();
            
            if (selectedAmmoColor != "")
            {
                chambers[currentChamber] = 1;  // Mark the chamber as filled

                Color chamberBulletColor = chamberColor[0];  // Default color
                Color chamberIconColor = chamberColor[0];

                switch (selectedAmmoColor) // Change color of chamber depending on the ammo box's color
                {
                    case "Red":
                        chamberBulletColor = chamberColor[1];
                        chamberTag[currentChamber] = "Red";
                        chamberIcon.gameObject.GetComponent<Image>().color = chamberColor[1];
                        break;
                    case "Yellow":
                        chamberBulletColor = chamberColor[2];
                        chamberTag[currentChamber] = "Yellow";
                        chamberIcon.gameObject.GetComponent<Image>().color = chamberColor[2];
                        break;
                    case "Green":
                        chamberBulletColor = chamberColor[3];
                        chamberTag[currentChamber] = "Green";
                        chamberIcon.gameObject.GetComponent<Image>().color = chamberColor[3];
                        break;
                    case "Blue":
                        chamberBulletColor = chamberColor[4];
                        chamberTag[currentChamber] = "Blue";
                        chamberIcon.gameObject.GetComponent<Image>().color = chamberColor[4];
                        break;
                }

                hudController.UpdateSpecificChamberHUD(currentChamber, true, chamberBulletColor);  // Only update the current chamber

                Debug.Log($"Loaded {selectedAmmoColor} bullet into chamber {currentChamber}.");
            }
        }
        else
        {
            Debug.Log($"Chamber {currentChamber} is already filled.");
        }
    }

    // Fire the bullet from the active chamber
    public void FireBullet()
    {
        if (chambers[currentChamber] == 1)
        {
            // Instantiate the bullet at the bullet spawn point
            switch (chamberTag[currentChamber])
            {
                case "Red":
                    Instantiate(bulletprefabs[0], bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    break;

                case "Yellow":
                    Instantiate(bulletprefabs[1], bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    break;

                case "Green":
                    Instantiate(bulletprefabs[2], bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    break;

                case "Blue":
                    Instantiate(bulletprefabs[3], bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    break;           
            }

            chambers[currentChamber] = 0;  // Mark the chamber as empty after firing
            chamberTag[currentChamber] = "";
            Debug.Log($"Fired bullet from chamber {currentChamber}.");

            hudController.UpdateSpecificChamberHUD(currentChamber, false, chamberColor[0]);  // Update only the fired chamber to empty
        }
        else
        {
            Debug.Log($"Chamber {currentChamber} is empty.");
        }
        // Rotate to the next chamber after firing
        RotateChamberRight();
    }

    public void RotateChamberLeft()
    {
        currentChamber = (currentChamber - 1 + totalChambers) % totalChambers;
        chamberIcon.transform.Rotate(0, 0, 60);
        Debug.Log($"Revolver rotated to chamber {currentChamber}.");
    }

    // Rotate to the next chamber (anticlockwise)
    public void RotateChamberRight()
    {
        currentChamber = (currentChamber + 1) % totalChambers;
        chamberIcon.transform.Rotate(0, 0, -60);
        Debug.Log($"Revolver rotated to chamber {currentChamber}.");
    }

    void Update()
    {
        // Fire the bullet when the player presses the left mouse button
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (chambers[currentChamber] == 1)
            {
                // Play the shooting animation
                gunAnim.SetTrigger("Shoot");
            }
            else
            {
                RotateChamberRight();
            }
        }

        // Load a bullet when the player presses 'R' (if the chamber is empty)
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(chambers[currentChamber] == 1)
            {
                RotateChamberRight();
            }
            LoadBullet();
        }

        // Optional chamber rotation for testing
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            RotateChamberLeft();
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0f )
        {
            RotateChamberRight();
        }

        switch (chamberTag[currentChamber])
        {
            case "Red":
                chamberIcon.gameObject.GetComponent<Image>().color = chamberColor[1];

                for (int i = 0; i < gunMeshes.Length; i++)
                {
                    gunMeshes[i].GetComponent<MeshRenderer>().material = gunMaterials[1];
                }
                break;
            case "Yellow":
                chamberIcon.gameObject.GetComponent<Image>().color = chamberColor[2];

                for (int i = 0; i < gunMeshes.Length; i++)
                {
                    gunMeshes[i].GetComponent<MeshRenderer>().material = gunMaterials[2];
                }
                break;
            case "Green":
                chamberIcon.gameObject.GetComponent<Image>().color = chamberColor[3];

                for (int i = 0; i < gunMeshes.Length; i++)
                {
                    gunMeshes[i].GetComponent<MeshRenderer>().material = gunMaterials[3];
                }
                break;
            case "Blue":
                chamberIcon.gameObject.GetComponent<Image>().color = chamberColor[4];

                for (int i = 0; i < gunMeshes.Length; i++)
                {
                    gunMeshes[i].GetComponent<MeshRenderer>().material = gunMaterials[4];
                }
                break;
            default:
                chamberIcon.gameObject.GetComponent<Image>().color = Color.white;

                for (int i = 0; i < gunMeshes.Length; i++)
                {
                    gunMeshes[i].GetComponent<MeshRenderer>().material = gunMaterials[0];
                }
                break;
        }
    }
}
