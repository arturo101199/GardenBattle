using UnityEngine;

public static class RaycastUtilities
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
