using System.Collections.Generic;
using UnityEngine;

public class MapDividerInPoints : MonoBehaviour
{
    const int mapChunkSize = 241;
    float mapScale = 1f;
    List<Vector3> points = new List<Vector3>();

    private void Awake()
    {
        mapScale = FindObjectOfType<TerrainGenerator>().planeScale;
    }

    public List<Vector3> DivideSquareMap(float deltaX, float deltaY, float boundaryOffset)
    {
        points.Clear();
        float finalScale = (mapChunkSize - boundaryOffset) * mapScale;
        int halfScale = (int)(finalScale / 2);
        for (float i = -halfScale; i < halfScale; i += deltaX)
        {
            for (float j = -halfScale; j < halfScale; j += deltaY)
            {
                points.Add(new Vector3(i, 0f, j));
            }
        }
        return points;
    }
}