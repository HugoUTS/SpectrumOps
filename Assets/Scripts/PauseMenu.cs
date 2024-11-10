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

    private MusicManager musicManager; // Reference to MusicManager

    // Start is called before the first frame update
    void Start()
    {
        // Find the MusicManager in the scene
        musicManager = FindObjectOfType<MusicManager>();
        if (musicManager == null)
        {
            Debug.LogWarning("MusicManager not found in the scene. Music will not be controlled.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isPaused == true)
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

    private void PauseGame()
    {
        Time.timeScale = 0;
        FPSController.enabled = false;
        playerPickup.enabled = false;
        ammoManager.enabled = false;
        revolverChamber.enabled = false;

        // Disable all HUD elements
        for (int i = 0; i < HUDControllers.Length; i++)
        {
            if (HUDControllers[i] != null)
            {
                HUDControllers[i].SetActive(false);
            }
        }

        pauseUI.SetActive(true);
        isPaused = true;

        // Pause all music
        if (musicManager != null)
        {
            musicManager.PauseAllMusic();
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        FPSController.enabled = true;
        playerPickup.enabled = true;
        ammoManager.enabled = true;
        revolverChamber.enabled = true;

        // Enable all HUD elements
        for (int i = 0; i < HUDControllers.Length; i++)
        {
            if (HUDControllers[i] != null)
            {
                HUDControllers[i].SetActive(true);
            }
        }

        pauseUI.SetActive(false);
        isPaused = false;

        // Resume all music
        if (musicManager != null)
        {
            musicManager.ResumeAllMusic();
        }
    }
}
