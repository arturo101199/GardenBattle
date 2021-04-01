using UnityEngine;

public static class GeometryUtilities
{
    public static Vector3[] DivideCircleEquallyXZ(Vector3 center, float radius, int nPoints, float angleOffset)
    {
        Vector3[] result = new Vector3[nPoints];
        float angle = 360 / nPoints * Mathf.Deg2Rad;
        for (int i = 0; i < nPoints; i++)
        {
            Debug.Log(angle);
            float t = angle * i + angleOffset * Mathf.Deg2Rad;
            float x = radius * Mathf.Cos(t);
            float z = radius * Mathf.Sin(t);
            Vector3 position = new Vector3(x, 0, z) + center;
            result[i] = position;
        }
        return result;
    }
}