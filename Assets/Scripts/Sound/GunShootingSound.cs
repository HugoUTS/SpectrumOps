using UnityEngine;

public class GunShootingSound : MonoBehaviour
{
    public AudioSource gunAudioSource;         // AudioSource for gun sounds
    public AudioClip gunShotClip;              // Sound to play when gun is fired
    public AudioClip emptyChamberClip;         // Sound to play when chamber is empty
    public RevolverChamber revolverChamber;    // Reference to the RevolverChamber script
    public KeyCode fireKey = KeyCode.Mouse0;   // Key to fire the gun

    private void Update()
    {
        // Check if the player presses the fire button
        if (Input.GetKeyDown(fireKey))
        {
            // Check if the current chamber has a bullet
            if (revolverChamber.chambers[revolverChamber.currentChamber] == 0)
            {
                // Play the empty chamber sound (click sound)
                PlayEmptyChamberSound();
            }
        }
    }

    // Function to play the gunshot sound
    public void PlayGunShotSound()
    {
        if (gunShotClip != null)
        {
            gunAudioSource.PlayOneShot(gunShotClip);
        }
    }

    // Function to play the empty chamber sound
    private void PlayEmptyChamberSound()
    {
        if (emptyChamberClip != null)
        {
            gunAudioSource.PlayOneShot(emptyChamberClip);
        }
    }
}