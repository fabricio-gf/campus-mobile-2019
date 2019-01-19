using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexDataManager : DataManager
{
    //public const string playerPath = "Prefabs/Player";
    [SerializeField] private static Codex codex;

    private void Start()
    {
        LoadCodex();
    }

    public static void SetCodex(int chapters)
    {
        codex.UnlockedChapters = chapters;
    }

    public static void LoadCodex()
    {
        SaveData.LoadCodex(dataPath);
    }
}
