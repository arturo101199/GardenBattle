﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseGenerator : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer = 0;
    [SerializeField] float terrainSize = 48f;
    [SerializeField] float terrainSizeOffset = 1f; //Offset for not placing bases just on the edge of the map
    [SerializeField] BaseInfo[] baseInfos = null;
    [SerializeField] Transform parentTransform = null;

    public List<BaseInfo> PlaceBases()
    {
        List<BaseInfo> basesPlaced = new List<BaseInfo>();
        foreach (BaseInfo baseInfo in baseInfos)
        {
            int nCharacters = (int)baseInfo.GlobalBlackboard.GetValue("totalNumberOfCharacters");
            if(nCharacters > 0)
            {
                GameObject myBase = Instantiate(baseInfo.BasePrefab, findBasePosition(), Quaternion.identity, parentTransform);
                baseInfo.GlobalBlackboard.UpdateValue("baseLocation", myBase.transform.position);
                rotateBase(myBase.transform);
                basesPlaced.Add(baseInfo);
            }
        }
        FindObjectOfType<NavMeshSurface>().BuildNavMesh();
        return basesPlaced;
    }

    Vector3 findBasePosition()
    {
        Vector3 randomPosition = RandomUtilites.GenerateRandomInsideRectangleXZ(Vector3.zero, terrainSize - terrainSizeOffset, terrainSize - terrainSizeOffset);
        NavMeshHit hit;
        bool isValidPosition = NavMesh.SamplePosition(randomPosition, out hit, 3f, NavMesh.AllAreas);
        while (!isValidPosition)
        {
            randomPosition = RandomUtilites.GenerateRandomInsideRectangleXZ(Vector3.zero, terrainSize - terrainSizeOffset, terrainSize - terrainSizeOffset);
            isValidPosition = NavMesh.SamplePosition(randomPosition, out hit, 3f, NavMesh.AllAreas);
        }
        return hit.position;
    }

    void rotateBase(Transform myBase)
    {
        TransformUtilites.RotateObjectPerpendicularToTheGround(myBase, groundLayer);
    }
}
