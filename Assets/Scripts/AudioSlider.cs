using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Volume");
    }

    public void OnValueChange(float value)
    {
        print(value);
        PlayerPrefs.SetFloat("Volume", value);
        audioManager.SetVolume(value);
    }
}