using UnityEngine;

public class SetMenuScenario : MonoBehaviour
{
    [SerializeField] Transform[] elements = null;
    [SerializeField] float radius = 5;
    [SerializeField] Transform center = null;
    [SerializeField] Transform camera = null;

    void Start()
    {
        placeMenuCharacters();
        placeCloseCamera();
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

    void placeCloseCamera()
    {
        camera.position = elements[0].transform.position + (elements[0].transform.position - center.position).normalized * 2.2f;
        camera.position = new Vector3(camera.position.x, 1.3f, camera.position.z);
        Quaternion lookAt = Quaternion.LookRotation(center.position - camera.position);
        camera.rotation = lookAt;
    }
}