using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCameraController : MonoBehaviour
{
    [SerializeField]
    Transform plane;

    Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position-plane.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y, plane.transform.position.z + cameraOffset.z) ;
    }
}
