using UnityEngine;
using TMPro;

public class GameCloser : MonoBehaviour
{
    BaseManager baseManager;
    [SerializeField] GameObject winCanvasGO = null;
    [SerializeField] TextMeshProUGUI winnerText = null;
    [SerializeField] GameSpeedController gameSpeedController = null;
    [SerializeField] SceneTransitioner sceneTransitioner = null;

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
                loadMainMenu();
            }
            else
            {
                timer += Time.unscaledDeltaTime;
            }
        }
    }

    void endGame()
    {        
        isEnding = true;
        displayWinner();
        lockGameSpeed();
        baseManager.OneRemainingBaseEvent -= endGame;

    }

    public void EndFromSettingsMenu()
    {
        lockGameSpeed();
        loadMainMenu();
        baseManager.OneRemainingBaseEvent -= endGame;
    }

    void displayWinner()
    {
        winCanvasGO.SetActive(true);
        Base winnerBase = baseManager.GetRemainingBase();
        string winner = LayerMask.LayerToName(winnerBase.gameObject.layer);
        winnerText.SetText(winner + "s win");
    }

    void lockGameSpeed()
    {
        gameSpeedController.SetGameSpeed(0);
        gameSpeedController.LockSpeed();
    }

    void loadMainMenu()
    {
        sceneTransitioner.LoadScene(0);
    }
}