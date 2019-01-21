using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSave : MonoBehaviour
{
    protected static string dataPath = string.Empty;

    private void Start()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    public void ResetSaveData()
    {
        SaveData.ResetSave(dataPath);
    }
}
