using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource music;
    public static SoundController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            music.Stop();
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnPlayMusic()
    {
        music.Play(0);
    }

    public void OnStopMusic()
    {
        music.Stop();
    }

    public void OnMusicMute()
    {
        music.volume = 0.0f;
    }

    public void OnMusicUnmute()
    {
        music.volume = 1.0f;
    }
}
