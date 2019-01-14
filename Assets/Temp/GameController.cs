using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public const string playerPath = "Prefabs/Player";

    private static string dataPath = string.Empty;

    public static GameData InitialValues = new GameData();
    [SerializeField] private Vector2 InitialPlayerPos;
    [SerializeField] private int InitialProgress = 0;
    [SerializeField] private int InitialChapters = 0;
    [SerializeField] private int[] InitialPages;

    void Awake()
    {
    	dataPath = System.IO.Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    private void Start()
    {
        InitialValues.playerPos = InitialPlayerPos;
        InitialValues.progress = InitialProgress;
        InitialValues.chapters = InitialChapters;
        InitialValues.pages = InitialPages;

        Load();
    }

    public static void SpawnPlayer(string path, Vector2 position, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        GameObject obj = Instantiate(prefab, position, rotation);
        obj.GetComponent<Player>().data = SaveData.gameData;
    }

	public void Save()
	{
		SaveData.Save(dataPath, SaveData.gameData);
	}

	public void Load()
	{
		SaveData.Load(dataPath);
	}
}
