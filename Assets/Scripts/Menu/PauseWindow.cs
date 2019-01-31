using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    private GameObject Window = null;
    private GameObject PauseButton = null;

    public void Awake()
    {
        PauseButton = transform.GetChild(0).gameObject;
        Window = transform.GetChild(1).gameObject;
    }

    public void OpenPauseWindow()
    {
        //animation
        PauseButton.SetActive(false);
        Window.SetActive(true);
    }

    public void ClosePauseWindow()
    {
        PauseButton.SetActive(true);
        Window.SetActive(false);
    }
}
