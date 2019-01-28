using UnityEngine;

[CreateAssetMenu(fileName = "Challenge", menuName = "Challenge", order = 1)]
public class Challenge : ScriptableObject
{
    public string ChallengeName;
    public Puzzle[] Puzzles;
    public bool InOrder;
    public bool Unlocked;
}
