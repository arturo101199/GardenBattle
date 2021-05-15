using UnityEngine;

public class MenuScenario : MonoBehaviour
{
    //public MenuCharacterHolder[] characters = null;
    [SerializeField] float radius = 5;
    [SerializeField] Transform center = null;
    [SerializeField] Transform closeCamera = null;
    [SerializeField] GameObject inputFieldPrefab = null;
    [SerializeField] Transform inputCanvas = null;
    [SerializeField] InputFieldsController inputFieldsController = null;

    [HideInInspector] public BasesInfo BasesInfo;
    BaseManager baseManager;
    Transform[] characters;

    void Start()
    {
        placeMenuCharacters();
        placeCloseCamera();
    }

    void placeMenuCharacters()
    {
        BasesInfo = FindObjectOfType<BasesInfo>();
        baseManager = FindObjectOfType<BaseManager>();
        baseManager.ResetBaseManager();
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
        closeCamera.position = characters[0].position + (characters[0].position - center.position).normalized * 2.2f;
        closeCamera.position = new Vector3(closeCamera.position.x, 1.3f, closeCamera.position.z);
        Quaternion lookAt = Quaternion.LookRotation(center.position - closeCamera.position);
        closeCamera.rotation = lookAt;
    }
}
