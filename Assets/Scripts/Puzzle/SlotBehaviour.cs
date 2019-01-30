using UnityEngine;
using UnityEngine.EventSystems;

public class SlotBehaviour : MonoBehaviour, IDropHandler
{
    // PUBLIC ATTRIBUTES
    public GameObject Item{
        get{
            if(transform.childCount>0){
                return transform.GetChild(0).gameObject;
            }
            else{
                return null;
            }
        }
    }

    [HideInInspector] public PuzzleReferee Referee;

    // PRIVATE ATTRIBUTES
    private Transform NewParent = null;
    private GameObject ItemReference = null;
    private RectTransform MyTransform = null;

    public void OnDrop (PointerEventData eventData){
        if(!Item){

            PuzzleReferee.ItemBeingDragged.transform.SetParent(transform);
        }
        else{
            NewParent = PuzzleReferee.ItemBeingDragged.GetComponent<CardBehaviour>().StartParent;
            ItemReference = Item;
            Item.transform.SetParent(NewParent);
            ItemReference.GetComponent<CardBehaviour>().UpdatePosition();
            PuzzleReferee.ItemBeingDragged.transform.SetParent(transform);
        }
        Referee.HasChanged();
    }

    public void ChangeSize(int caseNumber, int cardType)
    {
        MyTransform = GetComponent<RectTransform>();
        if (cardType == 0)
        {
            switch (caseNumber)
            {
                case 1:
                    MyTransform.sizeDelta = new Vector2(145.25f, 83);
                    break;
                case 3:
                    MyTransform.sizeDelta = new Vector2(145.25f, 83);
                    break;
                case 4:
                    MyTransform.sizeDelta = new Vector2(117, 54.25f);
                    break;
                case 5:
                    MyTransform.sizeDelta = new Vector2(111, 63);
                    break;
                case 6:
                    MyTransform.sizeDelta = new Vector2(89, 51.75f);
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
                    MyTransform.sizeDelta = new Vector2(145.25f, 130);
                    break;
                case 3:
                    MyTransform.sizeDelta = new Vector2(145.25f, 130);
                    break;
                case 4:
                    MyTransform.sizeDelta = new Vector2(117, 105);
                    break;
                case 5:
                    MyTransform.sizeDelta = new Vector2(111, 100);
                    break;
                case 6:
                    MyTransform.sizeDelta = new Vector2(89, 80);
                    break;
                default:
                    break;
            }
        }
    }
}
