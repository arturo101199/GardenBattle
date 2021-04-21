using UnityEngine;

public class MenuScenario : MonoBehaviour
{
    //public MenuCharacterHolder[] characters = null;
    [SerializeField] float radius = 5;
    [SerializeField] Transform center = null;
    [SerializeField] Transform camera = null;
    [SerializeField] GameObject inputFieldPrefab = null;
    [SerializeField] Transform inputCanvas = null;
    [SerializeField] InputFieldsController inputFieldsController = null;

    public BasesInfo BasesInfo;
    Transform[] characters;

    void Start()
    {
        placeMenuCharacters();
        placeCloseCamera();
    }

    void placeMenuCharacters()
    {
        BasesInfo = FindObjectOfType<BasesInfo>();
        BaseInfo[] baseInfos = BasesInfo.baseInfos;
        Vector3[] positions = GeometryUtilities.DivideCircleEquallyXZ(center.position, radius, baseInfos.Length, 0f);
        InputField[] inputFields = new InputField[baseInfos.Length];
        characters = new Transform[baseInfos.Length];
        for (int i = 0; i < baseInfos.Length; i++)
        {
            Quaternion lookAt = Quaternion.LookRotation(positions[i] - center.position);
            GameObject character = Instantiate(baseInfos[i].CharacterMenuPrefab, positions[i], lookAt);
            characters[i] = character.transform;
            InputField inputField = Instantiate(inputFieldPrefab, inputCanvas).GetComponent<InputField>();
            inputField.SetGlobalBlackboard(baseInfos[i].GlobalBlackboard);
            baseInfos[i].GlobalBlackboard.ResetBlackBoard();
            inputFields[i] = inputField;
        }
        inputFieldsController.SetInputFields(inputFields);
        GameGlobalBlackboard.Instance.ResetBlackBoard();
    }

    void placeCloseCamera()
    {
        camera.position = characters[0].position + (characters[0].position - center.position).normalized * 2.2f;
        camera.position = new Vector3(camera.position.x, 1.3f, camera.position.z);
        Quaternion lookAt = Quaternion.LookRotation(center.position - camera.position);
        camera.rotation = lookAt;
    }
}
