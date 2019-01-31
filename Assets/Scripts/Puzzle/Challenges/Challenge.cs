using UnityEngine;

[CreateAssetMenu(fileName = "Challenge", menuName = "Challenge", order = 1)]
public class Challenge : ScriptableObject
{
    public string ChallengeName;
    public Puzzle[] Puzzles;
    [HideInInspector] public int CompletedPuzzles;
    //public bool InOrder;
    [HideInInspector] public bool Unlocked;
    public int ProgressToUnlock;

    public bool VowelOnly;
    public bool ConsonantOnly;
}
