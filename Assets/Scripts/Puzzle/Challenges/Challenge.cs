using UnityEngine;

[CreateAssetMenu(fileName = "Challenge", menuName = "Challenge", order = 1)]
public class Challenge : ScriptableObject
{
    public string ChallengeName;
    public Puzzle[] Puzzles;
    public int CompletedPuzzles;
    public bool InOrder;
    public bool Unlocked;
    public int ProgressToUnlock;

    public bool VowelOnly;
    public bool ConsonantOnly;
}
