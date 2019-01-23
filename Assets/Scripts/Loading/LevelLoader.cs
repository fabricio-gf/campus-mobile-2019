using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    // PRIVATE REFERENCES
    [Header("References")]
    [SerializeField] private Animator LoadingAnimator = null;
    [SerializeField] private AnimationClip LoadingClip = null;

    // PRIVATE ATTRIBUTES
    private float time = 0;

    public void LoadLevel(string SceneName)
    {
        time = 0;
        StartCoroutine(LoadAsynchronously(SceneName));
    }

    public void LoadCodexScene(string SceneName)
    {
        LoadingInfo.CodexReturnToSceneName = SceneManager.GetActiveScene().name;
        LoadLevel(SceneName);
    }

    public void LoadPreviousScene()
    {
        time = 0;
        StartCoroutine(LoadAsynchronously(LoadingInfo.CodexReturnToSceneName));
    }

    IEnumerator LoadAsynchronously (string SceneName)
    {
        LoadingAnimator.SetTrigger("Loading");
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        operation.allowSceneActivation = false;

        
        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f && time >= LoadingClip.length)
            {
                operation.allowSceneActivation = true;
            }
            time += Time.deltaTime;
            //failsafe
            if (time >= 5)
            {
                Debug.Log("FAILED");
                break;
            }
            yield return null;
        }
    }
}
