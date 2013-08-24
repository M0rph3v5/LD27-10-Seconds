using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class StairScript : RewindableScript {
	
	List<GameObject> stairPieces;
	
	void Start () {
		stairPieces = new List<GameObject>();
		
		TweenParms parms = new TweenParms();
		
		
		for(int i = 0; i < transform.childCount; i++) {
			GameObject gameObject = transform.GetChild(i).gameObject;
			stairPieces.Add(gameObject);
		
			//parms.Prop("position", gameObject.transform + new Vector3(50, 0, 0));
			//HOTween.To(gameObject.transform, 5, parms);
		}
		
		
	}
	
	void Update () {
		
	}
	
	public override void WillStopRewinding () 	{
		base.WillStopRewinding ();
		
	}
	
	public override void WillStartRewinding () 	{
		base.WillStartRewinding ();
		
	}
}
