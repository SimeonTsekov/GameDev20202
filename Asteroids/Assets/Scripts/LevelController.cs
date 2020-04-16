using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public uint asteroidCount { get; private set; } = 0;
    public GameObject boss;
    public GameObject player;
    public uint bossCount;
    public static LevelController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
            asteroidCount = GameStateController.Instance.Level;

            if (GameStateController.Instance.Level % 5 == 0)
            {
                SpawnBoss();
                bossCount = 1;
                asteroidCount = 0;
            }

            Debug.Log(asteroidCount);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (asteroidCount == 0 && bossCount == 0)
        {
            Debug.Log("End");
            Invoke("EndLevel", 1.0f);
        }
    }

    public void DecreaseAsteroidCount()
    {
        asteroidCount --;
    }

    public void DecreaseBossCount()
    {
        bossCount --;
    }

    public void IncreaseAsteroidCount(uint count)
    {
        asteroidCount += count;
    }

    public void EndLevel()
    {
        GameStateController.Instance.OnPassLevel();
    }

    public void SpawnBoss()
    {
        boss = Instantiate(boss, new Vector3(0,0,5), Quaternion.identity);
        boss.transform.localScale = new Vector3(7, 7, 7);
    }
}
