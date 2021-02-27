using UnityEngine;

public class MeshRandomizer : MonoBehaviour
{
    Mesh mesh;
    float timer;
    int vertexId;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        RandomizeMesh();
    }

    void RandomizeMesh()
    {
        Vector3[] vertices = mesh.vertices;
        for(int i = 0; i < vertices.Length; i++)
        {
            float rand = Random.Range(-0.5f, 0.5f);
            vertices[i].y += rand;
        }
        mesh.vertices = vertices;
    }
}