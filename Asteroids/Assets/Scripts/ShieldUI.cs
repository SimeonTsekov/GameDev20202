using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldUI : MonoBehaviour
{
    Text txt;

    void Start()
    {
        txt = GetComponent<Text>();
        txt.text = "1";
    }

    void Update()
    {
        txt.text = "" + AbilitiesController.Instance.health;
    }
}
