using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingButton : MonoBehaviour
{
    [SerializeField] private bool LoadPreviousLevel = false;
    [SerializeField] private string SceneToLoad = "";
    private Button ThisButton = null;
    private LevelLoader Loader = null;

    private void Awake()
    {
        ThisButton = GetComponent<Button>();
        Loader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
        if (Loader != null)
        {
            if(!LoadPreviousLevel) ThisButton.onClick.AddListener(() => Loader.LoadLevel(SceneToLoad));
            else ThisButton.onClick.AddListener(() => Loader.LoadPreviousScene());
        }
    }
}
