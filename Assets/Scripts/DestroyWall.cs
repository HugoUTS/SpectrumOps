using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public string tagName = "Projectile"; // The tag to identify the bullet
    public Material wallMaterial;
    

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is a bullet (Projectile)
        if (collision.gameObject.tag == tagName)
        {
            // Get the Material of the bullet that hit the wall
            Renderer bulletRenderer = collision.gameObject.GetComponent<Renderer>();

            if (bulletRenderer != null)
            {
                Material bulletMaterial = bulletRenderer.material;

                // Compare the material names instead of references to ensure they match
                if (bulletMaterial.name == wallMaterial.name + " (Instance)" ||
                    bulletMaterial.name == wallMaterial.name)
                {
                    // Instantiate the destroyed version of the wall and destroy the original wall
                    if (collision.gameObject.tag == tagName)
                    {
                        
                        Destroy(gameObject);
                        Debug.Log("Wall destroyed by matching bullet color!");
                    }
                    else
                    {
                        Debug.Log("Wall not destroyed. Bullet color does not match.");
                    }
                }
            }
        }
    }
}