using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject ItemBeingDragged;
    private Vector3 StartPosition;
    [HideInInspector] public Transform StartParent;
    private CanvasGroup Group;
    private float ZPosition;
    [SerializeField] private Transform DraggingParent;

    // Start is called before the first frame update
    void Start()
    {
        ZPosition = transform.position.z;
        Group = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData){
        ItemBeingDragged = gameObject;
        StartPosition = transform.position;
        StartParent = transform.parent;
        transform.SetParent(DraggingParent);
        Group.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData){
        
        #if UNITY_ANDROID
            transform.position = Input.GetTouch(0).position;
        #endif
        #if UNITY_EDITOR
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZPosition);
        #endif
    }

    public void OnEndDrag(PointerEventData eventData){
        ItemBeingDragged = null;
        if(transform.parent == DraggingParent){
            transform.SetParent(StartParent);
            transform.position = StartPosition;
        }
        else{
            transform.localPosition = Vector3.zero;
        }
        Group.blocksRaycasts = true;
    }

    public void UpdatePosition(){
        transform.localPosition = Vector3.zero;
    }
}
