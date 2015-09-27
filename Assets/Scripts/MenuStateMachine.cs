using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;

public class MenuStateMachine : MonoBehaviour {

	private const string ANDROID_BACK = "Back";

	// 
	public Animator animator;
	public string startTrigger;
	
	void Awake() {
		DontDestroyOnLoad (this);

		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}

		if (!string.IsNullOrEmpty(startTrigger)) {
			animator.SetTrigger(startTrigger);
		}
	}

	void Update () {

		// Back button of android
		if (Input.GetKeyDown (KeyCode.Escape)) {
			animator.SetTrigger(ANDROID_BACK);
		}
	}
	
	public void SendEvent(string triggerName) {
		animator.SetTrigger(triggerName);

		// always reset the back event
		animator.ResetTrigger (ANDROID_BACK);
	}

	public void GetViewByName(string viewName, Action<BaseView> callback) {

		BaseView view = null;

		// find in scene
		view = FindView(viewName);

		// load async
		if (view == null) {
			StartCoroutine(LoadUIScene (viewName, callback));
		} else {
			callback(view);
		}
	}

	private IEnumerator LoadUIScene(string viewName, Action<BaseView> callback) {
		AsyncOperation async = Application.LoadLevelAdditiveAsync (viewName);
		yield return async;
		BaseView view = FindView(viewName);
		callback(view);
	}

	private BaseView FindView (string viewName) {
		BaseView view = null;
		GameObject go = GameObject.Find (viewName);
		if (go) {
			view = go.GetComponent<BaseView> (); 
		}
		return view;
	}
}