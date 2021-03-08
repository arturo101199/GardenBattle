using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] TerrainGenerator terrainGenerator = null;
    [SerializeField] BaseGenerator baseGenerator = null;

    void Start()
    {
        terrainGenerator.GenerateMap();
        baseGenerator.PlaceBases();
    }

}