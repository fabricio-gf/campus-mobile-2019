using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressSaving : MonoBehaviour
{
    public GameData data;
    private CodexController codexController;

    public void StoreData()
    {
        //data.Progress = ;
    }

    public void LoadData()
    {
        //codexController.GoToIndex();
    }

    public void ApplyData()
    {
        SaveData.AddCodexData(data.Progress);
    }

    public void OnEnable()
    {
        SaveData.OnProgressLoaded += LoadData;
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }

    public void OnDisable()
    {
        SaveData.OnProgressLoaded -= LoadData;
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave -= ApplyData;
    }
}
