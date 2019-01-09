using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    // PRIVATE REFERENCES
    [Header("References")]
	[SerializeField] private Text nameText = null;
	[SerializeField] private Text dialogueText = null;

	[SerializeField] private Animator animator = null;

    // PRIVATE ATTRIBUTES
	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		animator.SetBool("IsOpen", false);
	}

	public void StartDialogue (Dialogue dialogue)
	{
        // trigger animation
		animator.SetBool("IsOpen", true);

        // set the name of the person speaking
		nameText.text = dialogue.name;

        // clear leftover sentences
		sentences.Clear();

        // enqueues new sentences
		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

        // call method for displaying the first sentence
		DisplayNextSentence();
	}

    /// <summary>
    /// Method that displays the next sentence in the Queue
    /// </summary>
	public void DisplayNextSentence ()
	{
        // checks if there are no more sentences. if there aren't, end the dialogue
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

        // dequeues the next sentence 
		string sentence = sentences.Dequeue();

        // stop the previous coroutine for showing the text, and calls the next one
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

    /// <summary>
    /// Coroutine for printing each letter of the sentence no the dialogue box
    /// </summary>
    /// <param name="sentence">The sentence that must be shown in the dialogue box</param>
    /// <returns></returns>
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

    /// <summary>
    /// Method that ends the dialogue, closing the dialogue box
    /// </summary>
	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}
}
