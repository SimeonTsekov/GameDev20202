using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldPriceController : MonoBehaviour
{
    Text txt;

    void Start()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        if (GameStateController.Instance.shieldTier == 0)
        {
            txt.text = "500 ore";
        }
        else if (GameStateController.Instance.shieldTier == 1)
        {
            txt.text = "1000 ore";
        }
        else if (GameStateController.Instance.shieldTier == 2)
        {
            txt.text = "1500 ore";
        }
        else if (GameStateController.Instance.shieldTier == 3)
        {
            txt.text = "";
        }
    }
}
