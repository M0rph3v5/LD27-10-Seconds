using UnityEngine;
using System.Collections;

public class CollisionSwitch : MonoBehaviour {
	
	public BridgeScript bridge;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerExit(Collider other) {
		bridge.StartDestruction();
	}
}
