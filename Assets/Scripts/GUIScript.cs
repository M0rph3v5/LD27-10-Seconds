using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	
	public GUIText finalScore = null;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "Gameover") {
			if (Input.anyKey) {
				Application.LoadLevel("Game");
			}
		}
		
		if (finalScore != null)
			finalScore.text = "Score: " + GameManager.score.ToString();
	}
	
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 200, 50), "Score: " + GameManager.score.ToString());
		GUI.Label (new Rect(500, 10, 200, 50), "Remaining time: " + GameManager.timer.ToString());
		GUI.Label (new Rect(500, 40, 200, 50), "Longest survival: " + GameManager.totalTimer.ToString());
	}
}
