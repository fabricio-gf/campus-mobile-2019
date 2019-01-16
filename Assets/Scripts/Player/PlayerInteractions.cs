using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    //[SerializeField]
    private FloatingJoystick Joystick = null;

    private int InteractableLayerIndex;

    // Start is called before the first frame update
    void Awake()
    {
        Joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FloatingJoystick>();

        InteractableLayerIndex = LayerMask.GetMask("Interactable");
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Interact();
        }

#if UNITY_ANDROID
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Interact();
        }
#endif
    }

    private void Interact()
    {
        // send raycast forward
        Debug.DrawRay(transform.position, transform.up, Color.green, 2f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1f, InteractableLayerIndex);
        // if touches interactable, trigger dialogue
        if (hit)
        {
            Joystick.BlockMovement();
            hit.transform.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dialogue"))
        {
            Joystick.BlockMovement();
            collision.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        
    }
}
