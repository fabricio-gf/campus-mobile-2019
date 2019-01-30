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
                    grid.spacing = new Vector2(20, 40);
                    grid.constraintCount = 3;
                    break;
                case 4:
                    grid.cellSize = new Vector2(117, 105);
                    grid.spacing = new Vector2(50, 40);
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
                    MyTransform.anchoredPosition = new Vector2(0, 199.625f);
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
    }
}
