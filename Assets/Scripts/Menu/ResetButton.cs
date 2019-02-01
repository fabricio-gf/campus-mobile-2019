using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    private ResetSave reset = null;

    private void Awake()
    {
        reset = GameObject.FindGameObjectWithTag("ResetSave").GetComponent<ResetSave>();
    }

    public void ResetSave()
    {
        reset.ResetSaveData();
    }
}
