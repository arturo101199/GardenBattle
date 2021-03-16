using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AntFoodGeneration : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab = null;
    List<Vector3> foodPositions = new List<Vector3>();
    [SerializeField] Transform foodContainer = null;

    public void GenerateFood()
    {
        float mapScale = FindObjectOfType<TerrainGenerator>().planeScale;
        const int mapChunkSize = 241;
        float finalScale = (mapChunkSize-1) * mapScale;
        int halfScale = (int)(finalScale / 2);
        for (float i = -halfScale; i < halfScale; i += 2.5f)
        {
            for (float j = -halfScale; j < halfScale; j+= 2.5f)
            {
                spawnFood(new Vector3(i, 0f, j));
            }
        }
        FindObjectOfType<FoodManagement>().SetFood(foodPositions);
    }

    void spawnFood(Vector3 position)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 3f, NavMesh.AllAreas))
        {
            Instantiate(foodPrefab, hit.position, Quaternion.identity, foodContainer).SetActive(true);
            foodPositions.Add(hit.position);
        }
    }
}