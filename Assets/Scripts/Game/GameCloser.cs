using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameCloser : MonoBehaviour
{
    BaseManager baseManager;
    [SerializeField] GameObject winCanvasGO;
    [SerializeField] TextMeshProUGUI winnerText;

    private void Awake()
    {
        baseManager = FindObjectOfType<BaseManager>();
        baseManager.OneRemainingBaseEvent += endGame;
    }

    void endGame()
    {
        winCanvasGO.SetActive(true);
        Base winnerBase = baseManager.GetRemainingBase();
        string winner = LayerMask.LayerToName(winnerBase.gameObject.layer);
        winnerText.SetText(winner + "s win");
        Invoke("LoadMainMenu", 5f);
        baseManager.OneRemainingBaseEvent -= endGame;
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}