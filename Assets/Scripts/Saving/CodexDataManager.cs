﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexDataManager : DataManager
{
    //public const string playerPath = "Prefabs/Player";
    [SerializeField] private Codex codexReference;
    public static Codex codex;

    private void Start()
    {
        codex = codexReference;
    }

    public static void SetCodex(int chapters)
    {
        codex.UnlockedChapters = chapters;
    }

    public static void LoadCodex()
    {
        SaveData.LoadCodex(dataPath);
    }

    public void IncrementChapter()
    {
        codex.UnlockedChapters++;
        print("CODEX INCREMENTED " + codex.UnlockedChapters);
        Save();
    }
}
