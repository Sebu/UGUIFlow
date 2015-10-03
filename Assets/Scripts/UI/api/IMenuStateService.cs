using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public interface IMenuStateService {
	
	void SetTrigger(string trigger);

	void SetInfo(Dictionary<string, object> info);
}
