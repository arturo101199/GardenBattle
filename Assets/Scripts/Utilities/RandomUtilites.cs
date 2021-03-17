using UnityEngine;

public static class RandomUtilities
{
    public static Vector3 GenerateRandomInsideRectangleXZ(Vector3 center, float height, float width)
    {
        float x = Random.Range(0, width) + (center.x - width/2);
        float z = Random.Range(0, height) + (center.z - height/2);
        return new Vector3(x, 0, z);
    }
}