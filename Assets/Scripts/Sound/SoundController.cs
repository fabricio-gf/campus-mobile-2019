using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    /*public void MuteMusic(bool mute)
    {
        GetComponent<MusicController>().ToggleMuteMusic(mute);
    }

    public void MuteSFX(bool mute)
    {
        GetComponent<SFXController>().ToggleMuteSFX(mute);
    }*/
}
