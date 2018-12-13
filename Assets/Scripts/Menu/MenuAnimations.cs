using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MenuAnimations : MonoBehaviour {

	private Animator animator;

	void Awake () {
		animator = GetComponent<Animator>();		
	}

	public void TriggerAnimation(string trigger){
		animator.SetTrigger(trigger);
	}
}
