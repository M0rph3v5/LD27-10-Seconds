using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static GameObject gameObj;
	int score = 0;
	int timer = 10;
	bool gameOver = false;
	
	// Use this for initialization
	void Start () {
		gameObj = gameObject;
		Object.DontDestroyOnLoad(gameObj);
		InvokeRepeating("checkTimer", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) return;
		
		if (Application.loadedLevelName == "Game") {
			Application.LoadLevel("Gameover");
		}
		
		if (Application.loadedLevelName == "Gameover") {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.Quit();
			}
			else if (Input.anyKey) {
				Application.LoadLevel("Game");
			}
		}
	}
	
	void checkTimer() {
		if (!gameOver && timer > 0) {
			timer--;
			if (timer == 0) {
				gameOver = true;
			}
		}
	}
	
	public void IncreaseScore() {
		score++;
		timer += 10;
	}
	
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 200, 50), score.ToString());
		GUI.Label (new Rect(500, 10, 200, 50), timer.ToString());
	}
}
