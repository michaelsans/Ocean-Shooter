using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerSaveData
{
    public int record;
    public int money;
    public bool[] itemPurchased;
    public PlayerSaveData(PlayerManager player)
    {
        record = player.updateRecord;
        money = player.updateMoney;
        itemPurchased = new bool[10];
        for (int i = 0; i < 10; i++)
        {
            itemPurchased[i] = player.updateItemPurchased[i];
            Debug.Log(itemPurchased[i]);
        }
    }
}
