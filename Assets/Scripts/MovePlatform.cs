using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;
    public float current, target;

    public AudioSource platformAudioSource; // Reference to the AudioSource component
    public AudioClip moveSound; // The sound to play when the platform moves

    private bool isPlayingSound = false; // Track if the sound is already playing

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the target starts at 0
        target = 0;

        // Assign the audio clip to the audio source if not already set
        if (platformAudioSource != null && moveSound != null)
        {
            platformAudioSource.clip = moveSound;
            platformAudioSource.loop = true; // Set to loop for continuous movement sound
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Smoothly move the platform between pointA and pointB
        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(pointA.transform.position, pointB.transform.position, current);

        // Check if the platform is moving
        if (Mathf.Abs(target - current) > 0.01f)
        {
            PlayMovementSound();
        }
        else
        {
            StopMovementSound();
        }
    }

    // Method to play the movement sound
    private void PlayMovementSound()
    {
        if (platformAudioSource != null && !isPlayingSound)
        {
            platformAudioSource.Play();
            isPlayingSound = true;
        }
    }

    // Method to stop the movement sound
    private void StopMovementSound()
    {
        if (platformAudioSource != null && isPlayingSound)
        {
            platformAudioSource.Stop();
            isPlayingSound = false;
        }
    }

    // Optional: Call this function to toggle the platform's target
    public void ToggleMovement()
    {
        target = target == 0 ? 1 : 0;
    }
}
