using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
    public bool musicOn;
    public bool soundOn;

    public SettingsData(SettingsController controller)
    {
        musicOn = controller.musicOn;
        soundOn = controller.soundOn;
    }
}
