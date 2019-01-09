using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    // PUBLIC ATTRIBUTES
	public Dialogue Dialogue;

    // PRIVATE ATTRIBUTES
    private DialogueManager Manager;

    public void Start()
    {
        Manager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue ()
	{
		Manager.StartDialogue(Dialogue);
	}

}
