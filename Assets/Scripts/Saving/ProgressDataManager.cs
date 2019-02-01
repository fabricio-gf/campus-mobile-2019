using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressDataManager : DataManager
{
    //public const string playerPath = "Prefabs/Player";
    public static int CurrentProgress;
    public static int CurrentChallengeProgress;

    private void Start()
    {
        LoadProgress();
    }

    public static void SetProgress(int progress)
    {
        //Debug.Log("current progress is " + CurrentProgress);
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
        //Debug.Log("new progress is " + CurrentProgress);
    }

    public static void SetChallengeProgress(int progress)
    {
        //Debug.Log("current challenge progress is " + CurrentChallengeProgress);
        CurrentChallengeProgress = progress;
        //Debug.Log("new challenge progress is " + CurrentChallengeProgress);
    }

    public void LoadProgress()
    {
        SaveData.LoadProgress(dataPath);
    }
}
