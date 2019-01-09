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
}
