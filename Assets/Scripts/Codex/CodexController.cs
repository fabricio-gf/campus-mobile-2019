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

    [Header("References")]
    [SerializeField] private Text TitleText;
    [SerializeField] private Button[] BookmarkButtons;
    [SerializeField] private Image ContentImage;
    [SerializeField] private GameObject PreviousPageButton;
    [SerializeField] private GameObject NextPageButton;

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
                currentPage = codex.Chapters[currentChapter].NumberOfPages-1;
            }
        }
        else{
            currentPage--;
        }
        UpdatePage(currentChapter, currentPage);
    }

    public void NextPage(){
        if(currentPage == codex.Chapters[currentChapter].NumberOfPages-1){
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
                BookmarkButtons[i].enabled = false;
            }
            else{
                BookmarkButtons[i].enabled = true;
            }
        }
    }

    void UpdateContent(int chapterNumber, int pageNumber){
        ContentImage.sprite = codex.Chapters[chapterNumber].Pages[pageNumber].Content;
    }

    void UpdatePageButtons(int chapterNumber, int pageNumber){
        if(chapterNumber == codex.Chapters.Length-1 && pageNumber == codex.Chapters[chapterNumber].NumberOfPages-1){
            NextPageButton.SetActive(false);
        }
        else if(pageNumber == 0){
            PreviousPageButton.SetActive(false);
        }
        else{
            NextPageButton.SetActive(true);
            PreviousPageButton.SetActive(true);
        }
    }

    // METHODS FOR INDEX PAGE

    public void GoToIndex(){
        
    }
}
