using UnityEngine;
using UnityEngine.AI;

public class AntFoodGeneration : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab;
    public void GenerateFood()
    {
        float mapScale = FindObjectOfType<TerrainGenerator>().planeScale;
        const int mapChunkSize = 241;
        float finalScale = (mapChunkSize-1) * mapScale;
        int halfScale = (int)(finalScale / 2);
        for (int i = -halfScale; i < halfScale; i += 2)
        {
            for (int j = -halfScale; j < halfScale; j+=2)
            {
                spawnFood(new Vector3(i, 0f, j));
            }
        }
    }

    void spawnFood(Vector3 position)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 3f, NavMesh.AllAreas))
        {
            Instantiate(foodPrefab, hit.position, Quaternion.identity).SetActive(true);
        }
        else
        {
            print("No se pudo");
        }
    }
}