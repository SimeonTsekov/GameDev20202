using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public bool musicOn = true;
    public bool soundOn = true;
    public bool opened;
    public static SettingsController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            gameObject.SetActive(false);

            if (SaveSystem.LoadSettings() != null)
            {
                musicOn = SaveSystem.LoadSettings().musicOn;
                soundOn = SaveSystem.LoadSettings().soundOn;
            }

            if (!soundOn)
            {
                SoundController.Instance.OnSoundMute();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnSettings()
    {
        if (!opened)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void OnMusic()
    {
        if (!musicOn)
        {
            SoundController.Instance.OnMusicUnmute();
            musicOn = true;
        }
        else
        {
            SoundController.Instance.OnMusicMute();
            musicOn = false;
        }
    }

    public void OnSound()
    {
        if (!soundOn)
        {
            SoundController.Instance.OnSoundUnmute();
            soundOn = true;
        }
        else
        {
            SoundController.Instance.OnSoundMute();
            soundOn = false;
        }
    }

    void Pause()
    {
        opened = true;
        Time.timeScale = 0.0f;
        gameObject.SetActive(true);
    }

    void Resume()
    {
        opened = false;
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        SaveSystem.SaveSettings(this);
    }
}
