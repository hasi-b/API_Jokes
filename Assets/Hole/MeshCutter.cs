using UnityEngine;

public class MeshCutter : MonoBehaviour
{
    public GameObject cube; // Assign the cube GameObject in the Inspector

    void Start()
    {
        // Get the mesh of the plane
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null)
        {
            Debug.LogError("MeshFilter component not found!");
            return;
        }
        Mesh planeMesh = mf.mesh;

        // Get the bounds of the cube
        Bounds bounds = cube.GetComponent<Renderer>().bounds;

        // Calculate the plane's local position
        Vector3 localPos = transform.InverseTransformPoint(bounds.center);

        // Calculate the size of the hole
        Vector3 holeSize = new Vector3(bounds.size.x / 2, bounds.size.y / 2, bounds.size.z / 2);

        // Define the vertices for the hole
        Vector3[] vertices = planeMesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldPos = transform.TransformPoint(vertices[i]);
            Vector3 localVertPos = transform.InverseTransformPoint(worldPos);

            // Check if the vertex is inside the cube's bounds
            if (Mathf.Abs(localVertPos.x - localPos.x) < holeSize.x &&
                Mathf.Abs(localVertPos.y - localPos.y) < holeSize.y &&
                Mathf.Abs(localVertPos.z - localPos.z) < holeSize.z)
            {
                vertices[i].y = localPos.y; // Cut the plane at the intersection point
            }
        }

        // Assign the modified vertices back to the mesh
        planeMesh.vertices = vertices;

        // Recalculate the normals and bounds to ensure proper rendering
        planeMesh.RecalculateNormals();
        planeMesh.RecalculateBounds();
    }
}
