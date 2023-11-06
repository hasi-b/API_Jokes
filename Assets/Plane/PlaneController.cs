using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the movement speed as needed
    public float horizontalSpeed = 2f; // Adjust the horizontal movement speed as needed
    public float tiltStrength = 10f; // Adjust the tilt strength as needed
    public float floatSpeed = 5f;
    public float returnSpeed = 5f; // Adjust the return speed as needed

    private float originalY;
    private Quaternion initialRotation;
    private Rigidbody rb;
    [SerializeField]
    ParticleSystem destroyParticle;

    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y;
        initialRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // Update is called once per frame
    void FixedUpdate()
    {
        // Automatically move forward
        rb.velocity = transform.forward * moveSpeed;
       

        // Get input for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate horizontal movement
        float horizontalMovement = horizontalInput * horizontalSpeed * Time.deltaTime;

        // Apply horizontal movement
        Vector3 horizontalVelocity = transform.right * horizontalMovement;
        rb.velocity = new Vector3(horizontalVelocity.x * moveSpeed, rb.velocity.y, transform.forward.z * moveSpeed);

        // Apply floating effect
        float newY = originalY + Mathf.Sin(Time.time * floatSpeed) * 0.5f; // Adjust the multiplier for more or less float
        rb.velocity = new Vector3(rb.velocity.x, (newY - transform.position.y) * floatSpeed, rb.velocity.z);

        // Apply tilting effect
        if (horizontalInput != 0)
        {
            float tiltAngle = -horizontalInput * tiltStrength;
            Quaternion targetRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y, tiltAngle);
            rb.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * returnSpeed);
        }
        else
        {
            rb.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * returnSpeed);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);
        if (collision.gameObject.tag == "wall")
        {
            this.gameObject.SetActive(false);
            destroyParticle.gameObject.transform.position = transform.position + new Vector3(0f, 0f, 4f);
            destroyParticle.Play();
            Destroy(this);
            // Add collision handling logic here
            // Example: You can stop the movement or apply a force to the object on collision
        }
    }

}
