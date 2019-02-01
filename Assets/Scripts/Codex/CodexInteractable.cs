using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CodexInteractable : Interactable
{
    private DialogueTrigger dialogue;
    [SerializeField] private CodexDataManager dataManager = null;
    [SerializeField] private int UnlockedChapter = 0;

    [SerializeField] private int ProgressLimit = 0;

    void Awake()
    {
        dialogue = GetComponent<DialogueTrigger>();
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    private void Start()
    {
        if (SaveData.CheckProgress(dataPath) > ProgressLimit)
        {
            Destroy(gameObject);
        }
    }

    public override void Interact()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        dialogue.TriggerDialogue();
        CodexDataManager.SetCodex(UnlockedChapter);
        Debug.Log("Up progress ", gameObject);
        ProgressDataManager.SetProgress(ProgressLimit + 1);
    }


    public void OpenCodex()
    {

    }

}
