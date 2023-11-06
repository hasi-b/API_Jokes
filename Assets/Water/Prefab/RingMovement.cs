using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Example script for applying force to the ring
public class RingMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forceMagnitude = 20;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forceMagnitude, ForceMode.Impulse);
        }
    }
}

