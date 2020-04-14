using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
    public bool musicOn;

    public SettingsData(SettingsController controller)
    {
        musicOn = controller.musicOn;
    }
}
