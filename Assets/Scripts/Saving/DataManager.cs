using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    protected static string dataPath = string.Empty;

    void Awake()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    public void Save()
    {
        SaveData.Save(dataPath, SaveData.gameData);
    }
}
