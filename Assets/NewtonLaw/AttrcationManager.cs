using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrcationManager : MonoBehaviour
{
    public float G = 6.674f * Mathf.Pow(10f, -11f);
    Rigidbody ballRigidBody;
    [SerializeField] Rigidbody attractable;
   

    private void Awake()
    {
        ballRigidBody = GetComponent<Rigidbody>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - attractable.position;
       
        float distanceSquared = direction.sqrMagnitude;
        if (distanceSquared < 0.0001f || direction.magnitude>5)
        {
            return;
        }
        
        float forceMagnitude = G * (attractable.mass * ballRigidBody.mass) / distanceSquared;
        Vector3 force = direction.normalized * forceMagnitude;
        Debug.Log(forceMagnitude);
        Debug.Log(force);
        attractable.AddForce(force*20, ForceMode.Force);

    }
}
