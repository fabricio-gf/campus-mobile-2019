using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWithDelay : MonoBehaviour
{
    [SerializeField] private string DialogueName = null;
    [SerializeField] private GameObject DialogueTrigger = null;
    [SerializeField] private float DialogueDelay = 0;

    [SerializeField] private int ProgressLimit = 0;

    private static string dataPath = string.Empty;

    private void Awake()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SaveData.CheckProgress(dataPath) <= ProgressLimit)
        {
            StartCoroutine(StartDelay());
        }
        else
        {
            Destroy(DialogueTrigger.gameObject);
            Destroy(this);
        }
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(DialogueDelay);
        DialogueTrigger.SetActive(true);
        ProgressDataManager.SetProgress(ProgressLimit+1);
    }
}
