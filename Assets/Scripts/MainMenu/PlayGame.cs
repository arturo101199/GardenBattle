using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField] MenuScenario menuScenario = null;

    public void TryPlayGame()
    {
        int nTypes = 0;
        foreach (BaseInfo baseInfo in menuScenario.BasesInfo.baseInfos)
        {
            if ((int)baseInfo.GlobalBlackboard.GetValue("totalNumberOfCharacters") > 0)
                nTypes += 1;
        }
        if(nTypes > 1)
        {
            //Load Game Scene
            SceneManager.LoadScene(1);
            return;
        }
        else
        {
            //Make some feedback to notice the player that he can't play without at least two types of characters
        }
    }
}