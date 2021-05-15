using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audio;
    float maxVolume = 0f;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        maxVolume = audio.volume;
        audio.volume = PlayerPrefs.GetFloat("Volume") * maxVolume;
    }

    public void SetVolume(float volume)
    {
        audio.volume = maxVolume * volume;
    }
}
