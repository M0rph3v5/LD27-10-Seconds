using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StairScript : RewindableScript {
	
	List<GameObject> stairPieces;
	
	void Start () {
		stairPieces = new List<GameObject>();
		
		for(int i = 0; i < transform.childCount; i++) {
			stairPieces.Add((GameObject)transform.GetChild(i).gameObject);
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
