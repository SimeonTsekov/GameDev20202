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
        if (GameStateController.Instance.PlayerOre >= 500 && !GameStateController.Instance.shieldUpgrades[0])
        {
            GameStateController.Instance.PurchaseShieldMk1();
        }
    }

    public void OnPurchaseBlastwaveMk1()
    {
        if (GameStateController.Instance.PlayerOre >= 1000 && !GameStateController.Instance.blastwaveUpgrades[0])
        {
            GameStateController.Instance.PurchaseBlastwaveMk1();
        }
    }

    public void OnPurchaseMultishotMk1()
    {
        if (GameStateController.Instance.PlayerOre >= 1000 && !GameStateController.Instance.multishotUpgrades[0])
        {
            GameStateController.Instance.PurchaseMultishotMk1();
            Destroy(rapid);
        }
    }

    public void OnSettings()
    {
        SettingsController.Instance.OnSettings();
    }
}
