using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaving : MonoBehaviour
{
    public GameData data;

    public void StoreData()
    {
        data.PlayerPos = transform.position;
    }

    public void LoadData()
    {
        transform.position = data.PlayerPos;
    }

    public void ApplyData()
    {
        SaveData.AddPlayerData(data.PlayerPos);
    }

    public void OnEnable()
    {
        SaveData.OnPlayerLoaded += LoadData;
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }

    public void OnDisable()
    {
        SaveData.OnPlayerLoaded -= LoadData;
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave -= ApplyData;
    }
}
