using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWithActivation : MonoBehaviour
{
    [SerializeField] private string DialogueName = null;
    [SerializeField] private GameObject DialogueTrigger = null;

    [SerializeField] private int ProgressLimit = 0;

    private static string dataPath = string.Empty;

    private void Awake()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    void Start()
    {
        if (SaveData.CheckProgress(dataPath) > ProgressLimit)
        {
            Destroy(DialogueTrigger.gameObject);
            Destroy(this);
        }
    }

    public void ActivateDialogue()
    {
        DialogueTrigger.SetActive(true);
        Debug.Log("Up progress ", gameObject);
        ProgressDataManager.SetProgress(ProgressLimit + 1);
    }
}
