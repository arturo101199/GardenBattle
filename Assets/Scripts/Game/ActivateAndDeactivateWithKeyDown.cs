using UnityEngine;

public class ActivateAndDeactivateWithKeyDown : MonoBehaviour
{
    [SerializeField] KeyCode key = KeyCode.Escape;
    [SerializeField] GameObject GO = null;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            GO.SetActive(!GO.activeSelf);
        }
    }
}