using UnityEngine;
using System.Collections;
using System;

public class PopupView : StateMachineBehaviour {

	public string viewName;
	private GameObject view;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		view = GameObject.Find (viewName);

		if (view == null) {
			Application.LoadLevelAdditive(viewName);
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (view == null) {
			view = GameObject.Find (viewName);
//			view.transform.SetParent(animator.gameObject.transform, false);
			view.GetComponent<BaseView>().menuStateMachine = animator;
		}
	
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Animator tor = view.GetComponent<Animator>();
	
		if(tor != null) {
			tor.SetTrigger ("close");
		}
		//view.SetActive (false);
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
