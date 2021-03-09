using UnityEngine;

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
