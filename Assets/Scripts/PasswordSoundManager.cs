using UnityEngine;

public class PasswordSoundManager : MonoBehaviour
{
    public AudioSource audioSource;  // Reference to an AudioSource on the persistent object
    public AudioClip correctSound;   // Sound to play when the password is correct
    public AudioClip wrongSound;     // Sound to play when the password is incorrect

    // Play the correct sound effect
    public void PlayCorrectSound()
    {
        if (audioSource != null && correctSound != null)
        {
            audioSource.PlayOneShot(correctSound);
        }
    }

    // Play the wrong sound effect
    public void PlayWrongSound()
    {
        if (audioSource != null && wrongSound != null)
        {
            audioSource.PlayOneShot(wrongSound);
        }
    }
}