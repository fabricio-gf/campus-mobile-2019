using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    // PUBLIC REFERENCES
    [Header("References")]
    public AudioClip MusicTrack;

    // PRIVATE REFERENCES
    [SerializeField] private Transform SourceReference;
    [SerializeField] private float FadeDuration;
    [SerializeField] private float BlendDuration;

    // PRIVATE ATTRIBUTES
    private AudioSource Source1;
    private AudioSource Source2;
    private int CurrentSource = 1;
    private bool IsFading = false;
    private bool IsBlending = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Source1 = SourceReference.GetChild(0).GetComponent<AudioSource>();
        Source2 = SourceReference.GetChild(1).GetComponent<AudioSource>();
    }

    private void Start()
    {
        Source1.clip = MusicTrack;
        Source1.Play();
    }

    public void ChangeTrackInstantly(AudioClip newTrack)
    {
        if (CurrentSource == 1)
        {
            Source1.clip = newTrack;
        }
        else if (CurrentSource == 2)
        {
            Source2.clip = newTrack;
        }
    }

    public void ChangeTrackBlend(AudioClip newTrack, float BlendDuration)
    {
        if (!IsBlending)
        {
            if (CurrentSource == 1)
            {
                Source2.clip = newTrack;
                Source2.Play();
                StartCoroutine(BlendTracks(Source1, Source2));
                CurrentSource = 2;
            }
            else if (CurrentSource == 2)
            {
                Source1.clip = newTrack;
                Source1.Play();
                StartCoroutine(BlendTracks(Source2, Source1));
                CurrentSource = 1;
            }
        }
    }

    // VOLUME MANIPULATION METHODS

    public void ToggleMuteMusic(bool mute)
    {
        Source1.mute = mute;
        Source2.mute = mute;
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
}
