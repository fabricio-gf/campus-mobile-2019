using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    // PUBLIC REFERENCES
    [Header("References")]
    

    // PRIVATE REFERENCES
    [SerializeField] private AudioSource Source = null;

    // PRIVATE ATTRIBUTES
    private Dictionary<string, AudioClip> Clips = null;

    private static string SourceTag = "SFXSource";
    private static string PrefsString = "SFXMute";

    void Awake()
    {
        GameObject obj = GameObject.FindGameObjectWithTag(SourceTag);
        if (obj)
        {
            Destroy(Source.gameObject);
            Source = obj.GetComponent<AudioSource>();
        }
        else
        {
            DontDestroyOnLoad(Source.gameObject);
            Source.tag = SourceTag;
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
