using UnityEngine;

public static class TransformUtilities
{
    public static void RotateObjectPerpendicularToTheGround(Transform myObject, int groundLayer)
    {
        Vector3 normal = RaycastUtilities.GetGroundNormal(myObject.position, groundLayer);
        Vector3 forward = Vector3.Cross(myObject.right, normal);
        Quaternion lookRotation = Quaternion.LookRotation(forward, normal);
        myObject.rotation = lookRotation;
    }
}