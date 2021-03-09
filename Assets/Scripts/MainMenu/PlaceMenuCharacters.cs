using UnityEngine;

public class PlaceMenuCharacters : MonoBehaviour
{
    [SerializeField] Transform[] elements = null;
    [SerializeField] float radius = 5;
    [SerializeField] Transform center = null;

    void Start()
    {
        placeMenuCharacters();
    }

    void placeMenuCharacters()
    {
        Vector3[] positions = GeometryUtilities.DivideCircleEquallyXZ(center.position, radius, elements.Length);
        for (int i = 0; i < elements.Length; i++)
        {
            Quaternion lookAt = Quaternion.LookRotation(positions[i] - center.position);
            elements[i].SetPositionAndRotation(positions[i], lookAt);
        }
    }

}

public static class GeometryUtilities
{
    public static Vector3[] DivideCircleEquallyXZ(Vector3 center, float radius, int nPoints)
    {
        Vector3[] result = new Vector3[nPoints];
        float angle = 360 / nPoints * Mathf.Deg2Rad;
        for (int i = 0; i < nPoints; i++)
        {
            float t = angle * i;
            float x = radius * Mathf.Cos(t);
            float z = radius * Mathf.Sin(t);
            Vector3 position = new Vector3(x, 0, z) + center;
            result[i] = position;
        }
        return result;
    }
}