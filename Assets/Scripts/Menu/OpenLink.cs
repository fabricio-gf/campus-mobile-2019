using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public void OpenExternalLink(string url)
    {
        SaveData.Save(DataPath.Path, SaveData.gameData);
        Application.OpenURL(url);
    }
}
