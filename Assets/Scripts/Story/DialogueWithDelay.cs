using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWithDelay : MonoBehaviour
{
    [SerializeField] private string DialogueName = null;
    [SerializeField] private GameObject DialogueTrigger = null;
    [SerializeField] private float DialogueDelay = 0;

    [SerializeField] private int ProgressLimit = 0;
    [SerializeField] private bool SavePoint = false;

    private static string dataPath = string.Empty;

    private void Awake()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    // Start is called before the first frame update
    void Start()
    {
        //if (SaveData.CheckProgress(dataPath) > ProgressLimit)
        Debug.Log("Current Progress at " + name + ": " + ProgressDataManager.CurrentProgress);
        Debug.Log("Progress limit at " + name + ": " + ProgressLimit);
        if (ProgressDataManager.CurrentProgress > ProgressLimit)
        {
            Debug.Log("Is being destroyed");
            Destroy(DialogueTrigger.gameObject);
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(StartDelay());
        }
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(DialogueDelay);
        DialogueTrigger.SetActive(true);
    }

    public void AddProgress()
    {
        ProgressDataManager.SetProgress(ProgressLimit + 1);
        if (SavePoint) SaveData.Save(DataPath.Path, SaveData.gameData);
    }
}
