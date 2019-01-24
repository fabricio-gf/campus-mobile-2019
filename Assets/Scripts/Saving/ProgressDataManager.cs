using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressDataManager : DataManager
{
    //public const string playerPath = "Prefabs/Player";
    public static int CurrentProgress;

    private void Start()
    {
        LoadProgress();
    }

    public static void SetProgress(int progress)
    {
        Debug.Log("current progress is " + CurrentProgress);
        switch (progress)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
        CurrentProgress = progress;
        Debug.Log("new progress is " + CurrentProgress);
    }

    public void LoadProgress()
    {
        SaveData.LoadProgress(dataPath);
    }
}
