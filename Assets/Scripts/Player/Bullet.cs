using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;       // The speed of the bullet
    public float bulletLifetime = 1f;     // Time before the bullet is destroyed
    public Material bulletMaterial;       // The material of the bullet for color indication

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed; // Set the velocity
        Destroy(gameObject, bulletLifetime);           // Destroy bullet after lifetime expires
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Logic for bullet collision goes here (e.g., damage, impact effects, etc.)
        Destroy(gameObject);  // Destroy the bullet on collision
    }
}