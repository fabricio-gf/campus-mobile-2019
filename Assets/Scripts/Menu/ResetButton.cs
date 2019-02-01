using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    private ResetSave reset = null;

    public void ResetSave()
    {
        reset.ResetSaveData();
    }
}
