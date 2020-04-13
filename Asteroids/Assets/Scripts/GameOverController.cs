using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public bool opened;

    public void OnRestart()
    {
        GameStateController.Instance.RestartGame();
    }

    public void OnQuit()
    {
        GameStateController.Instance.QuitGame();
    }

    public void OnResetMinerals()
    {
        GameStateController.Instance.ResetOre();
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
        if (!opened)
        {
            opened = true;
            GameStateController.Instance.OnSettings();
        }
        else
        {
            opened = false;
            GameStateController.Instance.OnDestroySettings();
        }
    }
}
