﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{
    public void OnLoadMenu()
    {
        GameStateController.Instance.LoadMenu();
    }
}
