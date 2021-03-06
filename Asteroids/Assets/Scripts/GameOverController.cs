﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void OnRestart()
    {
        GameStateController.Instance.RestartGame();
    }

    public void OnQuit()
    {
        GameStateController.Instance.QuitGame();
    }

    public void OnAchievements()
    {
        AchievementsController.Instance.OnAchievements();
    }
    
    public void OnResetLevel()
    {
        GameStateController.Instance.ResetLevel();
    }

    public void OnShop()
    {
        GameStateController.Instance.LoadShop();
    }

    public void OnRazeGame()
    {
        GameStateController.Instance.OnRazeGame();
    }

    public void OnSettings()
    {
        SettingsController.Instance.OnSettings();
    }
}
