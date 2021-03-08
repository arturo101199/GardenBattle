using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TerrainGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TerrainGenerator mapGen = (TerrainGenerator)target;
        if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.GenerateMap();
            }
        }
        if (GUILayout.Button("Generate"))
        {
            mapGen.GenerateMap();
        }
    }
}