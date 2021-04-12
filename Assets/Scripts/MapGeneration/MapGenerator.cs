using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] TerrainGenerator terrainGenerator = null;
    [SerializeField] BaseGenerator baseGenerator = null;
    [SerializeField] AntFoodGeneration antFoodGeneration = null;
    [SerializeField] SpiderWebGeneration spiderWebGeneration = null;

    StarterCharactersGenerator starterCharactersGenerator;

    void Start()
    {
        terrainGenerator.GenerateMap();
        List<BaseInfo> placedBases = baseGenerator.PlaceBases();
        if ((int)AntGlobalBlackboard.Instance.GetValue("totalNumberOfCharacters") > 0)
            antFoodGeneration.GenerateFood();
        if ((int)SpiderGlobalBlackboard.Instance.GetValue("totalNumberOfCharacters") > 0)
            spiderWebGeneration.GenerateSpiderWebs();
        placeCharacters(placedBases);
    }

    void placeCharacters(List<BaseInfo> placedBases)
    {
        starterCharactersGenerator = new StarterCharactersGenerator();
        foreach (BaseInfo placedBase in placedBases)
        {
            int nCharacters = (int)placedBase.GlobalBlackboard.GetValue("totalNumberOfCharacters");
            Vector3 baseLocation = (Vector3)placedBase.GlobalBlackboard.GetValue("baseLocation");
            starterCharactersGenerator.GenerateCharacters(nCharacters, placedBase.CharacterPrefab, baseLocation);
        }
    }

}