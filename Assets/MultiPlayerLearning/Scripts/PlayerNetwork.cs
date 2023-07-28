using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetwork : NetworkBehaviour
{
    float x;
    float y;
    [SerializeField]
    float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            transform.position += new Vector3(x, 0, y) * moveSpeed * Time.deltaTime;
        

    }
}
