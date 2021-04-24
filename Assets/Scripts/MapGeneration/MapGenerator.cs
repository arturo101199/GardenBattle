using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] TerrainGenerator terrainGenerator = null;
    [SerializeField] BaseGenerator baseGenerator = null;
    [SerializeField] AntFoodGeneration antFoodGeneration = null;
    [SerializeField] SpiderWebGeneration spiderWebGeneration = null;

    List<BaseInfo> placedBases;
    StarterCharactersGenerator starterCharactersGenerator;

    void Start()
    {
        generateTerrain();
        placeBases();
        generateSpecialObjects();
        placeCharacters();
    }

    void placeCharacters()
    {
        starterCharactersGenerator = new StarterCharactersGenerator();
        foreach (BaseInfo placedBase in placedBases)
        {
            int nCharacters = (int)placedBase.GlobalBlackboard.GetValue("totalNumberOfCharacters");
            Vector3 baseLocation = (Vector3)placedBase.GlobalBlackboard.GetValue("baseLocation");
            starterCharactersGenerator.GenerateCharacters(nCharacters, placedBase.CharacterPrefab, baseLocation);
        }
    }

    void generateTerrain()
    {
        terrainGenerator.GenerateMap();
    }

    void generateSpecialObjects()
    {
        if ((int)AntGlobalBlackboard.Instance.GetValue("totalNumberOfCharacters") > 0)
            antFoodGeneration.GenerateFood();
        if ((int)SpiderGlobalBlackboard.Instance.GetValue("totalNumberOfCharacters") > 0)
            spiderWebGeneration.GenerateSpiderWebs();
    }

    void placeBases()
    {
        placedBases = baseGenerator.PlaceBases();
    }
}