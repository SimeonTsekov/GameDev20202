using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsController : MonoBehaviour
{
    public bool opened;
    public static AchievementsController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnAchievements()
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

    public void OnBack()
    {
        Resume();
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
    }
}
