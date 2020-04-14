﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public string GameOverScene = "GameOver";
    public string MainScene = "MainScene";
    public string ShopScene = "ShopScene";
    public float GameOverDelay = 3;
    public uint Level = 1;
    public bool[] shieldUpgrades = new bool[3];
    public bool[] blastwaveUpgrades = new bool[3];
    public bool[] multishotUpgrades = new bool[3];
    public uint PlayerOre = 0;
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
                shieldUpgrades = SaveSystem.LoadPlayer().shieldUpgrades;
                blastwaveUpgrades = SaveSystem.LoadPlayer().blastwaveUpgrades;
                multishotUpgrades = SaveSystem.LoadPlayer().multishotUpgrades;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsController.Instance.OnSettings();
        }
    }

    public void IncrementPlayerOre(uint oreToAdd)
    {
        PlayerOre += oreToAdd;
    }
    
    public void RestartGame()
    {
        SaveSystem.SavePlayer(this);

        if (SettingsController.Instance.musicOn)
        {
            SoundController.Instance.OnPlayMusic();
        }
        
        SceneManager.LoadScene(MainScene);
    }

    public void QuitGame()
    {
        SaveSystem.SavePlayer(this);
        Application.Quit();
    }

    public void ResetOre()
    {
        PlayerOre = 3500;
        SaveSystem.SavePlayer(this);
    }

    public void ResetLevel()
    {
        Level = 1;
        SaveSystem.SavePlayer(this);
    }

    public void OnPlayerDestroyed()
    {
        Invoke("OnGameOver", GameOverDelay);
    }

    public void OnPassLevel()
    {
        PlayerOre += 50 * Level;
        Level++;
        SoundController.Instance.OnStopMusic();
        SaveSystem.SavePlayer(this);
        SceneManager.LoadScene(GameOverScene);
    }

    public void LoadShop()
    {
        SaveSystem.SavePlayer(this);
        SceneManager.LoadScene(ShopScene);
    }

    public void LoadMenu()
    {
        SaveSystem.SavePlayer(this);
        SceneManager.LoadScene(GameOverScene);
    }

    public void PurchaseShieldMk1()
    {
        shieldUpgrades[0] = true;
        PlayerOre -= 500;
        SaveSystem.SavePlayer(this);
    }

    public void PurchaseBlastwaveMk1()
    {
        blastwaveUpgrades[0] = true;
        PlayerOre -= 1000;
        SaveSystem.SavePlayer(this);
    }

    public void PurchaseMultishotMk1()
    {
        multishotUpgrades[0] = true;
        PlayerOre -= 2000;
        SaveSystem.SavePlayer(this);
    }

    public void OnRazeGame()
    {
        SaveSystem.RazeData();
    }

    private void OnGameOver()
    {
        SaveSystem.SavePlayer(this);
        SoundController.Instance.OnStopMusic();
        SceneManager.LoadScene(GameOverScene);
    }
}
