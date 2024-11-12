using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public string tagName = "Projectile";     // Tag to identify the bullet
    public UnlockTally unlockTarget;          // Reference to the UnlockTally object
    public bool activated = false;            // Track if the button is activated
    public Material onColor;                  // Material to change to when the button is activated
    public Material buttonMaterial;           // Material assigned to the button (set this in the Inspector)
    public AudioSource buttonAudioSource;     // AudioSource to play the activation sound

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            // Get the Renderer component of the projectile (bullet)
            Renderer bulletRenderer = collision.gameObject.GetComponent<Renderer>();

            if (bulletRenderer != null)
            {
                Material bulletMaterial = bulletRenderer.material;

                // Compare material names to match button and bullet colors
                if (bulletMaterial.name == buttonMaterial.name + " (Instance)" || bulletMaterial.name == buttonMaterial.name)
                {
                    if (!activated)
                    {
                        // Reduce the number of buttons left and mark this button as activated
                        unlockTarget.buttonsLeft -= 1;
                        activated = true;

                        // Change the button color to the "on" color
                        gameObject.GetComponent<MeshRenderer>().material = onColor;

                        // Play the activation sound
                        if (buttonAudioSource != null)
                        {
                            buttonAudioSource.Play();
                        }

                        Debug.Log("Button activated by matching bullet color!");
                    }
                }
                else
                {
                    Debug.Log("Button not activated. Bullet color does not match.");
                }
            }
        }
    }
}
