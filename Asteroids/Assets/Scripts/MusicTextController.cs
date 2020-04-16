using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicTextController : MonoBehaviour
{
    Text txt;
    
    void Start()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        if (SettingsController.Instance.musicOn)
        {
            txt.text = "Music On";
        }
        else
        {
            txt.text = "Music Off";
        }
    }
}
