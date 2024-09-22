using UnityEngine;

public class ShatterOnInteraction : MonoBehaviour
{
    // Rigidbody components of the fractured pieces
    private Rigidbody[] fracturedPieces;

    // To check if the wall has already been shattered
    private bool isShattered = false;

    void Start()
    {
        // Find all Rigidbody components in the fractured pieces
        fracturedPieces = GetComponentsInChildren<Rigidbody>();

        // Disable gravity and freeze movement for all pieces
        foreach (Rigidbody rb in fracturedPieces)
        {
            rb.isKinematic = true;  // Makes the objects not react to physics
        }
    }

    // This method will be called when another GameObject interacts with the wall (using a trigger or collider)
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding is the right one
        if (collision.gameObject.CompareTag("Player") && !isShattered)
        {
            ShatterWall();
        }
    }

    // This method is responsible for enabling the fracture
    void ShatterWall()
    {
        isShattered = true;

        // Enable physics on all fractured pieces
        foreach (Rigidbody rb in fracturedPieces)
        {
            rb.isKinematic = false; // Allows them to react to gravity and collisions
        }
    }
}
