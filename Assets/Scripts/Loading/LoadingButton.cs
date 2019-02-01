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

    [SerializeField] private bool ChangeTrackOnLoad = false;
    [SerializeField] private AudioClip NewTrack = null;
    [SerializeField] private float TrackLoop = 0;

    private Button ThisButton = null;
    private LevelLoader Loader = null;
    private MusicController Music = null;

    private void Awake()
    {
        ThisButton = GetComponent<Button>();
        Loader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
        Music = GameObject.FindGameObjectWithTag("SoundSource").GetComponent<MusicController>();

        if (Loader != null)
        {
            if (LoadPreviousLevel)
            {
                ThisButton.onClick.AddListener(() => Loader.LoadPreviousScene());
                if (Music && ChangeTrackOnLoad)
                {
                    ThisButton.onClick.AddListener(() => Music.ChangeTrackBlend(LoadingInfo.PreviousTrack, LoadingInfo.PreviousLoopTime, 1f));
                }
            }
            else if (LoadCodexScene)
            {
                ThisButton.onClick.AddListener(() => Loader.LoadCodexScene(SceneToLoad));
                LoadingInfo.PreviousTrack = NewTrack;
                LoadingInfo.PreviousLoopTime = TrackLoop;

                if (Music && ChangeTrackOnLoad)
                {
                    ThisButton.onClick.AddListener(() => Music.ChangeTrackBlend(NewTrack, TrackLoop, 1f));
                }
            }
            else
            {
                ThisButton.onClick.AddListener(() => Loader.LoadLevel(SceneToLoad));
                if (Music && ChangeTrackOnLoad)
                {
                    ThisButton.onClick.AddListener(() => Music.ChangeTrackBlend(NewTrack, TrackLoop, 1f));
                }
            }

            if (LoadNewGame)
            {
                ThisButton.onClick.AddListener(() => GameObject.FindGameObjectWithTag("ResetSave").GetComponent<ResetSave>().ResetSaveData());
            }
        }
    }
}
