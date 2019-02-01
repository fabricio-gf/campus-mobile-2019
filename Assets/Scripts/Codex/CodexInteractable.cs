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
    [SerializeField] private bool SavePoint = false;

    void Awake()
    {
        dialogue = GetComponent<DialogueTrigger>();
    }

    private void Start()
    {
        //if (SaveData.CheckProgress(dataPath) > ProgressLimit)
        Debug.Log("Current Progress at " + name + ": " + ProgressDataManager.CurrentProgress);
        Debug.Log("Progress limit at " + name + ": " + ProgressLimit);
        if (ProgressDataManager.CurrentProgress > ProgressLimit)
        {
            Debug.Log("Is being destroyed");

            Destroy(gameObject);
        }
    }

    public override void Interact()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        dialogue.TriggerDialogue();
        CodexDataManager.SetCodex(UnlockedChapter);
        ProgressDataManager.SetProgress(ProgressLimit + 1);
        if (SavePoint) SaveData.Save(DataPath.Path, SaveData.gameData);
        SaveData.Save(DataPath.Path, SaveData.gameData);
    }


    public void OpenCodex()
    {

    }

}
