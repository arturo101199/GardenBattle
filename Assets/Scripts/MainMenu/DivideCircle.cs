using UnityEngine;

public class DivideCircle : MonoBehaviour
{
    [SerializeField] Transform[] elements = null;
    [SerializeField] float radius = 5;

    void Start()
    {
        float angle = 360 / elements.Length * Mathf.Deg2Rad;
        for (int i = 0; i < elements.Length; i++)
        {
            CalculatePositionAndRotation(angle, i);
        }
    }

    void CalculatePositionAndRotation(float angle, int index)
    {
        float t = angle * index;
        float x = radius * Mathf.Cos(t);
        float z = radius * Mathf.Sin(t);
        Vector3 position = new Vector3(x, 0, z);
        Quaternion lookAt = Quaternion.LookRotation(position);
        elements[index].SetPositionAndRotation(position, lookAt);
    }

}