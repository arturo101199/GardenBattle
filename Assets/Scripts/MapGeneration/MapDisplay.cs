using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRender;
    [SerializeField] Material material = null;
    [SerializeField] NavMeshSurface surface = null;
    GameObject plane;

    public void DrawTexture(Texture2D texture)
    {
        
        textureRender.sharedMaterial.SetTexture("_MainTex", texture);
        textureRender.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    public void DrawMesh(MeshData meshData, Texture2D texture, float scale)
    {
        if(plane == null)
        {
            initializePlane(scale);
        }

        Mesh mesh = createMesh(meshData, texture);

        bakeNavMesh(mesh);
        
    }

    void initializePlane(float scale)
    {
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.SetParent(surface.transform);
        plane.transform.localScale = Vector3.one * scale;
        plane.layer = LayerMask.NameToLayer("Ground");
    }

    void bakeNavMesh(Mesh mesh)
    {
        plane.GetComponent<MeshCollider>().sharedMesh = mesh;
        surface.BuildNavMesh();
    }

    Mesh createMesh(MeshData meshData, Texture2D texture)
    {
        MeshFilter meshFilter = plane.GetComponent<MeshFilter>();
        MeshRenderer meshRendered = plane.GetComponent<MeshRenderer>();
        meshRendered.sharedMaterial = material;
        meshFilter.sharedMesh = meshData.CreateMesh();
        meshRendered.sharedMaterial.SetTexture("_BaseMap", texture);
        return meshFilter.sharedMesh;
    }

}