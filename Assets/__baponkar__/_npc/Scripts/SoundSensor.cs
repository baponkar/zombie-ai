
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class SoundSensor : MonoBehaviour
{
    public int segments = 16; // Number of segments along the longitude
    public int rings = 8; // Number of rings along the latitude
    public float radius = 1.0f;
    [Range(0, 360)]
    public float startAngle = 0.0f;
    [Range(0, 360)]
    public float endAngle = 180.0f;

    private MeshFilter meshFilter;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        CreateMesh();
    }

    private void CreateMesh()
    {
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        int verticesCount = (segments + 1) * (rings + 1);
        Vector3[] vertices = new Vector3[verticesCount];
        Vector2[] uv = new Vector2[verticesCount];

        int index = 0;
        for (int ring = 0; ring <= rings; ring++)
        {
            float v = (float)ring / rings;
            float latitude = Mathf.Lerp(startAngle, endAngle, v);
            for (int segment = 0; segment <= segments; segment++)
            {
                float u = (float)segment / segments;
                float longitude = Mathf.Lerp(startAngle, endAngle, u);

                float x = Mathf.Sin(latitude * Mathf.Deg2Rad) * Mathf.Cos(longitude * Mathf.Deg2Rad);
                float y = Mathf.Cos(latitude * Mathf.Deg2Rad);
                float z = Mathf.Sin(latitude * Mathf.Deg2Rad) * Mathf.Sin(longitude * Mathf.Deg2Rad);

                vertices[index] = new Vector3(x, y, z) * radius;
                uv[index] = new Vector2(u, v);
                index++;
            }
        }

        int[] triangles = new int[segments * rings * 6];
        int t = 0;
        for (int ring = 0; ring < rings; ring++)
        {
            for (int segment = 0; segment < segments; segment++)
            {
                int currentRow = ring * (segments + 1);
                int nextRow = (ring + 1) * (segments + 1);

                triangles[t] = currentRow + segment;
                triangles[t + 1] = nextRow + segment;
                triangles[t + 2] = currentRow + segment + 1;

                triangles[t + 3] = currentRow + segment + 1;
                triangles[t + 4] = nextRow + segment;
                triangles[t + 5] = nextRow + segment + 1;

                t += 6;
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
