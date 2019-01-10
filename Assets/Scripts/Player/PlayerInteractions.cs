using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private FloatingJoystick Joystick = null;

    // Start is called before the first frame update
    void Awake()
    {

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
