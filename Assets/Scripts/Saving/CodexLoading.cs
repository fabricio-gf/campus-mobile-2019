using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexLoading : MonoBehaviour
{
    private CodexController codexController;

    private void Awake()
    {
        codexController = GetComponent<CodexController>();
    }

    private void Start()
    {
        CodexDataManager.LoadCodex();
    }

    public void LoadData()
    {
        codexController.GoToIndex();
    }    

    public void OnEnable()
    {
        SaveData.OnCodexLoaded += LoadData;
    }

    public void OnDisable()
    {
        SaveData.OnCodexLoaded -= LoadData;
    }
}
