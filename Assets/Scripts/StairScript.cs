using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;
using System.Linq;

public class StairScript : RewindableScript {
	
	List<GameObject> stairPieces;
	List<Tweener> stairPieceTween;
	
	void Start () {
		stairPieces = new List<GameObject>();
		stairPieceTween = new List<Tweener>();
		
		TweenParms parms = new TweenParms();
		parms.Ease(EaseType.EaseInOutExpo);
		parms.Loops(-1,LoopType.Yoyo);
		
		int i = 0;
		foreach(Transform child in transform.Cast<Transform>().OrderBy(t=>t.position.y).Reverse()) {
			GameObject gameObject = child.gameObject;
			stairPieces.Add(gameObject);
		
			parms.Prop("position", gameObject.transform.position + new Vector3(-5, 0, 0));			
			parms.Delay(i*0.2f);			
			Tweener tweener = HOTween.To(gameObject.transform, 1, parms);
			stairPieceTween.Add(tweener);
			i++;
		}
	}
	
	void Update () {
		
	}
	
	public override void WillStopRewinding () 	{
		base.WillStopRewinding ();
		
		foreach (Tweener tr in stairPieceTween) {
			tr.Play();	
		}
	}
	
	public override void WillStartRewinding () 	{
		base.WillStartRewinding ();
		
		foreach (Tweener tr in stairPieceTween) {
			tr.Pause();	
		}
	}
}
