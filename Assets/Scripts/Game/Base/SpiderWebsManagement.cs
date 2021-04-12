using System.Collections.Generic;
using UnityEngine;

public class SpiderWebsManagement : MonoBehaviour
{
    Stack<Vector3> sortedSpiderWebPositions = new Stack<Vector3>();

    public void SetSpiderWebPositions(List<Vector3> SpiderWebPositions)
    {
        ListUtilities.SortFromDistanceToAnObject(SpiderWebPositions, transform.position);
        SpiderWebPositions.Reverse();
        foreach (Vector3 position in SpiderWebPositions)
        {
            AddSpiderWebPosition(position);
        }
        AntGlobalBlackboard.Instance.AddKeyValue("spiderWebsManagement", this);
    }

    public Vector3 GetSpiderWebPosition()
    {
        if (sortedSpiderWebPositions.Count > 0)
            return sortedSpiderWebPositions.Pop();
        return Vector3.zero;
    }

    public void AddSpiderWebPosition(Vector3 position)
    {
        sortedSpiderWebPositions.Push(position);
    }
}