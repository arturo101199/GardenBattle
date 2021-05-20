using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseGenerator : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer = 0;
    [SerializeField] float terrainSize = 48f;
    [SerializeField] float terrainSizeOffset = 3f; //Offset for not placing bases just on the edge of the map
    [SerializeField] BasesInfo basesInfo = null;
    [SerializeField] Transform parentTransform = null;
    [SerializeField] float baseSeparation = 50f;

    Collider[] colsCache = new Collider[16];

    public List<BaseInfo> PlaceBases()
    {
        basesInfo = FindObjectOfType<BasesInfo>();
        List<BaseInfo> basesPlaced = new List<BaseInfo>();
        foreach (BaseInfo baseInfo in basesInfo.baseInfos)
        {
            int nCharacters = (int)baseInfo.GlobalBlackboard.GetValue("totalNumberOfCharacters");
            if(nCharacters > 0)
            {
                GameObject myBase = Instantiate(baseInfo.BasePrefab, findBasePosition(), Quaternion.identity, parentTransform);
                baseInfo.GlobalBlackboard.UpdateValue("baseLocation", myBase.transform.position);
                rotateBase(myBase.transform);
                myBase.GetComponent<Base>().SetGlobalBlackboard(baseInfo.GlobalBlackboard);
                basesPlaced.Add(baseInfo);
                FindObjectOfType<NavMeshSurface>().BuildNavMesh();
            }
        }
        return basesPlaced;
    }

    Vector3 findBasePosition()
    {
        Vector3 randomPosition = RandomUtilities.GenerateRandomInsideRectangleXZ(Vector3.zero, terrainSize - terrainSizeOffset, terrainSize - terrainSizeOffset);
        NavMeshHit hit;
        int tries = 0;
        bool isValidPosition = NavMesh.SamplePosition(randomPosition, out hit, 3f, NavMesh.AllAreas) && !IsAnotherBaseNear(hit.position);
        while (!isValidPosition)
        {
            tries++;
            randomPosition = RandomUtilities.GenerateRandomInsideRectangleXZ(Vector3.zero, terrainSize - terrainSizeOffset, terrainSize - terrainSizeOffset);
            isValidPosition = NavMesh.SamplePosition(randomPosition, out hit, 3f, NavMesh.AllAreas) && !IsAnotherBaseNear(hit.position);
        }
        print(tries);
        return hit.position;
    }

    void rotateBase(Transform myBase)
    {
        TransformUtilities.RotateObjectPerpendicularToTheGround(myBase, groundLayer);
    }

    bool IsAnotherBaseNear(Vector3 pos)
    {
        int cols = Physics.OverlapSphereNonAlloc(pos, baseSeparation, colsCache);
        for (int i = 0; i < cols; i++)
        {
            if (colsCache[i].CompareTag("Base"))
                return true;
        }
        return false;
    }
}
