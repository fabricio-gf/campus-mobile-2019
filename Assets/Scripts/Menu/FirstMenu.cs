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
        //SaveData.Save(dataPath, SaveData.gameData);

        if (SaveData.CheckProgress(dataPath) > ProgressLimit)
        {
            
            loader.LoadLevelNow("MenuFinal");
        }
        else
        {
            //do something
            //Debug.Log("Up progress ", gameObject);
            //SaveData.AddProgressData(ProgressLimit+1, SaveData.gameData.ChallengeProgress);
            //SaveData.Save(dataPath, SaveData.gameData);
        }
    }

}
