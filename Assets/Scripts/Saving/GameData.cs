using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public Vector2 PlayerPos;

    public int Progress;

    public int DictionaryProgress;

    public int Chapters;
    //public int[] Pages;

    //public GameData(Vector2 playerPosition, int progress, int dictionaryProgress, int chapters, int[] pages)
    public GameData(Vector2 playerPosition, int progress, int dictionaryProgress, int chapters)
    {
        PlayerPos = playerPosition;
        Progress = progress;
        DictionaryProgress = progress;
        Chapters = chapters;
        //Pages = pages;
    }
}
