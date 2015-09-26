using UnityEngine;
using System.Collections;
using System;

public class BaseMenuState : StateMachineBehaviour {

	public string sceneName;
	public string viewName;
	public BaseView view;

	private MenuStateMachine menuStateMachine;

	public void SendEvent(string eventName) {
		// TODO: analyse eventName and do stuff

		menuStateMachine.SendEvent(eventName);
	}

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		// this transition is going to a new scene
		if (!string.IsNullOrEmpty(sceneName) && Application.loadedLevelName != sceneName) {
			Application.LoadLevel(sceneName);
		}


		menuStateMachine = animator.GetComponent<MenuStateMachine>();
		menuStateMachine.AttachViewToMenuState(this);

	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//		view.Close ();
	}
}