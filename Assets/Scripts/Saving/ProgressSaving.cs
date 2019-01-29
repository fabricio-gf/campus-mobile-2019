using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressSaving : MonoBehaviour
{
    public GameData data;

    public void StoreData()
    {
        data.Progress = ProgressDataManager.CurrentProgress;
        data.ChallengeProgress = ProgressDataManager.CurrentChallengeProgress;
    }

    public void LoadData()
    {
        ProgressDataManager.CurrentProgress = data.Progress;
        ProgressDataManager.CurrentChallengeProgress = data.ChallengeProgress;
    }

    public void ApplyData()
    {
        SaveData.AddProgressData(data.Progress, data.ChallengeProgress);
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
