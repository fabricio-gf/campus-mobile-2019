using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPath: MonoBehaviour
{
    public static DataPath instance = null;
    public static string Path = string.Empty;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        Path = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
    }
}
