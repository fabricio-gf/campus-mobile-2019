using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameData data = new GameData();

    public void StoreData()
    {
        data.playerPos = transform.position;
    }

    public void LoadData()
    {
        transform.position = data.playerPos;
    }

    public void ApplyData()
    {
        SaveData.AddPlayerData(data.playerPos);
    }

    public void OnEnable()
    {
        SaveData.OnLoaded += LoadData;
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }

    public void OnDisable()
    {
        SaveData.OnLoaded -= LoadData;
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave -= ApplyData;
    }
}
