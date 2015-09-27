using UnityEngine;
using System.Collections;
using System;

public class BaseMenuState : StateMachineBehaviour {

	public string sceneName;
	public string viewName;
	public string eventOnExit;

	private BaseView view;
	private MenuStateMachine menuStateMachine;

	
	bool OnEvent() {
		return true;
	}

	void OnEnter() {
	}

	void OnExit() {
	}

#region internal 
	public void SendEvent(string eventName) {
		if (OnEvent()) {
			if (eventName != "Back" && !string.IsNullOrEmpty(eventOnExit)) {
				menuStateMachine.SendEvent(eventOnExit);
			}
			menuStateMachine.SendEvent(eventName);
		}
	}


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		// this transition is going to a new scene
		if (!string.IsNullOrEmpty(sceneName) && Application.loadedLevelName != sceneName) {
			Application.LoadLevel(sceneName);
		}

		menuStateMachine = animator.GetComponent<MenuStateMachine>();
		menuStateMachine.GetViewByName(this.viewName, OnAttach);
	}

	private void OnAttach(BaseView viewInScene) {
		view = viewInScene;
		view.menuState = this;
		OnEnter();
	}
	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		OnExit ();
	}
#endregion
}