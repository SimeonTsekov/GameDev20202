using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public string GameOverScene = "GameOver";
    public string MainScene = "MainScene";
    public float GameOverDelay = 3;
    public uint Level = 1;
    public uint PlayerOre { get; private set;} = 0;
    public static GameStateController Instance { get; private set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (SaveSystem.LoadPlayer() != null)
            {
                PlayerOre = SaveSystem.LoadPlayer().playerOre;
                Level = SaveSystem.LoadPlayer().level;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void IncrementPlayerOre(uint oreToAdd)
    {
        PlayerOre += oreToAdd;
    }
    
    public void RestartGame()
    {
        SaveSystem.SavePlayer(this);
        SceneManager.LoadScene(MainScene);
    }

    public void QuitGame()
    {
        SaveSystem.SavePlayer(this);
        Application.Quit();
    }

    public void ResetOre()
    {
        PlayerOre = 0;
        SaveSystem.SavePlayer(this);
    }
    
    public void OnPlayerDestroyed()
    {
        Invoke("OnGameOver", GameOverDelay);
    }

    public void OnPassLevel()
    {
        Level++;
        SaveSystem.SavePlayer(this);
        SceneManager.LoadScene(GameOverScene);
    }

    private void OnGameOver()
    {
        SaveSystem.SavePlayer(this);
        SceneManager.LoadScene(GameOverScene);
    }
}
