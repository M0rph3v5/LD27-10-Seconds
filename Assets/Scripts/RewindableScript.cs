using UnityEngine;
using System.Collections;

public class RewindableScript : MonoBehaviour {
	
	public bool isRewinding = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public virtual void WillStartRewinding () { // do your stuff to prepare for this
		Debug.Log("willstart rewidnngin");
		isRewinding = true;
	}
	
	public virtual void WillStopRewinding () { // resume whatever you had running
		isRewinding = false;
	}

}
