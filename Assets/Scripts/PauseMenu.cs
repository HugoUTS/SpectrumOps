using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;

    public FirstPersonController FPSController;
    public PlayerPickup playerPickup;
    public AmmoManager ammoManager;
    public RevolverChamber revolverChamber;
    public GameObject HUDController;

    public GameObject pauseUI;

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false)
            {
                Time.timeScale = 0;
                FPSController.enabled = false;
                playerPickup.enabled = false;
                ammoManager.enabled = false;
                revolverChamber.enabled = false;
                HUDController.SetActive(false);

                pauseUI.SetActive(true);
                isPaused = true;
            }

            else
            {
                Time.timeScale = 1;
                FPSController.enabled = true;
                playerPickup.enabled = true;
                ammoManager.enabled = true;
                revolverChamber.enabled = true;
                HUDController.SetActive(true);

                pauseUI.SetActive(false);
                isPaused = false;
            }
        }
    }
}
