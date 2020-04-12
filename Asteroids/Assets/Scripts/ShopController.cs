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
}
