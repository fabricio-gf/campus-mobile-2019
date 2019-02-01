using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteractable : Interactable
{
    [SerializeField] private Puzzle[] puzzleList = null;
    [SerializeField] private PuzzleReferee puzzleReferee = null;

    [SerializeField] private int ProgressLimit = 0;

    [SerializeField] private FloatingJoystick Joystick = null;

    private void Start()
    {
        //if (SaveData.CheckProgress(dataPath) > ProgressLimit)
        Debug.Log("Current Progress at " + name + ": " + ProgressDataManager.CurrentProgress);
        Debug.Log("Progress limit at " + name + ": " + ProgressLimit);
        if (ProgressDataManager.CurrentProgress > ProgressLimit)
        {
            Debug.Log("Is being destroyed");
            Destroy(GetComponent<BoxCollider2D>());
        }
    }

    public override void Interact()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        puzzleReferee.StartPuzzle(puzzleList[Random.Range(0,puzzleList.Length)]);
    }

    public void EnableCollider()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        Joystick.ResumeMovement();
    }
}
