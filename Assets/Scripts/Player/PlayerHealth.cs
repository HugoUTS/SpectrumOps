using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For restarting the scene or loading a death screen

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;  // Maximum health of the player
    private float currentHealth;    // Player's current health

    public GameObject deathScreen;  // Optional: A death screen UI to show on player death

    private void Start()
    {
        // Set the player's health to the maximum at the start of the game
        currentHealth = maxHealth;

        // Hide the death screen at the start if it exists
        if (deathScreen != null)
        {
            deathScreen.SetActive(false);
        }
    }

    // Call this function to make the player take damage
    public void TakeDamage(float damage)
    {
        // Reduce the player's current health
        currentHealth -= damage;

        // Check if health has dropped to zero or below
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    // Function to handle player's death
    private void Die()
    {
        Debug.Log("Player Died!");

        // Optional: Show a death screen or restart the level
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);  // Activate the death screen UI
        }
        else
        {
            // Reload the current scene (can be replaced with any other death handling)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Disable the player's movement and shooting
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerShooting>().enabled = false;

        // Optionally: Destroy the player or trigger a death animation
        // Destroy(gameObject);
    }
}

