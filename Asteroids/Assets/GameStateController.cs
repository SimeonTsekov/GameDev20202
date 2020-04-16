using System.Collections;
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
    public int shieldTier = 0;
    public int blastwaveTier = 0;
    public GameObject abilities;
    public static GameStateController Instance { get; private set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            AbilitiesController.Instance.SetShieldInactive();
            AbilitiesController.Instance.SetBlastwaveInactive();
            AbilitiesController.Instance.SetRapidFireInactive();

            if (SaveSystem.LoadPlayer() != null)
            {
                PlayerOre = SaveSystem.LoadPlayer().playerOre;
                Level = SaveSystem.LoadPlayer().level;
                shieldUpgrades = SaveSystem.LoadPlayer().shieldUpgrades;
                blastwaveUpgrades = SaveSystem.LoadPlayer().blastwaveUpgrades;
                multishotUpgrades = SaveSystem.LoadPlayer().multishotUpgrades;
                shieldTier = SaveSystem.LoadPlayer().shieldTier;
                blastwaveTier = SaveSystem.LoadPlayer().blastwaveTier;
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
        SoundController.Instance.OnPlayMusic();

        if (!SettingsController.Instance.musicOn)
        {
            SoundController.Instance.OnMusicMute();
        }

        Invoke("SetAbilitiesActive", 0.1f);
        SceneManager.LoadScene(MainScene);
    }

    public void QuitGame()
    {
        SaveSystem.SavePlayer(this);
        Application.Quit();
    }

    public void ResetLevel()
    {
        Level = 5;
        SaveSystem.SavePlayer(this);
    }

    public void OnPlayerDestroyed()
    {
        AbilitiesController.Instance.RemoveCooldown();
        Invoke("OnGameOver", GameOverDelay);
    }

    public void OnPassLevel()
    {
        SetAbilitiesInactive();
        AbilitiesController.Instance.RemoveCooldown();
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
        shieldTier++;
        shieldUpgrades[0] = true;
        PlayerOre -= 500;
        SaveSystem.SavePlayer(this);
    }

    public void PurchaseShieldMk2()
    {
        shieldTier++;
        shieldUpgrades[1] = true;
        PlayerOre -= 1000;
        SaveSystem.SavePlayer(this);
    }

    public void PurchaseShieldMk3()
    {
        shieldTier++;
        shieldUpgrades[2] = true;
        PlayerOre -= 1500;
        SaveSystem.SavePlayer(this);
    }

    public void PurchaseBlastwaveMk1()
    {
        blastwaveTier++;
        blastwaveUpgrades[0] = true;
        PlayerOre -= 1000;
        SaveSystem.SavePlayer(this);
    }

    public void PurchaseBlastwaveMk2()
    {
        blastwaveTier++;
        blastwaveUpgrades[1] = true;
        PlayerOre -= 2000;
        SaveSystem.SavePlayer(this);
    }

    public void PurchaseBlastwaveMk3()
    {
        blastwaveTier++;
        blastwaveUpgrades[2] = true;
        PlayerOre -= 3000;
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
        SetAbilitiesInactive();
        SaveSystem.SavePlayer(this);
        SoundController.Instance.OnStopMusic();
        SceneManager.LoadScene(GameOverScene);
    }

    void SetAbilitiesActive()
    {
        if (shieldUpgrades[0])
        {
            Debug.Log(true);
            AbilitiesController.Instance.SetShieldActive();
        }

        if (blastwaveUpgrades[0])
        {
            Debug.Log(true);
            AbilitiesController.Instance.SetBlastwaveActive();
        }

        if (multishotUpgrades[0])
        {
            Debug.Log(true);
            AbilitiesController.Instance.SetRapidFireActive();
        }
    }

    void SetAbilitiesInactive()
    {
        AbilitiesController.Instance.SetShieldInactive();
        AbilitiesController.Instance.SetBlastwaveInactive();
        AbilitiesController.Instance.SetRapidFireInactive();
    }
}
