using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private static GameObject ItemBeingDragged;
    private Vector3 StartPosition;
    private float ZPosition;

    // Start is called before the first frame update
    void Start()
    {
        ZPosition = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData){
        ItemBeingDragged = gameObject;
        StartPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData){
        
        #if UNITY_ANDROID
            transform.position = Input.GetTouch(0).position;
        #endif
        #if UNITY_EDITOR
            print(Input.mousePosition);
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZPosition);
        #endif
    }

    public void OnEndDrag(PointerEventData eventData){
        ItemBeingDragged = null;
        transform.position = StartPosition;
    }
}
