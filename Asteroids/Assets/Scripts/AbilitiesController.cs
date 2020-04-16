using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesController : MonoBehaviour
{
    public GameObject shield;
    public GameObject blastwave;
    public GameObject rapidFire;
    public Image cooldownImage;
    public float cooldown = 0;
    public int health = 0;
    public int shieldTier = 0;
    public static AbilitiesController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("DecreaseBlastwaveCooldown", 1.0f, 0.01f);
    }

    public void SetShieldActive()
    {
        Debug.Log("Shield Active");
        shield.SetActive(true);
    }

    public void SetBlastwaveActive()
    {
        blastwave.SetActive(true);
    }

    public void SetRapidFireActive()
    {
        rapidFire.SetActive(true);
    }

    public void SetShieldInactive()
    {
        shield.SetActive(false);
    }

    public void SetBlastwaveInactive()
    {
        blastwave.SetActive(false);
    }

    public void SetRapidFireInactive()
    {
        rapidFire.SetActive(false);
    }

    void DecreaseBlastwaveCooldown()
    {
        if (cooldown > 0)
        {
            cooldown -= 0.01f;
        }
    }

    public void SetCooldown()
    {
        cooldown = 10;
    }

    public void DecreaseShieldHealth()
    {
        health--;
    }

    public void SetShieldHealth(int amount)
    {
        health = amount;
    }

    public void RemoveCooldown()
    {
        cooldown = 0;
    }
}
