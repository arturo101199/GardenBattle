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
            plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            plane.transform.SetParent(surface.transform);
            var flags = StaticEditorFlags.NavigationStatic;
            GameObjectUtility.SetStaticEditorFlags(plane, flags);
        }
        plane.transform.localScale = Vector3.one * scale;
        MeshFilter MeshFilter = plane.GetComponent<MeshFilter>();
        MeshRenderer meshRendered = plane.GetComponent<MeshRenderer>();
        meshRendered.sharedMaterial = material;
        MeshFilter.sharedMesh = meshData.CreateMesh();
        meshRendered.sharedMaterial.SetTexture("_BaseMap", texture);
        plane.GetComponent<MeshCollider>().sharedMesh = MeshFilter.sharedMesh;
        surface.BuildNavMesh();
        print(surface.GetBuildSettings().minRegionArea);
    }

}