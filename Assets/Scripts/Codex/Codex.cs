using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Codex", menuName="Codex", order=1)]
public class Codex : ScriptableObject
{
    [System.Serializable] public struct Chapter{
        //public int ChapterNumber;
        public string ChapterTitle;
        public Page[] Pages;
    }

    [System.Serializable] public struct Page{
        public int PageNumber;
        public Sprite Content;
    }

    public Chapter[] Chapters;
}
