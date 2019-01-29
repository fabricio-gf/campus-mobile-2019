using UnityEngine;

[CreateAssetMenu(fileName="Puzzle", menuName="Puzzle", order=1)]
public class Puzzle : ScriptableObject
{
    public enum PuzzleType
    {
        Type1,
        Type2
    }

    public PuzzleType type;
    public string question;
    public char[] answer;
    public int tries;
    public bool noRepetition;
}
