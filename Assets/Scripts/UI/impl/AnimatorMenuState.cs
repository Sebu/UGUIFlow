using UnityEngine;
using System.Collections;
using System;

public class AnimatorMenuState : StateMachineBehaviour {
	
	public string sceneName;
	public string viewName;
		
	private IView _view;
	private AnimatorMenuStateMachine _menuStateMachine;
	
	
		
	#region internal 
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		_menuStateMachine = animator.GetComponent<AnimatorMenuStateMachine>();

		// this transition is going to a new scene
		if (!string.IsNullOrEmpty(sceneName) && Application.loadedLevelName != sceneName) {
			_menuStateMachine.FindNamedLevel(sceneName, OnLevelLoaded);
		} else {
			LoadView();
		}
		
	}

	private void OnLevelLoaded(GameObject levelRoot)
	{
		LoadView();
	}

	private void LoadView()
	{
		_menuStateMachine.FindNamedLevel(viewName, OnStateEnterAsync);
	}

	private void OnStateEnterAsync(GameObject levelRoot)
	{
		_view = levelRoot.GetComponent<IView>();
		Debug.Log("View:" + _view + "Did Appear");
		_view.DidAppear();
	}
	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(_view != null)
		{
			_view.DidDisappear();
		}
	}
	#endregion
}