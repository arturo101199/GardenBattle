using UnityEngine;

public class SetMenuScenario : MonoBehaviour
{
    [SerializeField] MenuCharacterHolder[] characters = null;
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
        Vector3[] positions = GeometryUtilities.DivideCircleEquallyXZ(center.position, radius, characters.Length, 0f);
        for (int i = 0; i < characters.Length; i++)
        {
            Quaternion lookAt = Quaternion.LookRotation(positions[i] - center.position);
            characters[i].characterTransform.SetPositionAndRotation(positions[i], lookAt);
        }
    }

    void placeCloseCamera()
    {
        camera.position = characters[0].characterTransform.position + (characters[0].characterTransform.position - center.position).normalized * 2.2f;
        camera.position = new Vector3(camera.position.x, 1.3f, camera.position.z);
        Quaternion lookAt = Quaternion.LookRotation(center.position - camera.position);
        camera.rotation = lookAt;
    }
}

[System.Serializable]
public class MenuCharacterHolder
{
    public Transform characterTransform;
    public GlobalBlackboard globalBlackboard;
}