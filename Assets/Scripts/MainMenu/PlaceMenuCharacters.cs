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
        Vector3[] positions = GeometryUtilities.DivideCircleEquallyXZ(center.position, radius, elements.Length, 0f);
        for (int i = 0; i < elements.Length; i++)
        {
            Quaternion lookAt = Quaternion.LookRotation(positions[i] - center.position);
            elements[i].SetPositionAndRotation(positions[i], lookAt);
        }
    }

}