using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public uint playerOre;

    public PlayerData(GameStateController controller)
    {
        playerOre = controller.PlayerOre;
    }
}
