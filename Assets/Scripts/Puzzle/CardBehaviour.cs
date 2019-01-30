using UnityEngine;
using UnityEngine.EventSystems;

public class CardBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    // PUBLIC ATTRIBUTES
    [HideInInspector] public Transform StartParent;
    [HideInInspector] public char CardValue;
    
    // PRIVATE ATTRIBUTES
    private Vector3 StartPosition;
    private CanvasGroup Group;
    private float ZPosition;

    // PRIVATE REFERENCES
    [Header("References")]
    [SerializeField] private Transform DraggingParent;

    // Start is called before the first frame update
    void Start()
    {
        ZPosition = transform.position.z;
        Group = GetComponent<CanvasGroup>();
        DraggingParent = GameObject.FindGameObjectWithTag("Drag").transform;
    }

    public void OnBeginDrag(PointerEventData eventData){
        PuzzleReferee.ItemBeingDragged = gameObject;
        StartPosition = transform.position;
        StartParent = transform.parent;
        transform.SetParent(DraggingParent);
        Group.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
#if UNITY_ANDROID
        transform.position = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, ZPosition);
#endif
#if UNITY_EDITOR
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZPosition);
#endif
    }

    public void OnEndDrag(PointerEventData eventData){
        PuzzleReferee.ItemBeingDragged = null;
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

    public void SetCardSize(int caseNumber, int cardType)
    {
        if (cardType == 0)
        {
            switch (caseNumber)
            {
                case 1:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
        else if (cardType == 1)
        {
            switch (caseNumber)
            {
                case 1:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
    }
}
