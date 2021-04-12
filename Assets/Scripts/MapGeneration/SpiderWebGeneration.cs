using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderWebGeneration : MonoBehaviour
{
    [SerializeField] float delta = 2.5f;
    [SerializeField] float boundaryOffset = 1f;

    MapDividerInPoints mapDivider = null;
    List<Vector3> spiderWebPositions = new List<Vector3>();

    private void Awake()
    {
        mapDivider = GetComponent<MapDividerInPoints>();
    }

    public void GenerateSpiderWebs()
    {
        List<Vector3> mapPoints = new List<Vector3>(mapDivider.DivideSquareMap(delta, delta, boundaryOffset));
        foreach (Vector3 point in mapPoints)
        {
            AddSpiderWebPosition(point);
        }
        FindObjectOfType<SpiderWebsManagement>().SetSpiderWebPositions(spiderWebPositions);
    }

    void AddSpiderWebPosition(Vector3 position)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 3f, NavMesh.AllAreas))
        {
            spiderWebPositions.Add(hit.position);
        }
    }
}