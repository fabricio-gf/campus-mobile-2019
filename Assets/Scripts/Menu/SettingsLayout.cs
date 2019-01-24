using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsLayout : MonoBehaviour
{
    [SerializeField] private Toggle MuteMusicToggle = null;
    [SerializeField] private Toggle MuteSFXToggle = null;

    private static string PrefsMusicString = "MusicMute";
    private static string PrefsSFXString = "SFXMute";


    // Start is called before the first frame update
    void OnEnable()
    {
        UpdateSettings();
    }

    void UpdateSettings()
    {
        if (PlayerPrefs.GetInt(PrefsMusicString) == 1)
        {
            MuteMusicToggle.isOn = true;
        }
        if(PlayerPrefs.GetInt(PrefsSFXString) == 1)
        {
            MuteSFXToggle.isOn = true;
        }
    }
}
