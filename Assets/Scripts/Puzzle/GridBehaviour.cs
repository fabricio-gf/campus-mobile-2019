using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridBehaviour : MonoBehaviour
{
    [SerializeField] private bool IsGrid = false;
    //[SerializeField] private bool IsHorizontal = false;

    private RectTransform MyTransform = null;
    private GridLayoutGroup grid = null;
    //private HorizontalLayoutGroup horizontal = null;

    void Awake()
    {
        if (IsGrid) grid = GetComponent<GridLayoutGroup>();
        //if (IsHorizontal) horizontal = GetComponent<HorizontalLayoutGroup>();
    }

    public void ChangeGridParameters(int caseNumber, int cardType)
    {
        if (cardType == 0)
        {
            switch (caseNumber)
            {
                case 1:
                    grid.cellSize = new Vector2(145.25f, 83);
                    grid.spacing = new Vector2(25, 25);
                    grid.constraintCount = 3;
                    break;
                case 3:
                    grid.cellSize = new Vector2(145.25f, 83);
                    grid.spacing = new Vector2(25, 50);
                    grid.constraintCount = 3;
                    break;
                case 4:
                    grid.cellSize = new Vector2(117, 54.25f);
                    grid.spacing = new Vector2(25, 40);
                    grid.constraintCount = 3;
                    break;
                case 5:
                    grid.cellSize = new Vector2(111, 63);
                    grid.spacing = new Vector2(25, 35);
                    grid.constraintCount = 4;
                    break;
                case 6:
                    grid.cellSize = new Vector2(89, 51.75f);
                    grid.spacing = new Vector2(20, 40);
                    grid.constraintCount = 5;
                    break;
                default:
                    break;
            }
        }
        else if(cardType == 1)
        {
            switch (caseNumber)
            {
                case 1:
                    grid.cellSize = new Vector2(145.25f, 130);
                    grid.spacing = new Vector2(25, 25);
                    grid.constraintCount = 3;
                    break;
                case 3:
                    grid.cellSize = new Vector2(145.25f, 130);
                    grid.spacing = new Vector2(25, 40);
                    grid.constraintCount = 3;
                    break;
                case 4:
                    grid.cellSize = new Vector2(117, 105);
                    grid.spacing = new Vector2(40, 10);
                    grid.constraintCount = 3;
                    break;
                case 5:
                    grid.cellSize = new Vector2(111, 100);
                    grid.spacing = new Vector2(20, 25);
                    grid.constraintCount = 4;
                    break;
                case 6:
                    grid.cellSize = new Vector2(89, 80);
                    grid.spacing = new Vector2(18, 40);
                    grid.constraintCount = 5;
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangePosition(int caseNumber, int caseType)
    {
        MyTransform = GetComponent<RectTransform>();
        HorizontalLayoutGroup horizontal = GetComponent<HorizontalLayoutGroup>();

        if (caseType == 0)
        {
            switch (caseNumber)
            {
                case 1:
                    //MyTransform.anchoredPosition = new Vector2();
                    break;
                case 3:
                    //MyTransform.anchoredPosition = new Vector2();
                    horizontal.spacing = 40;
                    break;
                case 4:
                    //MyTransform.anchoredPosition = new Vector2();
                    horizontal.spacing = 20;
                    break;
                case 5:
                    //MyTransform.anchoredPosition = new Vector2();
                    horizontal.spacing = 5;
                    break;
                case 6:
                    //MyTransform.anchoredPosition = new Vector2();
                    horizontal.spacing = 5;
                    break;
                default:
                    break;
            }
        }
        else if (caseType == 1)
        {
            switch (caseNumber)
            {
                case 1:
                    MyTransform.anchoredPosition = new Vector2(0, 226.5f);
                    break;
                case 3:
                    MyTransform.anchoredPosition = new Vector2(0, 226.5f);
                    horizontal.spacing = 40;
                    break;
                case 4:
                    MyTransform.anchoredPosition = new Vector2(0, 206);
                    horizontal.spacing = 20;
                    break;
                case 5:
                    MyTransform.anchoredPosition = new Vector2(0, 201.5f);
                    horizontal.spacing = 5;
                    break;
                case 6:
                    MyTransform.anchoredPosition = new Vector2(0, 185.875f);
                    horizontal.spacing = 5;
                    break;
                default:
                    break;
            }
        }
        else if(caseType == 2){
            switch (caseNumber)
            {
                case 1:
                    MyTransform.anchoredPosition = new Vector2(0, 325);
                    break;
                case 3:
                    MyTransform.anchoredPosition = new Vector2(0, 325);
                    horizontal.spacing = 40;
                    break;
                case 4:
                    MyTransform.anchoredPosition = new Vector2(0, 285);
                    horizontal.spacing = 20;
                    break;
                case 5:
                    MyTransform.anchoredPosition = new Vector2(0, 275);
                    horizontal.spacing = 5;
                    break;
                case 6:
                    MyTransform.anchoredPosition = new Vector2(0, 250);
                    horizontal.spacing = 5;
                    break;
                default:
                    break;
            }
        }
    }

    [ContextMenu("GridParameters 1, Top type")]
    public void GridParameters1()
    {
        grid = GetComponent<GridLayoutGroup>();
        ChangeGridParameters(1, 1);
    }
    [ContextMenu("GridParameters 3, Top type")]
    public void GridParameters3()
    {
        grid = GetComponent<GridLayoutGroup>();
        ChangeGridParameters(3, 1);
    }
    [ContextMenu("GridParameters 4, Top type")]
    public void GridParameters4()
    {
        grid = GetComponent<GridLayoutGroup>();
        ChangeGridParameters(4, 1);
    }
    [ContextMenu("GridParameters 5, Top type")]
    public void GridParameters5()
    {
        grid = GetComponent<GridLayoutGroup>();
        ChangeGridParameters(5, 1);
    }
    [ContextMenu("GridParameters 6, Top type")]
    public void GridParameters6()
    {
        grid = GetComponent<GridLayoutGroup>();
        ChangeGridParameters(6, 1);
    }

    [ContextMenu("ChangePosition 1, Top answer")]
    public void ChangePosition1()
    {
        MyTransform = GetComponent<RectTransform>();
        HorizontalLayoutGroup horizontal = GetComponent<HorizontalLayoutGroup>();
        ChangePosition(1, 1);
    }
    [ContextMenu("ChangePosition 3, Top answer")]
    public void ChangePosition3()
    {
        MyTransform = GetComponent<RectTransform>();
        HorizontalLayoutGroup horizontal = GetComponent<HorizontalLayoutGroup>();
        ChangePosition(3, 1);
    }
    [ContextMenu("ChangePosition 4, Top answer")]
    public void ChangePosition4()
    {
        MyTransform = GetComponent<RectTransform>();
        HorizontalLayoutGroup horizontal = GetComponent<HorizontalLayoutGroup>();
        ChangePosition(4, 1);
    }
    [ContextMenu("ChangePosition 5, Top answer")]
    public void ChangePosition5()
    {
        MyTransform = GetComponent<RectTransform>();
        HorizontalLayoutGroup horizontal = GetComponent<HorizontalLayoutGroup>();
        ChangePosition(5, 1);
    }
    [ContextMenu("ChangePosition 6, Top answer")]
    public void ChangePosition6()
    {
        MyTransform = GetComponent<RectTransform>();
        HorizontalLayoutGroup horizontal = GetComponent<HorizontalLayoutGroup>();
        ChangePosition(6, 1);
    }
    [ContextMenu("ChangePosition 1, Bottom answer")]
    public void ChangePosition1_2()
    {
        MyTransform = GetComponent<RectTransform>();
        HorizontalLayoutGroup horizontal = GetComponent<HorizontalLayoutGroup>();
        ChangePosition(1, 0);
    }
    [ContextMenu("ChangePosition 3, Bottom answer")]
    public void ChangePosition3_2()
    {
        MyTransform = GetComponent<RectTransform>();
        HorizontalLayoutGroup horizontal = GetComponent<HorizontalLayoutGroup>();
        ChangePosition(3, 0);
    }
    [ContextMenu("ChangePosition 4, Bottom answer")]
    public void ChangePosition4_2()
    {
        MyTransform = GetComponent<RectTransform>();
        HorizontalLayoutGroup horizontal = GetComponent<HorizontalLayoutGroup>();
        ChangePosition(4, 0);
    }
    [ContextMenu("ChangePosition 5, Bottom answer")]
    public void ChangePosition5_2()
    {
        MyTransform = GetComponent<RectTransform>();
        HorizontalLayoutGroup horizontal = GetComponent<HorizontalLayoutGroup>();
        ChangePosition(5, 0);
    }
    [ContextMenu("ChangePosition 6, Bottom answer")]
    public void ChangePosition6_2()
    {
        MyTransform = GetComponent<RectTransform>();
        HorizontalLayoutGroup horizontal = GetComponent<HorizontalLayoutGroup>();
        ChangePosition(6, 0);
    }
}
