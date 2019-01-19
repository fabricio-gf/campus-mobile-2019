using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexSaving : MonoBehaviour
{
    public GameData data;
    private CodexController codexController;

    public void StoreData()
    {
        data.Chapters = codexController.codex.UnlockedChapters;
    }

    public void LoadData()
    {
        codexController.GoToIndex();
    }

    public void ApplyData()
    {
        SaveData.AddCodexData(data.Chapters);
    }

    public void OnEnable()
    {
        SaveData.OnCodexLoaded += LoadData;
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }

    public void OnDisable()
    {
        SaveData.OnCodexLoaded -= LoadData;
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave -= ApplyData;
    }
}
