using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    /*public ActorData data = new ActorData();

    public void StoreData()
    {
        data.pos = transform.position;
    }

    public void LoadData()
    {
        transform.position = data.pos;
    }

    public void ApplyData()
    {
        //SaveData.AddActorData(data);
    }

    public void OnEnable()
    {
        SaveData.OnLoaded += LoadData;
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }

    public void OnDisable()
    {
        SaveData.OnLoaded -= LoadData;
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave -= ApplyData;
    }*/
}

[Serializable]
public class ActorData
{
    public Vector3 pos;
    // dialogue
}