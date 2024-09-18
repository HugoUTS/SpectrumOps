using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public variables for adjusting speed
    public float moveSpeed = 6f;
    public float jumpForce = 5f;
    public float mouseSensitivity = 100f;
    public Transform cameraTransform;

    // Private variables for movement and jumping
    private Rigidbody rb;
    private float xRotation = 0f;
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Handle mouse look
        HandleMouseLook();

        // Handle player movement
        HandleMovement();

        // Handle jumping
        HandleJumping();
    }

    void HandleMouseLook()
    {
        // Get mouse input for horizontal (X) and vertical (Y) rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player object horizontally (along the Y-axis) based on mouse X input
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically (along the X-axis) based on mouse Y input
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Prevent the camera from flipping
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleMovement()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");  // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");    // W/S or Forward/Back

        // Calculate movement direction relative to where the player is facing
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;

        // Move the player using Rigidbody
        rb.MovePosition(rb.position + movement);
    }

    void HandleJumping()
    {
        // Check if the player is grounded and presses the jump key
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // If player is touching the ground, set isGrounded to true
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // When player is not touching the ground, set isGrounded to false
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
