using UnityEngine;
using System.Collections;

public class GunControlScript : MonoBehaviour {

	RewindableObjectScript _rewindingUnit;
	
	int maxCharge = 9999;
	float charge = 9999; //10.0f;	
	float rechargeDelay = 3.0f;
	float rechargeCounter = 0.0f;
	
	float timePassed; // debug
	
	LineRenderer line;
	
	void Start () {
		line = GetComponent<LineRenderer>();
		line.enabled = false;
		line.SetWidth(0.1f, 0.1f);	
		line.SetVertexCount(2);
	}
	
	void Update() {
		if (_rewindingUnit) {
			line.enabled = true;
			line.SetPosition(0, transform.position);
			line.SetPosition(1, _rewindingUnit.transform.position);	
		} else {
			line.enabled = false;
		}
	}
	
	void FixedUpdate() {
		
		if (Input.GetMouseButton(0) && charge > Time.fixedDeltaTime) {
			if (_rewindingUnit) {
				timePassed += Time.fixedDeltaTime;				
				charge -= Time.fixedDeltaTime;				
			} else {
				Camera mainCamera = Camera.main;
				RaycastHit hit;
		        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit)) {
		        	RewindableObjectScript rewindingUnit = hit.collider.gameObject.GetComponent<RewindableObjectScript>();
					if (rewindingUnit == null) {
						if (hit.collider.transform.parent != null) {
							rewindingUnit = hit.collider.transform.parent.gameObject.GetComponent<RewindableObjectScript>();								
						}						
					}
					
					if (rewindingUnit != null) {						
						rewindingUnit.SetGlow(true);
						rewindingUnit.StartRewind();
						_rewindingUnit = rewindingUnit;						
					}
				} 		
			}
			
		} else {
			
			timePassed = 0;
			
			if (_rewindingUnit) {
				charge = (int)Mathf.Floor(charge);				
				
				_rewindingUnit.SetGlow(false);
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
		GUI.Label(new Rect(0,20,100,20), timePassed.ToString());
		GUI.Label(new Rect(0,40,100,20), rechargeCounter.ToString());
		
	}
}
