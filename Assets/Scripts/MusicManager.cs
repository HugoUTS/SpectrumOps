using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private List<AudioSource> musicSources = new List<AudioSource>(); // List to store all music AudioSources
    private bool isPaused = false; // Flag to check if music is paused

    private void Awake()
    {
        // Find all GameObjects in the scene with the "Music" layer
        GameObject[] musicObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in musicObjects)
        {
            // Check if the object is in the "Music" layer
            if (obj.layer == LayerMask.NameToLayer("Music"))
            {
                AudioSource audioSource = obj.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    musicSources.Add(audioSource);
                }
            }
        }
    }

    // Pause all music
    public void PauseAllMusic()
    {
        if (isPaused) return; // Prevent duplicate pause actions

        foreach (AudioSource source in musicSources)
        {
            if (source.isPlaying)
            {
                source.Pause();
            }
        }

        isPaused = true;
    }

    // Resume all music
    public void ResumeAllMusic()
    {
        if (!isPaused) return; // Prevent duplicate resume actions

        foreach (AudioSource source in musicSources)
        {
            source.UnPause();
        }

        isPaused = false;
    }
}