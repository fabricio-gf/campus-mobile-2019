using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleReferee : MonoBehaviour
{
    // PUBLIC STATIC ATTRIBUTES
    public static GameObject ItemBeingDragged;
    
    // PUBLIC ATTRIBUTES
    //[HideInInspector]
    public Puzzle CurrentPuzzle;

    public delegate void SerializeAction(bool result);
    public event SerializeAction OnPuzzleVictory;

    // PRIVATE ATTRIBUTES
    private char[] Answer;
    private char[] CurrentAnswer;

    private List<Transform> CardObjects;

    private List<char> Alphabet;

    private int TriesLeft = 5;

    // PRIVATE REFERENCES
    [SerializeField] private GameObject PuzzleObject = null;

    [SerializeField] private Text AnswerText = null;

    //[SerializeField] private List<Transform> AnswerSlots = null;
    [SerializeField] private List<Transform> AnswerTopSlots = null;
    [SerializeField] private List<Transform> AnswerBottomSlots = null;

    [SerializeField] private List<Transform> CardSlots = null;
    [SerializeField] private List<GemChangeColor> Gems = null;

    //[SerializeField] private Transform AnswerArea = null;
    [SerializeField] private Transform AnswerTopArea = null;
    [SerializeField] private Transform AnswerBottomArea = null;

    [SerializeField] private Transform GemsArea = null;
    [SerializeField] private Transform CardsArea = null;


    //[SerializeField] private GameObject SlotPrefab = null;
    [SerializeField] private GameObject SlotTopPrefab = null;
    [SerializeField] private GameObject SlotBottomPrefab = null;

    [SerializeField] private GameObject GemPrefab = null;
    //[SerializeField] private GameObject CardPrefab = null;
    [SerializeField] private GameObject CardTopPrefab = null;
    [SerializeField] private GameObject CardBottomPrefab = null;

    [SerializeField] private Sprite[] LetterSprites = null;
    [SerializeField] private Sprite[] SignSprites = null;

    
    private void Awake()
    {
        Alphabet = new List<char>();
        ResetAlphabet();

        AnswerTopSlots = new List<Transform>();
        AnswerBottomSlots = new List<Transform>();
        CardSlots = new List<Transform>();
        CardObjects = new List<Transform>();
    }

    public void StartPuzzle(Puzzle newPuzzle)
    {
        PuzzleObject.SetActive(true);

        CurrentPuzzle = newPuzzle;

        Answer = CurrentPuzzle.answer;
        CurrentAnswer = new char[Answer.Length];

        SetupPuzzle();
    }

    [ContextMenu("Setup Puzzle")]
    void SetupPuzzle()
    {
        TriesLeft = CurrentPuzzle.tries;

        DestroySlots();

        InitializeSlots();
        FillNecessaryLetters();
        FillRemainingLetters();
        ShuffleLetters();
    }

    void DestroySlots()
    {
        for (int i = 0; i < AnswerTopSlots.Count; i++)
        {
            Destroy(AnswerTopSlots[i].gameObject);
            Destroy(AnswerBottomSlots[i].gameObject);

            Destroy(Gems[i].gameObject);
        }

        AnswerTopSlots.Clear();
        AnswerBottomSlots.Clear();

        Gems.Clear();

        for (int i = 0; i < CardObjects.Count; i++)
        {
            Destroy(CardObjects[i].gameObject);
            Destroy(CardSlots[i].gameObject);
        }
        CardObjects.Clear();
        CardSlots.Clear();
    }

    void ResetAlphabet()
    {
        Alphabet.Clear();
        Alphabet.AddRange("abcdefghijklmnopqrstuvwxyz");
    }

    void FillAnswer()
    {
        AnswerText.text = CurrentPuzzle.question;
        GameObject obj;

        if (CurrentPuzzle.type == Puzzle.PuzzleType.Type1)
        {
            for(int i = 0; i < AnswerTopSlots.Count; i++)
            {
                Destroy(AnswerTopSlots[i].GetComponent<SlotBehaviour>());

                obj = Instantiate(CardTopPrefab, AnswerTopSlots[i]);

                Destroy(obj.GetComponent<CardBehaviour>());

                obj.transform.GetChild(0).GetComponent<Image>().sprite = SignSprites[(int)(Answer[i] - 97)];
            }
        }
        else
        {
            for (int i = 0; i < AnswerBottomSlots.Count; i++)
            {
                Destroy(AnswerBottomSlots[i].GetComponent<SlotBehaviour>());

                obj = Instantiate(CardBottomPrefab, AnswerBottomSlots[i]);

                Destroy(obj.GetComponent<CardBehaviour>());

                obj.transform.GetChild(0).GetComponent<Image>().sprite = LetterSprites[(int)(Answer[i] - 97)];
            }
        }
    }

    void InitializeSlots()
    {
        int slotNumber = CalculateCardSlots();
        GameObject obj;

        for (int i = 0; i < Answer.Length; i++)
        {
            obj = Instantiate(SlotTopPrefab, AnswerTopArea);
            obj.GetComponent<SlotBehaviour>().Referee = this;
            AnswerTopSlots.Add(obj.transform);

            obj = Instantiate(SlotBottomPrefab, AnswerBottomArea);
            obj.GetComponent<SlotBehaviour>().Referee = this;
            AnswerBottomSlots.Add(obj.transform);

            obj = Instantiate(GemPrefab, GemsArea);
            Gems.Add(obj.GetComponent<GemChangeColor>());
        }

        FillAnswer();

        if (CurrentPuzzle.type == Puzzle.PuzzleType.Type1)
        {
            CardsArea.GetComponent<GridLayoutGroup>().cellSize = new Vector2(101.5f,58);

            for (int i = 0; i < slotNumber; i++)
            {
                obj = Instantiate(SlotBottomPrefab, CardsArea);
                obj.GetComponent<SlotBehaviour>().Referee = this;

                CardSlots.Add(obj.transform);
            }
        }
        else
        {
            CardsArea.GetComponent<GridLayoutGroup>().cellSize = new Vector2(92.5f, 101.5f);

            for (int i = 0; i < slotNumber; i++)
            {
                obj = Instantiate(SlotTopPrefab, CardsArea);
                obj.GetComponent<SlotBehaviour>().Referee = this;

                CardSlots.Add(obj.transform);
            }
        }
    }

    void FillNecessaryLetters()
    {
        GameObject obj;
        if (CurrentPuzzle.type == Puzzle.PuzzleType.Type1)
        {
            for (int i = 0; i < Answer.Length; i++)
            {
                obj = Instantiate(CardBottomPrefab);
                CardObjects.Add(obj.transform);

                obj.GetComponent<CardBehaviour>().CardValue = Answer[i];

                obj.transform.GetChild(0).GetComponent<Image>().sprite = LetterSprites[(int)(Answer[i]-97)];

                //Alphabet.Remove(Answer[i]);

            }
        }
        else
        {
            for (int i = 0; i < Answer.Length; i++)
            {
                obj = Instantiate(CardTopPrefab);
                CardObjects.Add(obj.transform);

                obj.GetComponent<CardBehaviour>().CardValue = Answer[i];

                obj.transform.GetChild(0).GetComponent<Image>().sprite = SignSprites[(int)(Answer[i] - 97)];

                //Alphabet.Remove(Answer[i]);

            }
        }
    }

    void FillRemainingLetters()
    {
        GameObject obj;
        if (CurrentPuzzle.type == Puzzle.PuzzleType.Type1)
        {
            for (int i = Answer.Length; i < CardSlots.Count; i++)
            {
                obj = Instantiate(CardBottomPrefab);
                CardObjects.Add(obj.transform);

                int randomIndex = Random.Range(0, Alphabet.Count);
                obj.GetComponent<CardBehaviour>().CardValue = Alphabet[randomIndex];

                obj.transform.GetChild(0).GetComponent<Image>().sprite = LetterSprites[randomIndex];


                //Alphabet.RemoveAt(randomIndex);


            }
        }
        else 
        {
            for (int i = Answer.Length; i < CardSlots.Count; i++)
            {
                obj = Instantiate(CardTopPrefab);
                CardObjects.Add(obj.transform);

                int randomIndex = Random.Range(0, Alphabet.Count);
                obj.GetComponent<CardBehaviour>().CardValue = Alphabet[randomIndex];

                obj.transform.GetChild(0).GetComponent<Image>().sprite = SignSprites[randomIndex];


                //Alphabet.RemoveAt(randomIndex);

            }
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
                Gems[i].ChangeColor(false);
            }
            else
            {
                Gems[i].ChangeColor(true);
            }
        }

        if(incorrectLetters == 0)
        {
            //winner
            print("winner");
            OnPuzzleVictory?.Invoke(true);
        }
        else
        {
            //loser sound
            //lose 1 life
        }
    }

    int CalculateCardSlots()
    {
        GridLayoutGroup grid = CardsArea.GetComponent<GridLayoutGroup>();
        switch (Answer.Length)
        {
            case 1:
                return 3;
            case 3:
                grid.constraintCount = 3;
                return 6;
            case 4:
                grid.constraintCount = 5;
                return 10;
            case 5:
                grid.constraintCount = 4;
                return 12;
            case 6:
                grid.constraintCount = 5;
                return 15;
            default:
                break;
        }
        grid.constraintCount = 3;
        return 6;
    }

    public void HasChanged()
    {
        if (CurrentPuzzle.type == Puzzle.PuzzleType.Type1)
        {
            for (int i = 0; i < AnswerBottomSlots.Count; i++)
            {
                GameObject item = AnswerBottomSlots[i].GetComponent<SlotBehaviour>().Item;
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
        else
        {
            for (int i = 0; i < AnswerTopSlots.Count; i++)
            {
                GameObject item = AnswerTopSlots[i].GetComponent<SlotBehaviour>().Item;
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

    public void ClosePuzzle()
    {
        ClearPuzzleArea();
        PuzzleObject.SetActive(false);
    }

    public void ClearPuzzleArea()
    {
        // delete objects
        DestroySlots();
    }
}
