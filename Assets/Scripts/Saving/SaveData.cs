using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData
{
    //public static ActorContainer actorContainer = new ActorContainer();

    public static GameData gameData;

    public delegate void SerializeAction();
    public static event SerializeAction OnPlayerLoaded;
    public static event SerializeAction OnProgressLoaded;
    public static event SerializeAction OnDictionaryLoaded;
    public static event SerializeAction OnCodexLoaded;
    public static event SerializeAction OnBeforeSave;

    // CONSTANT INITIAL VALUES
    private const float InitialPlayerPosX = 0.5f;
    private const float InitialPlayerPosY = 0.5f;
    private const int InitialProgress = 0;
    private const int InitialDictionaryProgress = 0;
    private const int InitialChapters = 0;
    //private const int[] InitialPages = 

    public static void LoadPlayer(string path)
    {
        gameData = LoadFromJson(path);

        //spawn player at pos
        PlayerDataManager.SpawnPlayer(PlayerDataManager.playerPath, gameData.PlayerPos, Quaternion.identity);

        OnPlayerLoaded();
    }

    public static void LoadProgress(string path)
    {
        gameData = LoadFromJson(path);

        //set progress in map/game
        ProgressDataManager.SetProgress(gameData.Progress);

        OnProgressLoaded();
    }

    public static void LoadDictionary(string path)
    {
        gameData = LoadFromJson(path);

        //set dictionary
        DictionaryDataManager.SetDictionary(gameData.DictionaryProgress);

        OnDictionaryLoaded();
    }

    public static void LoadCodex(string path)
    {
        gameData = LoadFromJson(path);

        //set codex
        CodexDataManager.SetCodex(gameData.Chapters);

        OnCodexLoaded();
    }

    public static void Save(string path, GameData data)
    {
        OnBeforeSave();

        SaveToJson(path, data);
    }

    public static void AddPlayerData(Vector2 pos)
    {
        gameData.PlayerPos = pos;
    }

    private static GameData LoadFromJson(string path)
    {
        if (!File.Exists(path))
        {
            Debug.Log("it does not exist");
            //initialize a new game data with initial values
            gameData = new GameData(new Vector2(InitialPlayerPosX, InitialPlayerPosY), InitialProgress, InitialDictionaryProgress, InitialChapters);

            SaveToJson(path, gameData);
            if (File.Exists(path))
            {
                Debug.Log("it exists now");
            }
        }
        Debug.Log("it exists");
        string json = File.ReadAllText(path);

        return JsonUtility.FromJson<GameData>(json);
    }

    private static void SaveToJson(string path, GameData data)
    {
        string json = JsonUtility.ToJson(data);

        StreamWriter writer = File.CreateText(path);
        writer.Close();

        File.WriteAllText(path, json);
    }
}
