using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameCloser : MonoBehaviour
{
    BaseManager baseManager;
    [SerializeField] GameObject winCanvasGO;
    [SerializeField] TextMeshProUGUI winnerText;

    [SerializeField] float timeBeforeEnd = 5f;
    bool isEnding = false;

    float timer = 0f;

    private void Awake()
    {
        baseManager = FindObjectOfType<BaseManager>();
        baseManager.OneRemainingBaseEvent += endGame;
    }

    private void Start()
    {
        timer = 0f;
        isEnding = false;
    }

    private void Update()
    {
        if (isEnding)
        {
            if(timer >= timeBeforeEnd)
            {
                LoadMainMenu();
            }
            else
            {
                timer += Time.unscaledDeltaTime;
            }
        }
    }

    void endGame()
    {
        winCanvasGO.SetActive(true);
        Base winnerBase = baseManager.GetRemainingBase();
        string winner = LayerMask.LayerToName(winnerBase.gameObject.layer);
        winnerText.SetText(winner + "s win");
        isEnding = true;
        baseManager.OneRemainingBaseEvent -= endGame;
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}