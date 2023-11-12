using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [Header("HoleMesh")]
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshCollider meshCollider;
    [Header("Hole Vertices Radius")]
    [SerializeField] float radius;
    [SerializeField] Transform holeCenter;
    [SerializeField] Vector2 moveLimits;

    Mesh mesh;
    List<int> holeVertices = new List<int>();
    List<Vector3>offsets = new List<Vector3>();
    int holeVerticesCount;
    float x, y;
    Vector3 touch, targetPosition;
    [Space]
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mesh = meshFilter.mesh;
        FindHoleVertices();
        
    }

    private void FindHoleVertices()
    {
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            float Distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);
            Debug.Log("Distance"+Distance);
            if (Distance*100 < radius)
            {
                holeVertices.Add(i);
                offsets.Add(mesh.vertices[i]-holeCenter.position);
            }
        }
        Debug.Log(holeVertices.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveHole();
            UpdateHoleVerticesPosition();
        }
    }

    private void UpdateHoleVerticesPosition()
    {
        
        Vector3[] vertices = mesh.vertices;
        for(int i = 0; i < holeVertices.Count; i++)
        {
            vertices[holeVertices[i]] = holeCenter.position + offsets[i];
        }
        mesh.vertices = vertices;
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }

    private void MoveHole()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");
        touch = Vector3.Lerp(holeCenter.position, holeCenter.position + new Vector3(x, 0, y), moveSpeed * Time.deltaTime);
        targetPosition = new Vector3(Mathf.Clamp(touch.x,-moveLimits.x/100f,moveLimits.x/100f),touch.y, (Mathf.Clamp(touch.z, -moveLimits.y / 100f, moveLimits.y/100f)));
        holeCenter.position = targetPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(holeCenter.position, radius);
    }
}
