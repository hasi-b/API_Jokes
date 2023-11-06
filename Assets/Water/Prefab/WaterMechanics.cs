using UnityEngine;

public class WaterMechanics : MonoBehaviour
{
    public float waterLevel = 0f; // Set the water level
    public float waterDensity = 0.75f; // Adjust density as needed
    public float waterDrag = 1f; // Adjust drag as needed

    void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            if (other.transform.position.y < waterLevel)
            {
                // Object is submerged in water
                float depth = waterLevel - other.transform.position.y;
                float buoyantForce = waterDensity * Mathf.Abs(Physics.gravity.y) * depth;
                Vector3 buoyancy = new Vector3(0, buoyantForce, 0);
                rb.AddForce(buoyancy);

                // Apply water drag
                rb.drag = waterDrag;
            }
            else
            {
                // Object is above water
                rb.drag = 0.05f; // Adjust drag for above-water behavior
            }
        }
    }
}
