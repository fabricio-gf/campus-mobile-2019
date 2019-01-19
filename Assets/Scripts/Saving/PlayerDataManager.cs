using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDataManager : DataManager {

    public const string playerPath = "Prefabs/Player";

    private void Start()
    {
        LoadPlayer();
    }

    public static void SpawnPlayer(string path, Vector2 position, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        GameObject obj = Instantiate(prefab, position, rotation);
        obj.GetComponent<PlayerSaving>().data = SaveData.gameData;
    }

    public void LoadPlayer()
	{
		SaveData.LoadPlayer(dataPath);
	}
}
