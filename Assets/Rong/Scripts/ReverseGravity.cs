using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
    Rigidbody2D rigidbodyGravityReverse;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyGravityReverse = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            rigidbodyGravityReverse.gravityScale *= -1;
        }
    }
}
