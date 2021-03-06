﻿using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRender;
    public MeshFilter MeshFilter;
    public MeshRenderer meshRendered;

    public void DrawTexture(Texture2D texture)
    {
        
        textureRender.sharedMaterial.SetTexture("_MainTex", texture);
        textureRender.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    public void DrawMesh(MeshData meshData, Texture2D texture)
    {
        MeshFilter.sharedMesh = meshData.CreateMesh();
        meshRendered.sharedMaterial.SetTexture("_BaseMap", texture);
    }
}