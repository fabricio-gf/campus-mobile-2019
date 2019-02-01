using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //[SerializeField]
    private FloatingJoystick Joystick = null;

    private int InteractableLayerIndex;

    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Awake()
    {
        Joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FloatingJoystick>();

        InteractableLayerIndex = LayerMask.GetMask("Interactable");

        playerMovement = GetComponent<PlayerMovement>();
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
        Vector2 raycastDirection;
        switch (playerMovement.FacingDirection)
        {
            case PlayerMovement.Directions.UP:
                raycastDirection = new Vector2(0, 1);
                break;
            case PlayerMovement.Directions.RIGHT:
                raycastDirection = new Vector2(1,0);
                break;
            case PlayerMovement.Directions.DOWN:
                raycastDirection = new Vector2(0,-1);
                break;
            case PlayerMovement.Directions.LEFT:
                raycastDirection = new Vector2(-1, 0);
                break;
            default:
                raycastDirection = new Vector2(0, 0);
                break;
        }
        // send raycast forward
        Debug.DrawRay(transform.position, raycastDirection, Color.green, 2f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, 1f, InteractableLayerIndex);
        // if touches interactable, trigger dialogue
        if (hit)
        {
            Transform tr = hit.transform;
            if (tr.CompareTag("Dialogue"))
            {
                Joystick.BlockMovement();
                tr.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
            if (tr.CompareTag("Codex") || tr.CompareTag("Puzzle"))
            {
                playerMovement.FacingDirection = PlayerMovement.Directions.NONE;
                Joystick.BlockMovement();
                //collision.GetComponent<CodexInteractable>().Interact();
                tr.GetComponent<Interactable>().Interact();
            }
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
