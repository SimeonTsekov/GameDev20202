using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesterTextController : MonoBehaviour
{
    Text txt;

    void Start()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        if (SettingsController.Instance.testerOn)
        {
            txt.text = "Tester Mode On";
        }
        else
        {
            txt.text = "Tester Mode Off";
        }
    }
}
