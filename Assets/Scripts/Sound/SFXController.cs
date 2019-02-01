using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SFXController : MonoBehaviour
{
    public static AudioSource Source = null;

    // PUBLIC REFERENCES

    // PRIVATE REFERENCES
    [Header("References")]
    [SerializeField] private GameObject SourcePrefab = null;

    [Header("Clips")]
    [SerializeField] private AudioClip ClickClip = null;
    [SerializeField] private AudioClip SwipeClip = null;
    //[SerializeField] private AudioClip WooshClip = null;
    [SerializeField] private AudioClip RightClip = null;
    [SerializeField] private AudioClip WrongClip = null;
    [SerializeField] private AudioClip PageClip = null;

    private Toggle SFXMuteToggle = null;

    // PRIVATE ATTRIBUTES
    private Dictionary<string, AudioClip> Clips = null;

    private static string SourceTag = "SFXSource";
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

            //System.GC.Collect();
            //System.GC.WaitForPendingFinalizers();
            SFXMuteToggle = Resources.FindObjectsOfTypeAll<Toggle>()[0];
            SFXMuteToggle.onValueChanged.AddListener((bool mute) => ToggleMuteSFX(mute));

        }
        else if (scene.name == "GameFinal")
        {

            //System.GC.Collect();
            //System.GC.WaitForPendingFinalizers();
            SFXMuteToggle = Resources.FindObjectsOfTypeAll<Toggle>()[2];
            SFXMuteToggle.onValueChanged.AddListener((bool mute) => ToggleMuteSFX(mute));
        }
    }

    void FillClips()
    {
        Clips.Add("PressButton", ClickClip);
        Clips.Add("ToggleWindow", SwipeClip);
        //Clips.Add("LoadScene", WooshClip);
        Clips.Add("CorrectAnswer", RightClip);
        Clips.Add("WrongAnswer", WrongClip);
        Clips.Add("FlipPage", PageClip);
    }

    public void PlayClip(string key)
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
