using UnityEngine;

public class PlayerFootstepSound : MonoBehaviour
{
    public AudioSource footstepSource;    // The AudioSource component to play footstep sounds
    public AudioClip footstepClip;        // The footstep sound clip
    public float footstepInterval = 0.5f; // Time interval between footsteps
    private FirstPersonController playerController; // Reference to the player movement script
    private float footstepTimer = 0f;     // Timer to track time between footsteps

    private bool isMoving = false;

    void Start()
    {
        // Get the FirstPersonController component to track player movement
        playerController = GetComponent<FirstPersonController>();
        
        if (footstepSource == null)
        {
            footstepSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check if the player is moving and grounded
        if (playerController.isGrounded && (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))
        {
            isMoving = true;
            footstepTimer += Time.deltaTime;

            // Play the footstep sound at intervals
            if (footstepTimer >= footstepInterval)
            {
                footstepSource.clip = footstepClip;
                footstepSource.Play();
                footstepTimer = 0f;  // Reset the timer after playing the sound
            }
        }
        else
        {
            isMoving = false;
            footstepSource.Stop(); // Stop the footstep sound when the player stops moving
        }
    }
}