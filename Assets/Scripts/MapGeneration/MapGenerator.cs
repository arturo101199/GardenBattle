using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] TerrainGenerator terrainGenerator = null;
    [SerializeField] BaseGenerator baseGenerator = null;
    [SerializeField] AntFoodGeneration antFoodGeneration = null;

    void Start()
    {
        terrainGenerator.GenerateMap();
        baseGenerator.PlaceBases();
        if((int)AntGlobalBlackboard.Instance.GetValue("totalNumberOfCharacters") > 0)
            antFoodGeneration.GenerateFood();
    }

}