using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    // PRIVATE REFERENCES
    [Header("References")]
    [SerializeField] private AnimationClip EnterClip = null;
    [SerializeField] private GameObject LoadingPrefab = null;

    // PRIVATE ATTRIBUTES
    private Animator LoadingAnimator = null;
    private float time = 0;
    private bool firstTime = true;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        GameObject obj = Instantiate(LoadingPrefab);
        DontDestroyOnLoad(obj);
        LoadingAnimator = obj.GetComponent<Animator>();

        SceneManager.sceneLoaded += StartLoadAnimation;
    }

    private void StartLoadAnimation(Scene scene, LoadSceneMode mode)
    {
        if (firstTime) firstTime = false;
        else StartCoroutine(WaitToLoad(1f));
    }

    public void LoadLevel(string SceneName)
    {
        time = 0;
        StartCoroutine(LoadAsynchronously(SceneName));
    }

    public void LoadLevelNow(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
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
        print("loading");
        LoadingAnimator.SetTrigger("Loading");
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        operation.allowSceneActivation = false;

        
        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f && time >= EnterClip.length)
            {
                print("allow");
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

    IEnumerator WaitToLoad(float loadDelay)
    {
        yield return new WaitForSeconds(loadDelay);
        LoadingAnimator.SetTrigger("FinishedLoading");
    }
}
