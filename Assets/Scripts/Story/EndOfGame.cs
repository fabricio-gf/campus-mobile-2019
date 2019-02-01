using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    private Animator animator = null;
    [SerializeField] private PuzzleReferee referee = null;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        referee.OnPuzzleEnd += EndOfPuzzle;
    }

    private void EndOfPuzzle(bool result)
    {
        if (result)
        {
            animator.SetTrigger("OpenEndOfGame");
        }
    }
}
