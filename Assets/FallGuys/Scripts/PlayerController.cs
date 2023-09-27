using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;      // Movement speed
    public float jumpForce = 7f;      // Jump force
    public float rotationSpeed = 2.0f; // Rotation speed using the mouse
    private bool isGrounded = true;   // Check if the player is on the ground
    private Rigidbody rb;
    [SerializeField]
    Transform playerCameraRoot;

    private float rotationY = 0.0f;   // Current rotation around the Y-axis

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Handle player input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Apply movement to the rigidbody
        rb.MovePosition(transform.position + movement);

        // Handle player input for jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X");

        // Rotate the player based on mouse input
        RotateCamera(mouseX);
    }

    // Detect if the player is on the ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void RotateCamera(float mouseX)
    {
        // Calculate the new rotation angle based on mouse input
        rotationY += mouseX * rotationSpeed;

        // Apply the new rotation to the player's camera transform
        playerCameraRoot.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
