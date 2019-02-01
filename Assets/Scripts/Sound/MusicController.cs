﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public static AudioSource Source1 = null;
    public static AudioSource Source2 = null;

    // PUBLIC REFERENCES

    [Header("References")]
    public AudioClip MusicTrack;
    public float LoopDuration;


    // PRIVATE REFERENCES
    [SerializeField] private GameObject SourcePrefab = null;
    private Toggle MusicMuteToggle = null;

    // PRIVATE ATTRIBUTES
    [SerializeField] private float FadeDuration = 0;
    [SerializeField] private float BlendDuration = 0;
    private int CurrentSource = 1;
    private bool IsFading = false;
    private bool IsBlending = false;

    [HideInInspector] public static string SourceTag = "MusicSource";
    private static string PrefsString = "MusicMute";

    void Awake()
    {
        SceneManager.sceneLoaded += AddListenerToMuteButton;
    }

    private void Start()
    {
        if (Source1 == null && Source2 == null)
        {
            GameObject obj = Instantiate(SourcePrefab, new Vector3(0, 0, -10), Quaternion.identity);
            Source1 = obj.transform.GetChild(0).GetComponent<AudioSource>();
            Source2 = obj.transform.GetChild(1).GetComponent<AudioSource>();

            DontDestroyOnLoad(obj);
        }

        Source1.clip = MusicTrack;
        if (!Source1.isPlaying)
        {
            Source1.Play();
            StartCoroutine(LoopTrackAtTime(MusicTrack, Source1, Source2, LoopDuration));
        }

        if (PlayerPrefs.GetInt(PrefsString, 0) == 1)
        {
            Source1.mute = true;
            Source2.mute = true;
        }
    }

    void AddListenerToMuteButton(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameFinal")
        {
            //MusicMuteToggle = GameObject.FindGameObjectWithTag("MusicMuteToggle").GetComponent<Toggle>();
            //System.GC.Collect();
            //System.GC.WaitForPendingFinalizers();
            MusicMuteToggle = Resources.FindObjectsOfTypeAll<Toggle>()[1];
            MusicMuteToggle.onValueChanged.AddListener((bool mute) => ToggleMuteMusic(mute));

        }
        else if(scene.name == "MenuFinal")
        {
            //System.GC.Collect();
            //System.GC.WaitForPendingFinalizers();
            MusicMuteToggle = Resources.FindObjectsOfTypeAll<Toggle>()[1];
            MusicMuteToggle.onValueChanged.AddListener((bool mute) => ToggleMuteMusic(mute));

        }
    }

    public void ChangeTrackInstantly(AudioClip newTrack, float loopTime)
    {
        if (CurrentSource == 1)
        {
            StopAllCoroutines();
            Source1.clip = newTrack;
            Source1.Play();
            StartCoroutine(LoopTrackAtTime(newTrack, Source2, Source1, loopTime));
        }
        else if (CurrentSource == 2)
        {
            StopAllCoroutines();
            Source2.clip = newTrack;
            Source2.Play();
            StartCoroutine(LoopTrackAtTime(newTrack, Source1, Source2, loopTime));
        }
    }

    public void ChangeTrackBlend(AudioClip newTrack, float loopTime, float BlendDuration)
    {
        if (!IsBlending)
        {
            if (CurrentSource == 1)
            {
                StopAllCoroutines();
                Source2.clip = newTrack;
                Source2.Play();
                StartCoroutine(BlendTracks(Source1, Source2));
                StartCoroutine(LoopTrackAtTime(newTrack, Source1, Source2, loopTime));
                CurrentSource = 2;
            }
            else if (CurrentSource == 2)
            {
                StopAllCoroutines();
                Source1.clip = newTrack;
                Source1.Play();
                StartCoroutine(BlendTracks(Source2, Source1));
                StartCoroutine(LoopTrackAtTime(newTrack, Source2, Source1, loopTime));
                CurrentSource = 1;
            }
        }
    }

    // VOLUME MANIPULATION METHODS

    public void ToggleMuteMusic(bool mute)
    {
        Source1.mute = mute;
        Source2.mute = mute;
        PlayerPrefs.SetInt(PrefsString, mute ? 1 : 0);
    }
   
    IEnumerator FadeOutTrack(AudioSource Source)
    {
        IsFading = true;
        float time = 0;
        while (time <= FadeDuration)
        {
            Source.volume = 1 - (time / FadeDuration);
            time += Time.deltaTime;
            yield return null;
        }
        Source.Stop();
        IsFading = false;
    }

    IEnumerator FadeInTrack(AudioSource Source)
    {
        IsFading = true;
        Source.Play();
        float time = 0;
        while (time <= FadeDuration)
        {
            Source.volume = time / FadeDuration;
            time += Time.deltaTime;
            yield return null;
        }
        IsFading = false;
    }

    IEnumerator BlendTracks(AudioSource FadeOutSource, AudioSource FadeInSource)
    {
        IsBlending = true;
        float time = 0;
        while (time <= BlendDuration)
        {
            FadeOutSource.volume = 1 - (time / BlendDuration);
            FadeInSource.volume = time / BlendDuration;
            time += Time.deltaTime;
            yield return null;
        }
        FadeOutSource.Stop();
        IsBlending = false;
    }

    IEnumerator LoopTrackAtTime(AudioClip clip, AudioSource currentSource, AudioSource newSource, float time)
    {
        yield return new WaitForSeconds(time);
        newSource.clip = clip;
        newSource.Play();
        StartCoroutine(LoopTrackAtTime(clip, newSource, currentSource, time));
    }
}
