using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLabelController : MonoBehaviour
{
    Text txt;

    void Start()
    {
        txt = GetComponent<Text>();
        txt.text += GameStateController.Instance.Level;
    }

    void Update()
    {
        txt.text = "Next level: " + GameStateController.Instance.Level;
    }
}