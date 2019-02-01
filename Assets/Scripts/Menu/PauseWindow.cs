using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : MonoBehaviour
{
    private Animator animator = null;
    [SerializeField] private Toggle MusicToggle = null;
    [SerializeField] private Toggle SFXToggle = null;
    [SerializeField] private Toggle HandToggle = null;

    private static string PrefsMusicString = "MusicMute";
    private static string PrefsSFXString = "SFXMute";

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenPauseWindow()
    {
        animator.SetTrigger("OpenWindow");
        if (PlayerPrefs.GetInt(PrefsMusicString) == 1)
        {
            MusicToggle.isOn = true;
        }
        if (PlayerPrefs.GetInt(PrefsSFXString) == 1)
        {
            SFXToggle.isOn = true;
        }
    }

    public void ClosePauseWindow()
    {
        animator.SetTrigger("CloseWindow");
    }
}
