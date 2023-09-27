using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    public float kickForce = 10f;          // The force of the kick.
    public float kickRange = 2f;           // The range of the kick.
    public KeyCode kickKey = KeyCode.F;    // The key to trigger the kick.

    void Update()
    {
        // Check if the kick key is pressed.
       
            // Perform the kick action.
            PerformKick();
        
    }

    void PerformKick()
    {
        // Create a ray from the player's position in the forward direction.
        Ray ray = new Ray(transform.position + new Vector3(0f,0.5f,0f), transform.forward);
        RaycastHit hit;

        // Set the default color to red.
        Color rayColor = Color.red;

        // Cast the ray and check if it hits an object within the kick range.
        if (Physics.Raycast(ray, out hit, kickRange))
        {
            // Change the ray color to green if the object is within kick range.
            rayColor = Color.green;

            // Check if the hit object has a Rigidbody component.
            Rigidbody hitRigidbody = hit.collider.GetComponent<Rigidbody>();
            if (hitRigidbody != null && (Input.GetKeyDown(kickKey)))
            {
                // Apply a force to the hit object in the direction of the ray.
                hitRigidbody.AddForce(ray.direction * kickForce, ForceMode.Impulse);
            }
        }

        // Draw the ray with the determined color to make it visible in the scene view.
        Debug.DrawRay(ray.origin, ray.direction * kickRange, rayColor, 0.5f);
    }
}
