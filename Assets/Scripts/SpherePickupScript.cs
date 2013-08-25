using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class SpherePickupScript : MonoBehaviour {
	
	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		GameObject gameObj = GameManager.gameObj;
		if (gameObj != null)
			gameManager = gameObj.GetComponent<GameManager>();
		
		HOTween.To (transform, 2.5f, 
			new TweenParms().Prop("position", transform.position + new Vector3(0, 0.2f, 0))
				.Loops(-1, LoopType.Yoyo).Ease (EaseType.EaseInOutSine));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter() {
		gameManager.IncreaseScore();
		Destroy(gameObject);
	}
}
