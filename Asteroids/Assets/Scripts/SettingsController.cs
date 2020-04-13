using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public bool masterVolumeState;
    public bool opened;
    public static SettingsController Instance { get; private set; }

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

    public void OnSettings()
    {
        if (!opened)
        {
            opened = true;
            gameObject.SetActive(true);
        }
        else
        {
            opened = false;
            gameObject.SetActive(false);
        }
    }
}
