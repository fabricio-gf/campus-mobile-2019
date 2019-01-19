using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexSaving : MonoBehaviour
{

    public GameData data;
    private CodexController codexController;

    private void Awake()
    {
        codexController = GetComponent<CodexController>();
    }

    public void StoreData()
    {
        data.Chapters = CodexDataManager.codex.UnlockedChapters;
    }

    public void ApplyData()
    {
        SaveData.AddCodexData(data.Chapters);
    }

    public void OnEnable()
    {
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }

    public void OnDisable()
    {
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave -= ApplyData;
    }
}
