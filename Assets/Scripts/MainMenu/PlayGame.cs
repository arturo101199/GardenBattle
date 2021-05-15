using UnityEngine;

public class PlayGame : MonoBehaviour
{
    [SerializeField] MenuScenario menuScenario = null;
    [SerializeField] GameObject notEnoughCharacterTypesGO = null;
    [SerializeField] SceneTransitioner sceneTransitioner = null;
    [SerializeField] InputFieldsController inputFieldsController = null;
    bool isTransitioning;

    private void Start()
    {
        isTransitioning = false;
    }

    public void TryPlayGame()
    {
        int nTypes = 0;
        int nTotalCharacters = 0;
        foreach (BaseInfo baseInfo in menuScenario.BasesInfo.baseInfos)
        {
            int nCharacters = (int)baseInfo.GlobalBlackboard.GetValue("totalNumberOfCharacters");
            if (nCharacters > 0)
            {
                nTypes += 1;
                nTotalCharacters += nCharacters; 
            }
        }
        if(nTypes > 1)
        {
            if (isTransitioning) return;
            GameGlobalBlackboard.Instance.UpdateValue("totalNumberOfCharacters", nTotalCharacters);
            sceneTransitioner.LoadScene(1);
            isTransitioning = true;
            inputFieldsController.BlockFields();
            return;
        }
        else
        {
            notEnoughCharacterTypesGO.SetActive(true);
            notEnoughCharacterTypesGO.GetComponent<DelayedSetInactive>().DelaySetInactive(4f);
        }
    }
}