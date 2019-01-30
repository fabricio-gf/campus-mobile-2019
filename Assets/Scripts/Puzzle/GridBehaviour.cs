using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridBehaviour : MonoBehaviour
{
    [SerializeField] private bool IsGrid = false;
    [SerializeField] private bool IsHorizontal = false;

    private GridLayoutGroup grid = null;
    private HorizontalLayoutGroup horizontal = null;

    void Awake()
    {
        if (IsGrid) grid = GetComponent<GridLayoutGroup>();
        if (IsHorizontal) horizontal = GetComponent<HorizontalLayoutGroup>();
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
                    grid.cellSize = new Vector2(127.75f, 73);
                    grid.spacing = new Vector2(25, 40);
                    grid.constraintCount = 3;
                    break;
                case 5:
                    grid.cellSize = new Vector2(110.25f, 63);
                    grid.spacing = new Vector2(25, 35);
                    grid.constraintCount = 4;
                    break;
                case 6:
                    grid.cellSize = new Vector2(87.5f, 50);
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
                    grid.cellSize = new Vector2(150.3f, 135);
                    grid.spacing = new Vector2(25, 25);
                    grid.constraintCount = 3;
                    break;
                case 3:
                    grid.cellSize = new Vector2(150.3f, 135);
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

    public void ChangeHorizontalParameters(int caseNumber)
    {

    }
}
