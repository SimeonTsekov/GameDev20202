using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlastwaveButtonTextController : MonoBehaviour
{
    Text txt;

    void Start()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        if (GameStateController.Instance.blastwaveTier == 0)
        {
            txt.text = "Purchase Blastwave Mk.1";
        }
        else if (GameStateController.Instance.blastwaveTier == 1)
        {
            txt.text = "Purchase Blastwave Mk.2";
        }
        else if (GameStateController.Instance.blastwaveTier == 2)
        {
            txt.text = "Purchase Blastwave Mk.3";
        }
        else if (GameStateController.Instance.blastwaveTier == 3)
        {
            txt.text = "Blastwave at max level";
        }
    }
}
