using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;


[RequireComponent(typeof(Animator))]
public class AnimatorMenuStateMachine : MonoBehaviour, IMenuStateService
{

	private const string ANDROID_BACK = "Back";

	// 
	private Animator _animator;
	public string StartTrigger;

	public static AnimatorMenuStateMachine Instance;


	//TODO: use singleton Template
	void Awake() 
	{
		DontDestroyOnLoad (this);

		if (Instance == null)
		{
			Instance = this;
			_animator = GetComponent<Animator>();
			
			if (!string.IsNullOrEmpty(StartTrigger))
			{
				_animator.SetTrigger(StartTrigger);
				_animator.enabled = true;
			}
		} 
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

	}

	void Update () 
	{
		// Back button of android
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			SetTrigger(ANDROID_BACK);
		}
	}
	
	public void SetTrigger(string triggerName) 
	{
		_animator.SetTrigger(triggerName);
	}

	public void SetInfo(Dictionary<string, object> info)
	{

	}

	#region nice async load find cache 
	public void FindNamedLevel(string name, Action<GameObject> callback) 
	{

		GameObject go = null;

		// find in scene
		go = GameObject.Find(name);

		// load async
		if (go == null) 
		{
			StartCoroutine(LoadUIScene (name, callback));
		} 
		else 
		{
			callback(go);
		}
	}

	private IEnumerator LoadUIScene(string name, Action<GameObject> callback)
	{
		AsyncOperation async = Application.LoadLevelAdditiveAsync (name);
		yield return async;
		callback(GameObject.Find(name));
	}
	#endregion
}