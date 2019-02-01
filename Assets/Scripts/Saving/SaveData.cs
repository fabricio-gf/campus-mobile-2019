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
    private const float InitialPlayerPosX = -5.5f;
    private const float InitialPlayerPosY = -3.5f;
    private const int InitialProgress = 0;
    private const int InitialChallengeProgress = 0;
    private const int InitialDictionaryProgress = 0;
    private const int InitialChapters = 0;
    //private const int[] InitialPages = 

    public static void LoadPlayer(string path)
    {
        gameData = LoadFromJson(path);

        //spawn player at pos
        PlayerDataManager.SpawnPlayer(PlayerDataManager.playerPath, gameData.PlayerPos, Quaternion.identity);

        OnPlayerLoaded?.Invoke();
    }

    public static void LoadProgress(string path)
    {
        gameData = LoadFromJson(path);

        //set progress in map/game
        ProgressDataManager.SetProgress(gameData.Progress);
        ProgressDataManager.SetChallengeProgress(gameData.ChallengeProgress);

        OnProgressLoaded?.Invoke();
    }

    public static void LoadDictionary(string path)
    {
        gameData = LoadFromJson(path);

        //set dictionary
        DictionaryDataManager.SetDictionary(gameData.DictionaryProgress);

        OnDictionaryLoaded?.Invoke();
    }

    public static void LoadCodex(string path)
    {
        gameData = LoadFromJson(path);

        //set codex
        CodexDataManager.SetCodex(gameData.Chapters);
        OnCodexLoaded?.Invoke();
    }

    public static void Save(string path, GameData data)
    {
        OnBeforeSave?.Invoke();

        SaveToJson(path, data);
    }

    public static void AddPlayerData(Vector2 pos)
    {
        gameData.PlayerPos = pos;
    }

    public static void AddCodexData(int chapters)
    {
        gameData.Chapters = chapters;
    }

    public static void AddProgressData(int progress, int challengeProgress)
    {
        gameData.Progress = progress;
        gameData.ChallengeProgress = challengeProgress;
    }

    public static void AddDictionaryProgressData(int dictionaryProgress)
    {
        gameData.DictionaryProgress = dictionaryProgress;
    }

    public static void ResetSave(string path)
    {
        gameData = new GameData(new Vector2(InitialPlayerPosX, InitialPlayerPosY), InitialProgress, InitialChallengeProgress, InitialDictionaryProgress, InitialChapters);
        PlayerPrefs.SetInt("SFXMute", 0);
        PlayerPrefs.SetInt("MusicMute", 0);
        PlayerPrefs.SetInt("PracticeRecord", 0);

        SaveToJson(path, gameData);
    }

    private static GameData LoadFromJson(string path)
    {
        if (!File.Exists(path))
        {
            //Debug.Log("it does not exist");
            //initialize a new game data with initial values
            gameData = new GameData(new Vector2(InitialPlayerPosX, InitialPlayerPosY), InitialProgress, InitialChallengeProgress, InitialDictionaryProgress, InitialChapters);

            SaveToJson(path, gameData);
            if (File.Exists(path))
            {
                //Debug.Log("it exists now");
            }
        }
        //Debug.Log("it exists");
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
    
    public static int CheckProgress(string path)
    {
        GameData data = LoadFromJson(path);
        if (data == null) Debug.Log("null");
        return data.Progress;
    }

    public static int CheckChallengeProgress(string path)
    {
        GameData data = LoadFromJson(path);
        return data.ChallengeProgress;
    }
}
