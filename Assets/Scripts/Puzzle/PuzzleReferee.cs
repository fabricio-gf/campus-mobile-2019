﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleReferee : MonoBehaviour, IHasChanged
{
    public static GameObject ItemBeingDragged;
    public Puzzle CurrentPuzzle;

    private List<char> Alphabet;
    private char[] Answer;
    private char[] CurrentAnswer;

    [SerializeField] private List<Transform> AnswerSlots;
    [SerializeField] private List<Transform> CardSlots;

    [SerializeField] private Transform AnswerArea;
    [SerializeField] private Transform CardsArea;

    private List<Transform> CardObjects;

    [SerializeField] private GameObject CardPrefab;
    [SerializeField] private GameObject SlotPrefab;

    [SerializeField] private Sprite[] LetterSprites;
    [SerializeField] private Sprite[] SignSprites;

    private bool FirstTime = true;

    private int TriesLeft;

    private void Awake()
    {
        Alphabet = new List<char>();
        ResetAlphabet();

        CardObjects = new List<Transform>();
        AnswerSlots = new List<Transform>();
        CardSlots = new List<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Answer = CurrentPuzzle.answer;
        CurrentAnswer = new char[Answer.Length];

        SetupPuzzle();
    }

    [ContextMenu("Setup Puzzle")]
    void SetupPuzzle()
    {
        TriesLeft = CurrentPuzzle.tries;

        for(int i = 0; i < AnswerSlots.Count; i++)
        {
            Destroy(AnswerSlots[i].gameObject);
        }
        AnswerSlots.Clear();
        for(int i = 0; i < CardObjects.Count; i++)
        {
            Destroy(CardObjects[i].gameObject);
            Destroy(CardSlots[i].gameObject);
        }
        CardObjects.Clear();
        CardSlots.Clear();

        InitializeSlots();
        FillNecessaryLetters();
        FillRemainingLetters();
        ShuffleLetters();
    }

    void ResetAlphabet()
    {
        Alphabet.Clear();
        Alphabet.AddRange("abcdefghijklmnopqrstuvwxyz");
    }

    void InitializeSlots()
    {
        int slotNumber = CalculateCardSlots();
        GameObject obj;
        
        for(int i = 0; i < Answer.Length; i++)
        {
            obj = Instantiate(SlotPrefab, AnswerArea);
            obj.GetComponent<SlotBehaviour>().Referee = this;
            AnswerSlots.Add(obj.transform);
        }
        for(int i = 0; i < slotNumber; i++)
        {
            obj = Instantiate(SlotPrefab, CardsArea);
            obj.GetComponent<SlotBehaviour>().Referee = this;

            //change size/parameters of slot

            CardSlots.Add(obj.transform);
        }
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

            //Alphabet.Remove(Answer[i]);

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

            //Alphabet.RemoveAt(randomIndex);

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

    void AddLetter(int position, char letter)
    {
        CurrentAnswer[position] = letter;
    }

    void RemoveLetter(int position)
    {
        CurrentAnswer[position] = ' ';
    }

    public void CheckAnswer()
    {
        int incorrectLetters = 0;
        for(int i = 0; i < Answer.Length; i++)
        {
            if (Answer[i] != CurrentAnswer[i])
            {
                incorrectLetters++;
                //incorrect visual in slot
                print("wrong in position " + i);
            }
        }

        if(incorrectLetters == 0)
        {
            //winner
            print("winner");
        }
        else
        {
            //loser sound
        }
    }

    int CalculateCardSlots()
    {
        return Answer.Length * 2;
    }

    public void HasChanged()
    {
        print("entrou");
        for(int i = 0; i < AnswerSlots.Count; i++)
        {
            GameObject item = AnswerSlots[i].GetComponent<SlotBehaviour>().Item;
            if (item)
            {
                AddLetter(i, item.GetComponent<CardBehaviour>().CardValue);
            }
            else
            {
                RemoveLetter(i);
            }
        }
    }
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged: IEventSystemHandler
    {
        void HasChanged();
    }
}
