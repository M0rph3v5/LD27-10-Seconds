using UnityEngine;
using System.Collections;

public class GunControlScript : MonoBehaviour {

	RewindUnit _rewindingUnit;
	int maxCharge = 10;
	float charge = 10.0f;
	
	float rechargeDelay = 3.0f;
	float rechargeCounter = 0.0f;
	
	float timePassed;
	
	void Start () {
	
	}
	
	void FixedUpdate() {
		
		if (Input.GetMouseButton(0) && charge > Time.fixedDeltaTime) {
			if (_rewindingUnit) {
				timePassed += Time.fixedDeltaTime;
				
				charge -= Time.fixedDeltaTime;
				
			} else {
				Camera mainCamera = Camera.mainCamera;
				RaycastHit hit;
		        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit)) {
		        	RewindUnit rewindingUnit = hit.collider.gameObject.GetComponent<RewindUnit>();				
					
					if (rewindingUnit != null) {					
						Debug.Log("starting rewind");
						rewindingUnit.StartRewind();
						_rewindingUnit = rewindingUnit;
					}
				} 		
			}
			
		} else {
			
			timePassed = 0;
			
			if (_rewindingUnit) {
				Debug.Log("stopping rewind");
				Debug.Log(charge);
				charge = (int)Mathf.Floor(charge);
				Debug.Log(charge);
				_rewindingUnit.StopRewind();
				_rewindingUnit = null;
				
				rechargeCounter = 0.0f;
			} else {
				
				if (rechargeCounter >= rechargeDelay) {
					charge = Mathf.Min(Time.fixedDeltaTime + charge, maxCharge);
				} else {
					rechargeCounter += Time.fixedDeltaTime;
				}
			}
			
		}
		
    }
	
	void OnGUI() {
		
		int shownCharges = (int)Mathf.Floor(charge);
		
		GUI.Label(new Rect(0,0,100,40), shownCharges.ToString());
		GUI.Label(new Rect(0,40,100,40), timePassed.ToString());
		
	}
}
