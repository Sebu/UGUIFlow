using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MenuStateMachine : MonoBehaviour {

	private const string ANDROID_BACK = "back";
	// 
	public Animator animator;

	private Dictionary<string, BaseView> viewByNameCache;

	void Awake() {
		DontDestroyOnLoad (this);

		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
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
	
	public void AttachViewToMenuState(BaseMenuState menuState) {

		GameObject go;
		// lookup cache
//		menuState.view = viewByNameCache [menuState.viewName];

		// find in scene
		if (menuState.view == null) {
			go = GameObject.Find(menuState.viewName);
			if (go) {
				menuState.view = go.GetComponent<BaseView>(); 
			}
		}

		// load async
		if (menuState.view == null) {
			StartCoroutine(LoadUIScene (menuState));
		} else {
			menuState.view.menuState = menuState;
		}
	}


	private IEnumerator LoadUIScene(BaseMenuState menuState) {
		AsyncOperation async = Application.LoadLevelAdditiveAsync (menuState.viewName);
		yield return async;
		menuState.view = GameObject.Find (menuState.viewName).GetComponent<BaseView>();
		menuState.view.menuState = menuState;
	}

}
