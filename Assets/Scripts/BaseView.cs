using UnityEngine;
using System.Collections;

public class BaseView : MonoBehaviour {
	
	public BaseMenuState menuState;

	public void SendEvent(string eventName) {
		menuState.SendEvent(eventName);
	}
	
	public void Close() {
		// DEMO: if we have an animator play close animation
		// should maybe be done by someone else?
		Animator tor = GetComponent<Animator>();
		if(tor != null) {
			tor.SetTrigger ("close");
		}
	}
}