using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTextController : MonoBehaviour
{
    Text txt;

    void Start()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        if (SettingsController.Instance.soundOn)
        {
            txt.text = "Sound On";
        }
        else
        {
            txt.text = "Sound Off";
        }
    }
}
