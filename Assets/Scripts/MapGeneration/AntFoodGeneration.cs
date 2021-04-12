using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AntFoodGeneration : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab = null;
    [SerializeField] Transform foodContainer = null;
    [SerializeField] float delta = 2.5f;
    [SerializeField] float boundaryOffset = 1f;

    List<Vector3> foodPositions = new List<Vector3>();
    MapDividerInPoints mapDivider = null;


    private void Awake()
    {
        mapDivider = GetComponent<MapDividerInPoints>();
    }
    
    public void GenerateFood()
    {
        List<Vector3> MapPoints = new List<Vector3>(mapDivider.DivideSquareMap(delta, delta, boundaryOffset));
        foreach (Vector3 point in MapPoints)
        {
            spawnFood(point);
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
