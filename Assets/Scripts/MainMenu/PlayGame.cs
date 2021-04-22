using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField] MenuScenario menuScenario = null;
    [SerializeField] GameObject notEnoughCharacterTypesGO = null;

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
            //Load Game Scene
            GameGlobalBlackboard.Instance.UpdateValue("totalNumberOfCharacters", nTotalCharacters);
            SceneManager.LoadScene(1);
            return;
        }
        else
        {
            notEnoughCharacterTypesGO.SetActive(true);
            notEnoughCharacterTypesGO.GetComponent<DelayedSetInactive>().DelaySetInactive(4f);
        }
    }
}