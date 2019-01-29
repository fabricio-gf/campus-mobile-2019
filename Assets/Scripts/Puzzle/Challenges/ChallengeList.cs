using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeList : MonoBehaviour
{
    private List<Button> Buttons;
    [SerializeField] private GameObject ButtonPrefab;
    [SerializeField] private Sprite UnlockedIcon;

    [SerializeField] private Challenge[] Challenges;

    [SerializeField] private PuzzleSequence puzzleSequence;

    void Awake()
    {
        Buttons = new List<Button>();
        InitializeButtons();
    }

    void InitializeButtons()
    {
        GameObject obj;
        for(int i = 0; i < Challenges.Length; i++)
        {
            obj = Instantiate(ButtonPrefab, transform);
            obj.transform.GetComponentInChildren<Text>().text = Challenges[i].ChallengeName;
            
            Buttons.Add(obj.GetComponent<Button>());
            if (!Challenges[i].Unlocked && Challenges[i].ProgressToUnlock <= ProgressDataManager.CurrentChallengeProgress)
            {
                Challenges[i].Unlocked = true;
            }
            if (Challenges[i].Unlocked)
            {
                Buttons[i].interactable = true;

                Transform child = obj.transform.GetChild(1);
                child.GetComponent<Image>().sprite = UnlockedIcon;

                Text completionText = child.GetChild(0).GetComponent<Text>();
                completionText.text = Challenges[i].CompletedPuzzles + " / " + Challenges[i].Puzzles.Length;

                int index = i;
                Buttons[i].onClick.RemoveAllListeners();
                Buttons[i].onClick.AddListener(() => OpenChallenge(index));
            }
            else
            {
                Challenges[i].CompletedPuzzles = 0;
            }
        }
    }

    public void OpenChallenge(int challengeIndex)
    {
        puzzleSequence.StartPuzzleSequence(Challenges[challengeIndex]);
    }

    public void UpdateButtonsState()
    {
        for(int i = 0; i < Challenges.Length; i++)
        {
            if (!Challenges[i].Unlocked && Challenges[i].ProgressToUnlock <= ProgressDataManager.CurrentChallengeProgress)
            {
                Challenges[i].Unlocked = true;
            }
            if (Challenges[i].Unlocked)
            {
                Buttons[i].interactable = true;

                Transform child = Buttons[i].transform.GetChild(1);
                child.GetComponent<Image>().sprite = UnlockedIcon;

                Text completionText = child.GetChild(0).GetComponent<Text>();
                completionText.text = Challenges[i].CompletedPuzzles + " / " + Challenges[i].Puzzles.Length;

                int index = i;
                Buttons[i].onClick.RemoveAllListeners();
                Buttons[i].onClick.AddListener(() => OpenChallenge(index));
            }
        }
    }

    void CloseWindow() {
        
    }

}
