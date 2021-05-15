using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    [SerializeField] Transform[] UIPositions = null;
    [SerializeField] Transform selectedImage = null;

    bool isLocked;

    void Start()
    {
        isLocked = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetGameSpeed(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SetGameSpeed(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            SetGameSpeed(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            SetGameSpeed(3);

    }

    public void LockSpeed()
    {
        isLocked = true;
    }

    public void SetGameSpeed(int speed)
    {
        if (isLocked) return;
        Time.timeScale = Mathf.Pow(2, speed);
        selectedImage.position = UIPositions[speed].position;
    }

    void OnDisable()
    {
        SetGameSpeed(0);
    }
}