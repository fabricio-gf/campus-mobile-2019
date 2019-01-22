using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public static AudioSource Source = null;

    // PUBLIC REFERENCES
    [Header("References")]
    

    // PRIVATE REFERENCES
    //[SerializeField]

    // PRIVATE ATTRIBUTES
    private Dictionary<string, AudioClip> Clips = null;
    [SerializeField] private AudioSource SourceReference = null;

    [HideInInspector] public static string SourceTag = "SFXSource";
    private static string PrefsString = "SFXMute";

    void Awake()
    {
        if(Source == null)
        {
            Source = SourceReference;
            DontDestroyOnLoad(Source.gameObject);
        }
        else if(Source != SourceReference)
        {
            Destroy(SourceReference.gameObject);
        }
        
        Clips = new Dictionary<string, AudioClip>();
        FillClips();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(PrefsString, 0) == 1)
        {
            Source.mute = true;
        }
    }

    void FillClips()
    {
        // fill dictionary here
    }

    void PlayClip(string key)
    {
        AudioClip clip;
        if(Clips.TryGetValue(key, out clip))
        {
            Source.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("No clip found! Try another name");
        }
    }

    public void ToggleMuteSFX(bool mute)
    {
        Source.mute = mute;
        PlayerPrefs.SetInt(PrefsString, mute ? 1 : 0);
    }
}
