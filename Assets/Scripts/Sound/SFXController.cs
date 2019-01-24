using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SFXController : MonoBehaviour
{
    public static AudioSource Source = null;

    // PUBLIC REFERENCES

    [Header("References")]
    [SerializeField] private GameObject SourcePrefab = null;
    private Toggle SFXMuteToggle = null;

    // PRIVATE REFERENCES
    //[SerializeField]

    // PRIVATE ATTRIBUTES
    private Dictionary<string, AudioClip> Clips = null;

    [HideInInspector] public static string SourceTag = "SFXSource";
    private static string PrefsString = "SFXMute";

    void Awake()
    {
        Clips = new Dictionary<string, AudioClip>();
        FillClips();
        SceneManager.sceneLoaded += AddListenerToMuteButton;
    }

    private void Start()
    {
        if (Source == null)
        {
            GameObject obj = Instantiate(SourcePrefab, new Vector3(0,0,-10), Quaternion.identity);
            Source = obj.GetComponent<AudioSource>();

            DontDestroyOnLoad(obj);

        }

        if (PlayerPrefs.GetInt(PrefsString, 0) == 1)
        {
            Source.mute = true;
        }
    }

    void AddListenerToMuteButton(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MenuFinal")
        {
            //print(GameObject.Find("SFXMuteToggle").name);
            //SFXMuteToggle = GameObject.FindGameObjectWithTag("SFXMuteToggle").GetComponent<Toggle>();
            SFXMuteToggle = Resources.FindObjectsOfTypeAll<Toggle>()[1];
            SFXMuteToggle.onValueChanged.AddListener((bool mute) => ToggleMuteSFX(mute));
        }
    }

    public void Test()
    {
        Debug.Log("TESTING");
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
