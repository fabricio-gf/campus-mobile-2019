using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingButton : MonoBehaviour
{
    [SerializeField] private bool LoadPreviousLevel = false;
    [SerializeField] private bool LoadCodexScene = false;
    [SerializeField] private bool LoadNewGame = false;
    [SerializeField] private string SceneToLoad = "";
    private Button ThisButton = null;
    private LevelLoader Loader = null;

    private void Awake()
    {
        ThisButton = GetComponent<Button>();
        Loader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
        if (Loader != null)
        {
            if(LoadPreviousLevel) ThisButton.onClick.AddListener(() => Loader.LoadPreviousScene());
            else if(LoadCodexScene) ThisButton.onClick.AddListener(() => Loader.LoadCodexScene(SceneToLoad));
            else ThisButton.onClick.AddListener(() => Loader.LoadLevel(SceneToLoad));
            if(LoadNewGame) ThisButton.onClick.AddListener(() => GameObject.FindGameObjectWithTag("ResetSave").GetComponent<ResetSave>().ResetSaveData());
        }
    }
}
