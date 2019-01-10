using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FloatingJoystick : Joystick
{
    Vector2 joystickCenter = Vector2.zero;

    private bool CanMove = true;
    private Image JoystickImage = null;

    private void Awake()
    {
        JoystickImage = GetComponent<Image>();    
    }

    void Start()
    {
        background.gameObject.SetActive(false);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (CanMove)
        {
            Vector2 direction = eventData.position - joystickCenter;
            inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
            ClampJoystick();
            handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (CanMove)
        {
            background.gameObject.SetActive(true);
            background.position = eventData.position;
            handle.anchoredPosition = Vector2.zero;
            joystickCenter = eventData.position;
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (CanMove)
        {
            background.gameObject.SetActive(false);
            inputVector = Vector2.zero;
        }
    }

    public void BlockMovement()
    {
        CanMove = false;
        JoystickImage.raycastTarget = false;

        background.gameObject.SetActive(false);
        inputVector = Vector2.zero;
    }

    public void ResumeMovement()
    {
        JoystickImage.raycastTarget = true;
        CanMove = true;
    }
}