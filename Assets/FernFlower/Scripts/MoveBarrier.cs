using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBarrier : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(gameObject.transform.position.x,player.transform.position.y,gameObject.transform.position.z);
    }
}
