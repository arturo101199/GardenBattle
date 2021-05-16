using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    float maxVolume = 0f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        maxVolume = audioSource.volume;
        audioSource.volume = PlayerPrefs.GetFloat("Volume") * maxVolume;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = maxVolume * volume;
    }
}
