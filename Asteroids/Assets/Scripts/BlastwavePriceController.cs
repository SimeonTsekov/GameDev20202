using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlastwavePriceController : MonoBehaviour
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
            txt.text = "1000 ore";
        }
        else if (GameStateController.Instance.blastwaveTier == 1)
        {
            txt.text = "2000 ore";
        }
        else if (GameStateController.Instance.blastwaveTier == 2)
        {
            txt.text = "3000 ore";
        }
        else if (GameStateController.Instance.blastwaveTier == 3)
        {
            txt.text = "";
        }
    }
}

