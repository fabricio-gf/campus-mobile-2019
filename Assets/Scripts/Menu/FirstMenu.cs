using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMenu : MonoBehaviour
{
    [SerializeField] private int ProgressLimit = 0;
    [SerializeField] private LevelLoader loader = null;

    // Start is called before the first frame update
    void Start()
    {
        //dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");

        //if (SaveData.CheckProgress(dataPath) > ProgressLimit)
        if (ProgressDataManager.CurrentProgress > ProgressLimit)
        {
            
            loader.LoadLevelNow("MenuFinal");
        }
        else
        {
            //do something
            ProgressDataManager.SetProgress(ProgressLimit + 1);
        }
    }

}
