using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMenu : MonoBehaviour
{
    protected static string dataPath = string.Empty;
    [SerializeField] private int ProgressLimit = 0;
    [SerializeField] private LevelLoader loader = null;

    // Start is called before the first frame update
    void Start()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
        print("progress" + SaveData.CheckProgress(dataPath));
        if (SaveData.CheckProgress(dataPath) > ProgressLimit)
        {
            
            loader.LoadLevelNow("MenuFinal");
        }
        else
        {
            //do something
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
