using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;

    public FirstPersonController FPSController;
    public PlayerPickup playerPickup;
    public AmmoManager ammoManager;
    public RevolverChamber revolverChamber;
    public GameObject[] HUDControllers;

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
                for (int i = 0; i < HUDControllers.Length; i++)
                {
                    if(HUDControllers[i] != null)
                    {
                        HUDControllers[i].SetActive(false);
                    }
                }

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
                for (int i = 0; i < HUDControllers.Length; i++)
                {
                    if (HUDControllers[i] != null)
                    {
                        HUDControllers[i].SetActive(true);
                    }
                }

                pauseUI.SetActive(false);
                isPaused = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if(isPaused == true)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (isPaused == true)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(0);
            }
        }
    }
}
