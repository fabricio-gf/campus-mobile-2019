using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData
{
    //public static ActorContainer actorContainer = new ActorContainer();

    public static GameData gameData = new GameData();

    public delegate void SerializeAction();
    public static event SerializeAction OnLoaded;
    public static event SerializeAction OnBeforeSave;

    public static void Load(string path)
    {
        gameData = LoadFromJson(path);
        Debug.Log(gameData);

        /*foreach(ActorData data in actorContainer.actors)
        {
            GameController.CreateActor(data, GameController.playerPath, data.pos, Quaternion.identity);
        }*/

        //spawn player at pos
        Debug.Log(GameController.playerPath);
        GameController.SpawnPlayer(GameController.playerPath, gameData.playerPos, Quaternion.identity);

        //set progress in map/game

        //set codex

        OnLoaded();

        //ClearActorList();
    }

    public static void Save(string path, GameData data)
    {
        OnBeforeSave();

        SaveToJson(path, data);
    }

    public static void AddPlayerData(Vector2 pos)
    {
        gameData.playerPos = pos;
    }

    /*public static void ClearActorList()
    {
        actorContainer.actors.Clear();
    }*/

    private static GameData LoadFromJson(string path)
    {
        if (!File.Exists(path))
        {
            Debug.Log("it does not exist");
            gameData = GameController.InitialValues;
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
