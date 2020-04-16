using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{
    public GameObject rapid;

    public void OnLoadMenu()
    {
        GameStateController.Instance.LoadMenu();
        if (SettingsController.Instance.opened)
        {
            SettingsController.Instance.OnSettings();
        }
    }
    
    public void OnPurchaseShieldMk1()
    {
        if (GameStateController.Instance.PlayerOre >= 500 && GameStateController.Instance.shieldTier == 0)
        {
            AbilitiesController.Instance.SetShieldActive();
            GameStateController.Instance.PurchaseShieldMk1();
        } 
        else if(GameStateController.Instance.PlayerOre >= 1000 && GameStateController.Instance.shieldTier == 1)
        {
            GameStateController.Instance.PurchaseShieldMk2();
        }
        else if (GameStateController.Instance.PlayerOre >= 1500 && GameStateController.Instance.shieldTier == 2)
        {
            GameStateController.Instance.PurchaseShieldMk3();
        }
    }

    public void OnPurchaseBlastwaveMk1()
    {
        if (GameStateController.Instance.PlayerOre >= 1000 && !GameStateController.Instance.blastwaveUpgrades[0])
        {
            AbilitiesController.Instance.SetBlastwaveActive();
            GameStateController.Instance.PurchaseBlastwaveMk1();
        }
    }

    public void OnPurchaseMultishotMk1()
    {
        if (GameStateController.Instance.PlayerOre >= 1000 && !GameStateController.Instance.multishotUpgrades[0])
        {
            AbilitiesController.Instance.SetRapidFireActive();
            GameStateController.Instance.PurchaseMultishotMk1();
            Destroy(rapid);
        }
    }

    public void OnSettings()
    {
        SettingsController.Instance.OnSettings();
    }
}
