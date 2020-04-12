using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public uint asteroidCount { get; private set; } = 0;
    public static LevelController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            asteroidCount = GameStateController.Instance.Level;
            Debug.Log(asteroidCount);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (asteroidCount == 0)
        {
            Debug.Log("End");
            EndLevel();
        }
    }

    public void DecreaseAsteroidCount()
    {
        asteroidCount --;
    }

    public void IncreaseAsteroidCount(uint count)
    {
        asteroidCount += count;
    }

    public void EndLevel()
    {
        GameStateController.Instance.OnPassLevel();
    }
}
