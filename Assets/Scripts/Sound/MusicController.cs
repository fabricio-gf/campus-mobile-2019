using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    // PUBLIC REFERENCES
    [Header("References")]
    public AudioClip MusicTrack;
    public float LoopDuration;

    // PRIVATE REFERENCES
    [SerializeField] private Transform SourceReference = null;
    [SerializeField] private float FadeDuration = 0;
    [SerializeField] private float BlendDuration = 0;

    // PRIVATE ATTRIBUTES
    private AudioSource Source1 = null;
    private AudioSource Source2 = null;
    private int CurrentSource = 1;
    private bool IsFading = false;
    private bool IsBlending = false;

    private static string SourceTag = "MusicSource";
    private static string PrefsString = "MusicMute";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GameObject obj = GameObject.FindGameObjectWithTag(SourceTag);
        if(obj)
        {
            Destroy(SourceReference.gameObject);
            SourceReference = obj.transform;
        }
        else
        {
            DontDestroyOnLoad(SourceReference.gameObject);
            SourceReference.tag = SourceTag;
        }
        Source1 = SourceReference.GetChild(0).GetComponent<AudioSource>();
        Source2 = SourceReference.GetChild(1).GetComponent<AudioSource>();
    }

    private void Start()
    {
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
