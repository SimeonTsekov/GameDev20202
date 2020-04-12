using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{
    public void OnLoadMenu()
    {
        GameStateController.Instance.LoadMenu();
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
}
