using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using System.Linq;

public class BridgeScript : MonoBehaviour {
	
	public void StartDestruction () {
		int i = 0;
		foreach(Transform child in transform.Cast<Transform>().OrderBy(t=>t.position.x).Reverse()) {
			HOTween.To(child, 0, new TweenParms().Prop("position", child.position).Delay(i * 0.005f).OnComplete(wakeUp, i));
			
			i++;
		}
	}
	
	void wakeUp(TweenEvent data) {		
		int i = (int)data.parms[0];
		transform.GetChild(i).rigidbody.isKinematic = false;
		transform.GetChild(i).rigidbody.WakeUp();
	}
}