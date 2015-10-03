using UnityEngine;
using System.Collections;

public class BaseView : MonoBehaviour, IView {

	private IMenuStateService _menuStateService;
	private Animator _animator;

	void Awake()
	{
		//inject
		_menuStateService = AnimatorMenuStateMachine.Instance;
		_animator = GetComponent<Animator>();
	}


	public void SetTrigger(string eventName) 
	{
		_menuStateService.SetTrigger(eventName);
	}

	public void DidAppear()
	{

	}

	public void DidDisappear()
	{

	}

	public void Close () 
	{
		if(_animator != null) 
		{
			_animator.SetTrigger("close");
		}
	}
}