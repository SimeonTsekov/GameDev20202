using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RapidFireButtonController : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (GameStateController.Instance.multishotUpgrades[0])
        {
            button.interactable = false;
        }
    }
}
