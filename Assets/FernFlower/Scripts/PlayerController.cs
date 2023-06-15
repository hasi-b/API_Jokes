namespace FernFlower
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using static UnityEngine.LightAnchor;

    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        float jumpForceUp;
        [SerializeField]
        float jumpForceSideways;
        float screenMiddlepoint;
        Rigidbody2D playerRigidbody;
        // Start is called before the first frame update
        void Start()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            screenMiddlepoint = Screen.width / 2;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 tapPosition = Input.mousePosition;
                if (tapPosition.x < screenMiddlepoint)
                {
                    Jump(Vector2.left,playerRigidbody);
                }
                else
                {
                    Jump(Vector2.right, playerRigidbody);
                }
            }
           
        }

        private void Jump(Vector2 jumpDirection,Rigidbody2D rigidBody)
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(jumpDirection * jumpForceSideways, ForceMode2D.Impulse);
            rigidBody.AddForce(Vector2.up * jumpForceUp, ForceMode2D.Impulse);
        }
    }
}