using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSave : MonoBehaviour
{
    public static ResetSave instance = null;
    protected static string dataPath = string.Empty;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    public void ResetSaveData()
    {
        SaveData.ResetSave(dataPath);
        ProgressDataManager.SetProgress(SaveData.gameData.Progress);
    }
}
