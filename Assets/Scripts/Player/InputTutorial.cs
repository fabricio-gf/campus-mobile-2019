﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTutorial : MonoBehaviour
{

    [SerializeField] private int ProgressLimit = 0;
    private static string dataPath = string.Empty;

    void Start()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
        if (ProgressLimit > SaveData.CheckProgress(dataPath))
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
        Debug.Log("Up progress ", gameObject);
        ProgressDataManager.SetProgress(ProgressLimit+1);
    }
}
