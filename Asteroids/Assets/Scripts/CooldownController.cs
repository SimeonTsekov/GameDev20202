using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
    Image filling;
    float time;

    void Start()
    {
        filling = this.GetComponent<Image>();
        filling.fillAmount = 0;
        time = 0.0f;
    }

    void Update()
    {
        if (AbilitiesController.Instance.cooldown > 0)
        {
            time -= Time.deltaTime;
            filling.fillAmount = time / 10;
        }
        else
        {
            filling.fillAmount = 0;
            time = 10;
        }
    }
}
