using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSequence : MonoBehaviour
{
    private PuzzleReferee Referee;
    private int PuzzleIndex;
    private Challenge challenge;
    private Puzzle[] Puzzles;
    [SerializeField] private ChallengeList challengesList;

    private void Awake()
    {
        Referee = GetComponent<PuzzleReferee>();
    }

    public void StartPuzzleSequence(Challenge challenge)
    {
        this.challenge = challenge;
        Puzzles = challenge.Puzzles;

        Referee.OnPuzzleEnd += PuzzleEnd;

        if (challenge.CompletedPuzzles >= challenge.Puzzles.Length) PuzzleIndex = 0;
        else PuzzleIndex = challenge.CompletedPuzzles;

        Referee.StartPuzzle(challenge.Puzzles[PuzzleIndex], challenge.VowelOnly, challenge.ConsonantOnly);
    }

    public void PuzzleEnd(bool result)
    {
        if (result)
        {
            Referee.ClearPuzzleArea();
            PuzzleIndex++;
            if (PuzzleIndex < Puzzles.Length)
            {
                if (challenge.CompletedPuzzles <= PuzzleIndex)
                {
                    challenge.CompletedPuzzles++;
                }

                Referee.StartPuzzle(Puzzles[PuzzleIndex], challenge.VowelOnly, challenge.ConsonantOnly);
            }
            else
            {
                ProgressDataManager.SetChallengeProgress(challenge.ProgressToUnlock+1);

                if (challenge.CompletedPuzzles < PuzzleIndex)
                {
                    challenge.CompletedPuzzles++;
                }

                Referee.OnPuzzleEnd -= PuzzleEnd;
                Referee.ClosePuzzle();

                challengesList.UpdateButtonsState();
            }
        }
        else {
            Referee.OnPuzzleEnd -= PuzzleEnd;
            challengesList.UpdateButtonsState();
        }
    }
}
