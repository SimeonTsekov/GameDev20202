using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RapidFirePriceController : MonoBehaviour
{
    Text txt;

    void Start()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        if (!GameStateController.Instance.multishotUpgrades[0])
        {
            txt.text = "2000 ore";
        }
        else if (GameStateController.Instance.multishotUpgrades[0])
        {
            txt.text = "";
        }
    }
}
