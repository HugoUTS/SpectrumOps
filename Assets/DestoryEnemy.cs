using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public string tagName = "Projectile";      // Tag of the bullet
    public GameObject Model;                   // Shattered Model prefab
    public AudioClip destructionClip;          
    public float soundVolume = 1.0f;           
    public float spawnHeightOffset = 0.5f;     

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            // Play the destruction sound at the wall's position
            AudioSource.PlayClipAtPoint(destructionClip, transform.position, soundVolume);

            // Calculate the spawn position with an upward offset
            Vector3 spawnPosition = transform.position + Vector3.up * spawnHeightOffset;

            // Spawn the broken/shattered model at the new position
            GameObject brokenModel = Instantiate(Model, spawnPosition, transform.rotation);

            // Call ShatterModel to disable the original enemy and its components
            ShatterModel();
        }
    }

    void ShatterModel()
    {
        // Disable NavMeshAgent
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent != null)
        {
            agent.enabled = false;
        }

        // Disable the renderer to hide the original object
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
        
        // Optionally disable the collider so the object can't interact with other physics objects
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        Destroy(gameObject);
    }
}
