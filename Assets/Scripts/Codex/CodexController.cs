using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodexController : MonoBehaviour
{

    // PRIVATE ATTRIBUTES
    [SerializeField] private Codex codex;
    private int currentChapter;
    private int currentPage;
    private bool isInIndex = true;

    [Header("References")]
    [SerializeField] private Text TitleText;
    [SerializeField] private Button[] BookmarkButtons;
    [SerializeField] private Image ContentImage;
    [SerializeField] private GameObject PreviousPageButton;
    [SerializeField] private GameObject NextPageButton;
    [SerializeField] private GameObject PageObject;
    [SerializeField] private GameObject IndexObject;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void PreviousPage(){
        if(currentPage == 0){
            if(currentChapter>0){
                currentChapter--;
                currentPage = codex.Chapters[currentChapter].Pages.Length-1;
            }
        }
        else{
            currentPage--;
        }
        UpdatePage(currentChapter, currentPage);
    }

    public void NextPage(){
        if(currentPage == codex.Chapters[currentChapter].Pages.Length-1){
            if(currentChapter<codex.Chapters.Length-1){
                currentChapter++;
                currentPage = 0;
            }
        }
        else{
            currentPage++;
        }
        UpdatePage(currentChapter, currentPage);
    }

    // METHODS FOR GENERAL PAGES

    public void GoToChapter(int chapterNumber){
        if(isInIndex){
            IndexObject.SetActive(false);
            PageObject.SetActive(true);
        }
        currentChapter = chapterNumber;
        currentPage = 0;
        UpdatePage(currentChapter, currentPage);
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
            if(i == chapterNumber){
                BookmarkButtons[i].interactable = false;
            }
            else{
                BookmarkButtons[i].interactable = true;
            }
        }
    }

    void UpdateContent(int chapterNumber, int pageNumber){
        ContentImage.sprite = codex.Chapters[chapterNumber].Pages[pageNumber].Content;
    }

    void UpdatePageButtons(int chapterNumber, int pageNumber){
        if(chapterNumber == codex.Chapters.Length-1 && pageNumber == codex.Chapters[chapterNumber].Pages.Length-1){
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

    // METHODS FOR INDEX PAGE

    public void GoToIndex(){
        PageObject.SetActive(false);
        IndexObject.SetActive(true);
    }
}
