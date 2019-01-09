using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MenuAnimations : MonoBehaviour {

    // PRIVATE ATTRIBUTES
	private Animator animator = null;

	void Awake () {
		animator = GetComponent<Animator>();		
	}

	public void TriggerAnimation(string trigger){
		animator.SetTrigger(trigger);
	}
}
