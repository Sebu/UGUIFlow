using UnityEngine;
using System.Collections;

public class BaseView : MonoBehaviour {


	public Animator menuStateMachine;

	public void Trigger(string triggerName) {
		menuStateMachine.SetTrigger (triggerName);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
