using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeController : MonoBehaviour
{
    private int PuzzleCounter;

    private PuzzleReferee Referee;

    private List<Puzzle> PuzzleList = null;

    [SerializeField] private List<Puzzle> OriginalPuzzleList = null;
    [SerializeField] private Text CounterText = null;
    [SerializeField] private Text EndText = null;
    [SerializeField] private Text RecordText1 = null;
    [SerializeField] private Text RecordText2 = null;
    [SerializeField] private int PracticeTries = 5;
    [SerializeField] private GameObject EndScreen = null;
    [SerializeField] private GameObject MainScreen = null;
    [SerializeField] private GameObject PuzzleObject = null;

    private void Start()
    {
        Referee = GetComponent<PuzzleReferee>();
        Referee.OnPuzzleEnd += FinishPuzzle;
        PuzzleList = new List<Puzzle>(OriginalPuzzleList);
        Referee.CarryOverTries = true;

        ResetEverything();

        RecordText1.text = "Recorde: " + PlayerPrefs.GetInt("PracticeRecord", 0);
        RecordText2.text = "Seu recorde é de " + PlayerPrefs.GetInt("PracticeRecord", 0) + " desafios";
    }

    public void StartAnotherPuzzle()
    {
        Puzzle newPuzzle = GetRandomPuzzle(Referee.CurrentPuzzle);

        Referee.StartPuzzle(newPuzzle);
    }

    Puzzle GetRandomPuzzle(Puzzle oldPuzzle)
    {
        if (oldPuzzle != null) PuzzleList.Remove(oldPuzzle);
        if (PuzzleList.Count <= 0)
        {
            PuzzleList = new List<Puzzle>(OriginalPuzzleList);
        }
        //if (oldPuzzle != null) PuzzleList.Remove(oldPuzzle);

        Puzzle newPuzzle = PuzzleList[Random.Range(0, PuzzleList.Count)];
        return newPuzzle;
    }

    void FinishPuzzle(bool result)
    {
        Referee.ClearPuzzleArea();
        if (result)
        {
            PuzzleCounter++;
            CounterText.text = "Contador atual: " + PuzzleCounter;
            StartAnotherPuzzle();
        }
        else
        {
            //end practice
            if (PlayerPrefs.GetInt("PracticeRecord", 0) < PuzzleCounter)
            {
                PlayerPrefs.SetInt("PracticeRecord", PuzzleCounter);
                RecordText1.text = "Recorde: " + PuzzleCounter;
                RecordText2.text = "Seu recorde é de " + PlayerPrefs.GetInt("PracticeRecord", 0) + " desafios";
                PuzzleCounter = 0;
            }
            GoToEndScreen();
        }
    }

    public void GoToEndScreen()
    {
        EndText.text = "Você completou " + PuzzleCounter + " desafios";
        Referee.ClosePuzzle();
        EndScreen.SetActive(true);
    }

    public void GoToMain()
    {
        EndScreen.SetActive(false);
        MainScreen.SetActive(true);

    }

    public void StartPuzzleSequence()
    {
        ResetEverything();
        EndScreen.SetActive(false);
        MainScreen.SetActive(false);
        PuzzleObject.SetActive(true);
        StartAnotherPuzzle();
    }

     void ResetEverything()
    {
        Referee.SetTriesLeft(PracticeTries);
        PuzzleCounter = 0;
    }
}
