using UnityEngine;
using UnityEngine.AI;

public class BaseGenerator : MonoBehaviour
{
    [SerializeField] Transform[] bases = null;
    [SerializeField] LayerMask groundLayer = 0;

    public void PlaceBases()
    {
        foreach (Transform myBase in bases)
        {
            Vector3 randomPosition = RandomUtilites.GenerateRandomInsideRectangleXZ(Vector3.zero, 48, 48);
            NavMeshHit hit;
            bool isValidPosition = NavMesh.SamplePosition(randomPosition, out hit, 3f, NavMesh.AllAreas);
            while (!isValidPosition)
            {
                randomPosition = RandomUtilites.GenerateRandomInsideRectangleXZ(Vector3.zero, 48, 48);
                isValidPosition = NavMesh.SamplePosition(randomPosition, out hit, 3f, groundLayer);
            }
            myBase.position = hit.position;
            rotateBase(myBase);
        }
    }

    void rotateBase(Transform myBase)
    {
        TransformUtilites.RotateObjectPerpendicularToTheGround(myBase, groundLayer);
    }
}

public static class RaycastUtilites
{
    public static Vector3 GetGroundNormal(Vector3 position, int groundLayer)
    {
        Ray ray = new Ray(position, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, groundLayer))
        {
            return hit.normal;
        }
        return Vector3.up;
    }
}

public static class TransformUtilites
{
    public static void RotateObjectPerpendicularToTheGround(Transform myObject, int groundLayer)
    {
        Vector3 normal = RaycastUtilites.GetGroundNormal(myObject.position, groundLayer);
        Vector3 forward = Vector3.Cross(myObject.right, normal);
        Quaternion lookRotation = Quaternion.LookRotation(forward, normal);
        myObject.rotation = lookRotation;
    }
}
