using UnityEngine;

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
