using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleReferee : MonoBehaviour
{
    public static GameObject ItemBeingDragged;
    public Puzzle CurrentPuzzle;

    private List<char> Alphabet;
    private char[] Answer;
    private char[] CurrentAnswer;

    [SerializeField] private List<Transform> AnswerSlots;
    [SerializeField] private List<Transform> CardSlots;
    private List<Transform> CardObjects;
    [SerializeField] private GameObject CardPrefab;

    private bool FirstTime = true;

    private void Awake()
    {
        Alphabet = new List<char>();
        ResetAlphabet();

        CardObjects = new List<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Answer = CurrentPuzzle.answer;

        SetupPuzzle();
    }

    [ContextMenu("Setup Puzzle")]
    void SetupPuzzle()
    {
        for(int i = 0; i < CardObjects.Count; i++)
        {
            Destroy(CardObjects[i].gameObject);
        }
        CardObjects.Clear();

        FillNecessaryLetters();
        FillRemainingLetters();
        ShuffleLetters();
    }

    void ResetAlphabet()
    {
        Alphabet.Clear();
        Alphabet.AddRange("abcdefghijklmnopqrstuvwxyz");
    }

    void FillNecessaryLetters()
    {
        GameObject obj;
        for(int i = 0; i < Answer.Length; i++)
        {
            obj = Instantiate(CardPrefab);
            CardObjects.Add(obj.transform);

            obj.GetComponent<CardBehaviour>().CardValue = Answer[i];

            //TEMP
            obj.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = Answer[i].ToString().ToUpper();
            //TEMP

            Alphabet.Remove(Answer[i]);

            //obj.sprite = 
            
        }
    }

    void FillRemainingLetters()
    {
        GameObject obj;
        for (int i = Answer.Length; i < CardSlots.Count; i++)
        {
            obj = Instantiate(CardPrefab);
            CardObjects.Add(obj.transform);

            int randomIndex = Random.Range(0, Alphabet.Count);
            obj.GetComponent<CardBehaviour>().CardValue = Alphabet[randomIndex];

            //TEMP
            obj.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = Alphabet[randomIndex].ToString().ToUpper();
            //TEMP

            Alphabet.RemoveAt(randomIndex);

            //obj.sprite = 
            
        }
    }

    void ShuffleLetters()
    {
        List<Transform> slots = new List<Transform>(CardSlots);
        List<Transform> objects = new List<Transform>(CardObjects);
        int randomIndex;

        for(int i = 0; i < CardSlots.Count; i++)
        {

            randomIndex = Random.Range(0, slots.Count);

            objects[0].SetParent(slots[randomIndex]);

            objects[0].GetComponent<CardBehaviour>().UpdatePosition();
            objects.RemoveAt(0);
            slots.RemoveAt(randomIndex);
        }
    }

    public void AddLetter(int position, char letter)
    {
        CurrentAnswer[position] = letter;
    }

    public void RemoveLetter(int position)
    {
        CurrentAnswer[position] = ' ';
    }

    void CheckAnswer()
    {
        string answer, currentAnswer;
        answer = new string(Answer);
        currentAnswer = new string(CurrentAnswer);
        if(string.Compare(answer, currentAnswer) == 0)
        {
            //correct
        }
        else
        {
            //incorrect
            //check incorrect letters
        }
    }
}
