using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAddition : MonoBehaviour
{
    [SerializeField]
    GameObject b;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = b.transform.position - transform.position ;
        direction.Normalize();

        rb.AddForce(direction*20,ForceMode.Force);
    }
}
