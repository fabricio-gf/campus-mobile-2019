using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CodexInteractable : Interactable
{
    private DialogueTrigger dialogue;
    [SerializeField] private CodexDataManager dataManager;

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
        dataManager.IncrementChapter();
        //increment progress?

    }


    public void OpenCodex()
    {

    }

}
