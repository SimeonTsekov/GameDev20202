using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public uint playerOre;
    public uint level;

    public PlayerData(GameStateController controller)
    {
        playerOre = controller.PlayerOre;
        level = controller.Level;
    }
}
