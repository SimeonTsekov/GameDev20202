using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RapidFireButtonTextController : MonoBehaviour
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
            txt.text = "Purchase RapidFire";
        }
        else if (GameStateController.Instance.multishotUpgrades[0])
        {
            txt.text = "RapidFire at max level";
        }
    }
}

