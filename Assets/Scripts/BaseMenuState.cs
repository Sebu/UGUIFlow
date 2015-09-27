using UnityEngine;
using System.Collections;
using System;

public class BaseMenuState : StateMachineBehaviour {

	public string sceneName;
	public string viewName;

	private BaseView view;
	private MenuStateMachine menuStateMachine;

	public void SendEvent(string eventName) {
		// TODO: analyse eventName and do stuff
		menuStateMachine.SendEvent(eventName);
	}

	public void OnEnter() {

	}

	public void OnExit() {

	}

#region internal 
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