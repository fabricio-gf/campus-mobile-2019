using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Puzzle", menuName="Puzzle", order=1)]
public class Puzzle : ScriptableObject
{
    public enum puzzleType
    {
        Type1,
        Type2
    }

    public string question;
    public char[] answer;
}
