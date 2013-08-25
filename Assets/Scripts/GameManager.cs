using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static GameObject gameObj;
	public static int score = 0;
	public static int timer = 10;
	public static int totalTimer = 0;
	public static bool gameOver = false;
	
	// Use this for initialization
	void Start () {
		gameObj = gameObject;
		initGame();
	}
	
	void initGame() {
		score = 0;
		timer = 10;
		totalTimer = timer;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
			return;
		}
		
		if (gameOver)
			Application.LoadLevel("Gameover");
	}
	
	float timeElapsed = 0.0f;
	
	void FixedUpdate() {
		timeElapsed += Time.deltaTime;
		
		if (!gameOver && timeElapsed > 1.0f) {
			checkTimer();
			timeElapsed = 0.0f;
		}
	}
	
	void resetGame() {
		Application.LoadLevel("Game");
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
		totalTimer += 10;
	}
}
