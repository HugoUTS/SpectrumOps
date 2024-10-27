using UnityEngine;

public class PasswordSoundManager : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource to play the sounds
    public AudioClip correctPasswordSound; // Sound clip for the correct password
    public AudioClip wrongPasswordSound;   // Sound clip for the wrong password

    // Method to play the correct password sound
    public void PlayCorrectPasswordSound()
    {
        if (audioSource != null && correctPasswordSound != null)
        {
            audioSource.PlayOneShot(correctPasswordSound);
        }
    }

    // Method to play the wrong password sound
    public void PlayWrongPasswordSound()
    {
        if (audioSource != null && wrongPasswordSound != null)
        {
            audioSource.PlayOneShot(wrongPasswordSound);
        }
    }
}