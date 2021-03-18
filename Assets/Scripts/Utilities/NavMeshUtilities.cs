using UnityEngine;
using UnityEngine.AI;

public static class NavMeshUtilities
{
    public static Vector3 SamplePositionNearMe(Vector3 myPos, Vector3 destinationPos)
    {
        Vector3 dirDestinationToMe = (myPos - destinationPos).normalized;
        NavMeshHit hit;
        NavMesh.SamplePosition(destinationPos + dirDestinationToMe * 0.4f, out hit, 3f, NavMesh.AllAreas);
        return hit.position;
    }
}