﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public bool musicOn = true;
    public bool soundOn = true;
    public bool testerOn;
    private GameObject[] objs;
    public bool opened;
    public static SettingsController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            gameObject.SetActive(false);

            objs = GameObject.FindGameObjectsWithTag("Tester");

            if (SaveSystem.LoadSettings() != null)
            {
                musicOn = SaveSystem.LoadSettings().musicOn;
                soundOn = SaveSystem.LoadSettings().soundOn;
                testerOn = SaveSystem.LoadSettings().testerOn;
            }

            if (!soundOn)
            {
                SoundController.Instance.OnSoundMute();
            }

            if (!testerOn)
            {
                OnTesterDeact();
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

    public void OnTester()
    {
        if (!testerOn)
        {
            OnTesterAct();
            testerOn = true;
        }
        else
        {
            OnTesterDeact();
            testerOn = false;
        }
    }

    void OnTesterDeact()
    {
        foreach (GameObject tester in objs)
        {
            tester.SetActive(false);
        }
    }

    void OnTesterAct()
    {
        foreach (GameObject tester in objs)
        {
            tester.SetActive(true);
        }
    }

    public void OnQuit()
    {
        SaveSystem.SaveSettings(this);
        GameStateController.Instance.QuitGame();
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
