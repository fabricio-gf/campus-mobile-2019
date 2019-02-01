using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTutorial : MonoBehaviour
{

    [SerializeField] private int ProgressLimit = 0;
    [SerializeField] private bool SavePoint = false;

    void Start()
    {
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
        ProgressDataManager.SetProgress(ProgressLimit + 1);
        if (SavePoint) SaveData.Save(DataPath.Path, SaveData.gameData);

        //temp
        gameObject.SetActive(false);
        //set animation to close

    }
}
