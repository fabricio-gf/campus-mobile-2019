using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    // PUBLIC REFERENCES
    [Header("References")]
    

    // PRIVATE REFERENCES
    [SerializeField] private AudioSource Source;

    // PRIVATE ATTRIBUTES
    private Dictionary<string, AudioClip> Clips;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Clips = new Dictionary<string, AudioClip>();
        FillClips();
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
    }
}
