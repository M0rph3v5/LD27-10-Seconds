using UnityEngine;
using System.Collections;

public class SpherePickupScript : MonoBehaviour {
	
	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameManager.gameObj.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter() {
		gameManager.IncreaseScore();
		Destroy(gameObject);
	}
}
