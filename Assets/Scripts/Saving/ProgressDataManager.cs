using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressDataManager : DataManager
{
    //public const string playerPath = "Prefabs/Player";

    private void Start()
    {
        LoadProgress();
    }

    public static void SetProgress(int progress)
    {
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
    }

    public void LoadProgress()
    {
    }
}
