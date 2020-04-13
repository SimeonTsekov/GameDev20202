﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public uint playerOre;
    public uint level;
    public bool[] shieldUpgrades;
    public bool[] blastwaveUpgrades;
    public bool[] multishotUpgrades;

    public PlayerData(GameStateController controller)
    {
        playerOre = controller.PlayerOre;
        level = controller.Level;
        shieldUpgrades = controller.shieldUpgrades;
        blastwaveUpgrades = controller.blastwaveUpgrades;
        multishotUpgrades = controller.multishotUpgrades;
    }
}
