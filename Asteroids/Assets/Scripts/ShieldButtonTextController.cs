using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldButtonTextController : MonoBehaviour
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
            txt.text = "Purchase Shield Mk.1";
        }
        else if (GameStateController.Instance.shieldTier == 1)
        {
            txt.text = "Purchase Shield Mk.2";
        }
        else if (GameStateController.Instance.shieldTier == 2)
        {
            txt.text = "Purchase Shield Mk.3";
        }
        else if(GameStateController.Instance.shieldTier == 3)
        {
            txt.text = "Shield at max level";
        }
    }
}
