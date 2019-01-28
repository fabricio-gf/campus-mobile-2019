using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeCheck : MonoBehaviour
{

    private void Awake()
    {
        if(PlayerPrefs.GetInt("KnowledgeLevel", -1) != -1)
        {
            Destroy(gameObject);
        }
    }

    public void DefineKnowledgeLevel(int level)
    {
        PlayerPrefs.SetInt("KnowledgeLevel", level);
        StartCoroutine(AnimationDelayToDestroy());
    }

    IEnumerator AnimationDelayToDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
