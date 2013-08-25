using UnityEngine;
using System.Collections;

public class RotateScript : RewindableScript {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (base.isRewinding) {
			return;
		}
		
		//transform.RotateAround(transform.position, Time.deltaTime * 20.0f);
		transform.Rotate(0, Time.deltaTime * 20.0f, 0, Space.World);
	}
	
	public override void WillStopRewinding (float elapsedTime) 	{
		base.WillStopRewinding (elapsedTime);		
	}
	
	public override void WillStartRewinding () 	{
		base.WillStartRewinding ();
		
	}
}
