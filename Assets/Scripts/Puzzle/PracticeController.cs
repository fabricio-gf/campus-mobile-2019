using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeController : MonoBehaviour
{
    private int PuzzleCounter;

    private PuzzleReferee Referee;

    [SerializeField] private List<Puzzle> PuzzleList = null;

    private void Start()
    {
        Referee = GetComponent<PuzzleReferee>();
        Referee.OnPuzzleVictory += FinishPuzzle;
    }

    public void StartAnotherPuzzle()
    {
        Puzzle newPuzzle = GetRandomPuzzle(Referee.CurrentPuzzle);

        Referee.StartPuzzle(newPuzzle);
    }

    Puzzle GetRandomPuzzle(Puzzle oldPuzzle)
    {
        PuzzleList.Remove(oldPuzzle);
        Puzzle newPuzzle = PuzzleList[Random.Range(0, PuzzleList.Count)];
        PuzzleList.Add(oldPuzzle);
        return newPuzzle;
    }

    void FinishPuzzle(bool result)
    {
        PuzzleCounter += result ? 1 : 0;
        print("COUNTER " + PuzzleCounter);

        Referee.ClearPuzzleArea();
    }
}
