using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    [SerializeField] 
    float kickForce = 10f;          // The force of the kick.
    [SerializeField]  
    float kickRange = 2f;           // The range of the kick.
    [SerializeField]
    KeyCode kickKey = KeyCode.F;

    #region
    Ray ray;
    RaycastHit hit;
    Color rayColor = Color.red;
    Rigidbody hitRigidbody;
    #endregion
    // The key to trigger the kick.

    void Update()
    {
        // Check if the kick key is pressed.
        if (Input.GetKeyDown(kickKey))
        {
            // Perform the kick action.
            PerformKick();
        }
    }

    void PerformKick()
    {
        // Create a ray from the player's position in the forward direction.
        ray = new Ray(transform.position + new Vector3(0f,1f,0f), transform.forward);
        

        // Set the default color to red.
        

        // Cast the ray and check if it hits an object within the kick range.
        if (Physics.Raycast(ray, out hit, kickRange))
        {
            // Change the ray color to green if the object is within kick range.
            rayColor = Color.green;

            // Check if the hit object has a Rigidbody component.
            hitRigidbody = hit.collider.GetComponent<Rigidbody>();
            if (hitRigidbody != null)
            {
                // Apply a force to the hit object in the direction of the ray.
                hitRigidbody.AddForce(ray.direction * kickForce, ForceMode.Impulse);
            }
        }

        // Draw the ray with the determined color and thickness.
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * kickRange, rayColor, 0.5f);
    }
}
