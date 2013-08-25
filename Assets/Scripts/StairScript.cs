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
		
			parms.Prop("localPosition", gameObject.transform.localPosition + new Vector3(-5, 0, 0));			
			parms.Delay(i*0.2f);			
			Tweener tweener = HOTween.To(gameObject.transform, 1, parms);
			stairPieceTween.Add(tweener);
			i++;
		}
	}
	
	public override void WillStopRewinding (float elapsedTime) 	{
		base.WillStopRewinding (elapsedTime);
		
		foreach (Tweener tr in stairPieceTween) {			
			float modifiedByElapsedTime = (tr.isLoopingBack ? tr.elapsed+tr.duration : tr.elapsed )  - elapsedTime;
			while (modifiedByElapsedTime < 0) {
				modifiedByElapsedTime = (tr.duration*2) + modifiedByElapsedTime; // duration excludes looptypes
			}
			
			tr.GoToAndPlay(modifiedByElapsedTime);
		}
	}
	
	public override void WillStartRewinding () 	{
		base.WillStartRewinding ();
		
		foreach (Tweener tr in stairPieceTween) {
			tr.Pause();	
		}
	}
}
