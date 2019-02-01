using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTutorial : MonoBehaviour
{
    [SerializeField] private int ProgressLimit = 0;
    [SerializeField] private bool SavePoint = false;
    private static string dataPath = string.Empty;

    void Start()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
        //if (SaveData.CheckProgress(dataPath) > ProgressLimit)
        if (ProgressDataManager.CurrentProgress > ProgressLimit)
        {
            Destroy(gameObject);
        }
        else
        {
            //StartCoroutine(StartDelay());
        }
    }

    public void CloseTutorial()
    {
        //temp
        gameObject.SetActive(false);
        //set animation to close
        //Debug.Log("Up progress ", gameObject);
        //ProgressDataManager.SetProgress(ProgressLimit + 1);
        if (SavePoint) SaveData.Save(DataPath.Path, SaveData.gameData);
    }
}
