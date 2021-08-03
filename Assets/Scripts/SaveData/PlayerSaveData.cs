using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerSaveData
{
    public int record;
    public int money;

    public PlayerSaveData(PlayerManager player)
    {
        record = player.updateRecord;
        money = player.updateMoney;
    }
}
