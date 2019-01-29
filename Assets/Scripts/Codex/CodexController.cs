using UnityEngine;
using UnityEngine.UI;

public class CodexController : MonoBehaviour
{
    // PRIVATE ATTRIBUTES
    private int CurrentChapter = 0;
    private int CurrentPage = 0;
    private bool IsInIndex = true;
    private GameObject CurrentObject = null;

    [Header("References")]
    // PUBLIC REFERENCES
    public Codex codex = null;

    // PRIVATE REFERENCES
    [SerializeField] private Text TitleText = null;

    [SerializeField] private Button[] BookmarkButtons = null;

    [SerializeField] private Button[] IndexChapterButtons = null;

    [SerializeField] private Image ContentImage = null;

    [SerializeField] private GameObject PreviousPageButton = null;
    [SerializeField] private GameObject NextPageButton = null;
    [SerializeField] private GameObject IndexPageButton = null;

    [SerializeField] private GameObject PageObject = null;
    [SerializeField] private GameObject IndexObject = null;
    [SerializeField] private GameObject ChallengesObject = null;


    public void PreviousPage(){
        if(CurrentPage == 0){
            if(CurrentChapter>0){
                CurrentChapter--;
                CurrentPage = codex.Chapters[CurrentChapter].Pages.Length-1;
            }
        }
        else{
            CurrentPage--;
        }
        UpdatePage(CurrentChapter, CurrentPage);
    }

    public void NextPage(){
        if(CurrentPage == codex.Chapters[CurrentChapter].Pages.Length-1){
            if(CurrentChapter<codex.Chapters.Length-1){
                CurrentChapter++;
                CurrentPage = 0;
            }
        }
        else{
            CurrentPage++;
        }
        UpdatePage(CurrentChapter, CurrentPage);
    }

    // METHODS FOR GENERAL CHAPTERS

    public void GoToChapter(int chapterNumber){
        if(IsInIndex){
            IndexObject.SetActive(false);
            PageObject.SetActive(true);
            CurrentObject = PageObject;
        }
        CurrentChapter = chapterNumber;
        CurrentPage = 0;
        UpdatePage(CurrentChapter, CurrentPage);
    }

    void UpdatePage(int chapterNumber, int pageNumber){
        UpdateTitle(chapterNumber);
        UpdateBookmarks(chapterNumber);
        UpdatePageButtons(chapterNumber, pageNumber);
        UpdateContent(chapterNumber, pageNumber);
    }

    void UpdateTitle(int chapterNumber){
        TitleText.text = codex.Chapters[chapterNumber].ChapterTitle;
    }

    void UpdateBookmarks(int chapterNumber){
        for(int i = 0; i < BookmarkButtons.Length; i++){
            if(i >= codex.UnlockedChapters || i == chapterNumber){
                BookmarkButtons[i].interactable = false;
            }
            else{
                BookmarkButtons[i].interactable = true;
            }
        }
    }

    void UpdateContent(int chapterNumber, int pageNumber){
        ContentImage.sprite = codex.Chapters[chapterNumber].Pages[pageNumber].Content;
        ContentImage.rectTransform.localPosition = new Vector3(0, -500, 0);
    }

    void UpdatePageButtons(int chapterNumber, int pageNumber){
        if((chapterNumber == codex.Chapters.Length-1 && pageNumber == codex.Chapters[chapterNumber].Pages.Length-1)||
            (chapterNumber == codex.UnlockedChapters-1)){
            NextPageButton.SetActive(false);
        }
        else if(chapterNumber == 0 && pageNumber == 0){
            PreviousPageButton.SetActive(false);
        }
        else{
            NextPageButton.SetActive(true);
            PreviousPageButton.SetActive(true);
        }
    }

    // METHODS FOR INDEX CHAPTER

    public void GoToIndex(){
        CurrentObject?.SetActive(false);
        UpdateIndex();
        IndexObject.SetActive(true);
    }

    void UpdateIndex()
    {
        for(int i = 0; i < codex.UnlockedChapters; i++)
        {
            if (i >= codex.Chapters.Length) break;
            IndexChapterButtons[i].interactable = true;
        }

        for(int i = codex.UnlockedChapters; i < codex.Chapters.Length; i++)
        {
            IndexChapterButtons[i].interactable = false;
        }

        if(codex.UnlockedChapters == 0)
        {
            IndexPageButton.SetActive(false);
        }
        else
        {
            IndexPageButton.SetActive(true);
        }
    }

    // METHODS FOR CHALLENGE CHAPTER

    public void GoToChallenges()
    {
        IndexObject.SetActive(false);
        ChallengesObject.SetActive(true);
        CurrentObject = ChallengesObject;
    }
}
