using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSequence : MonoBehaviour
{
    private PuzzleReferee Referee;
    private int PuzzleIndex;
    private Puzzle[] Puzzles;

    private void Awake()
    {
        Referee = GetComponent<PuzzleReferee>();
    }

    public void StartPuzzleSequence(Puzzle[] puzzles)
    {
        Puzzles = puzzles;

        Referee.OnPuzzleEnd += PuzzleEnd;

        PuzzleIndex = 0;
        Referee.StartPuzzle(puzzles[PuzzleIndex]);
    }

    public void PuzzleEnd(bool result)
    {
        if (result)
        {
            Referee.ClearPuzzleArea();
            PuzzleIndex++;
            if (PuzzleIndex < Puzzles.Length)
            {
                Referee.StartPuzzle(Puzzles[PuzzleIndex]);
            }
            else
            {
                print("winner of all puzzles");
                Referee.ClosePuzzle();
            }
        }
    }
}
