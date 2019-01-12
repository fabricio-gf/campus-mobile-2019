using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDialogue : MonoBehaviour
{
    [SerializeField] private GameObject DialogueTrigger = null;
    [SerializeField] private float DialogueDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(DialogueDelay);
        DialogueTrigger.SetActive(true);
    }
}
