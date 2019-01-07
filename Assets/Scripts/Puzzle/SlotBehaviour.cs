using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotBehaviour : MonoBehaviour, IDropHandler
{
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

    private Transform NewParent = null;
    private GameObject ItemReference = null;

    public void OnDrop (PointerEventData eventData){
        if(!Item){
            CardBehaviour.ItemBeingDragged.transform.SetParent(transform);
        }
        else{
            NewParent = CardBehaviour.ItemBeingDragged.GetComponent<CardBehaviour>().StartParent;
            ItemReference = Item;
            Item.transform.SetParent(NewParent);
            ItemReference.GetComponent<CardBehaviour>().UpdatePosition();
            CardBehaviour.ItemBeingDragged.transform.SetParent(transform);
        }
    }
}
