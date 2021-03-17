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

public static class Vector3Utilities
{
    public static Vector3 GetDirectionXZFromTo(Vector3 from, Vector3 to)
    {
        Vector3 fromXZ = new Vector3(from.x, 0f, from.z);
        Vector3 toXZ = new Vector3(to.x, 0f, to.z);

        Vector3 direction = Vector3.Normalize(toXZ - fromXZ);
        return direction;
    }
}
