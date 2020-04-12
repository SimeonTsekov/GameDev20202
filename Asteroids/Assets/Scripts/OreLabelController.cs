using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreLabelController : MonoBehaviour
{
    Text txt;

    void Start()
    {
        txt = GetComponent<Text>();
        txt.text += GameStateController.Instance.PlayerOre;
    }

    void Update()
    {
        txt.text = "Ore: " + GameStateController.Instance.PlayerOre;
    }
}
