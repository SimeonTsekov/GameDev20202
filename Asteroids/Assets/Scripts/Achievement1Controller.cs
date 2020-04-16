using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement1Controller : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        if (GameStateController.Instance.Level <= 11)
        {
            slider.value = GameStateController.Instance.Level - 1;
        }
        else
        {
            slider.value = 10;
        }
    }
}
