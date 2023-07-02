using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    Rigidbody axe;
    [SerializeField]
    int axeThrowPower;
    [SerializeField]
    GameObject player;
    [SerializeField]
    bool axeInMotion;
    [SerializeField]
    private float rotateSpeed;

    private void Awake()
    {
        axe = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
            if (axeInMotion)
            {
            transform.localEulerAngles += transform.right * rotateSpeed * Time.deltaTime;
            }
        
    }

    private void OnEnable()
    {
        ThirdPersonController.OnAxeThrow += ThrowAxe;
    }

    private void OnDisable()
    {
        ThirdPersonController.OnAxeThrow -= ThrowAxe;
    }

    private void ThrowAxe()
    {
        axeInMotion = true;
        axe.isKinematic = false;
        axe.transform.parent = null;
        axe.AddForce(player.transform.forward*axeThrowPower,ForceMode.Impulse);
        axeInMotion = true;
        Debug.Log("St");

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("wall"))
        {
            axeInMotion = false;
            axe.isKinematic = true;
        }
        
    
    }
    
}
