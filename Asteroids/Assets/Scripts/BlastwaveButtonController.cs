using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlastwaveButtonController : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (GameStateController.Instance.blastwaveTier == 3)
        {
            button.interactable = false;
        }
    }
}
