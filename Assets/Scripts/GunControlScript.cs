using UnityEngine;
using System.Collections;

public class GunControlScript : MonoBehaviour {

	RewindUnit _rewindingUnit;
	
	void Start () {
	
	}
	
	void FixedUpdate() {
		
		if (Input.GetMouseButton(0)) {
			Camera mainCamera = Camera.mainCamera;
			RaycastHit hit;
	        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit)) {
	        	RewindUnit rewindingUnit = hit.collider.gameObject.GetComponent<RewindUnit>();
				Debug.DrawLine(mainCamera.transform.position, hit.point);				
				if (rewindingUnit == _rewindingUnit)
					return;
				
				if (rewindingUnit != null) {					
					Debug.Log("starting rewind");
					rewindingUnit.StartRewind();
					_rewindingUnit = rewindingUnit;
				}  
			} else {
				
			}	
		} else {
			if (_rewindingUnit) {
				Debug.Log("stopping rewind");
				_rewindingUnit.StopRewind();
				_rewindingUnit = null;
			}
		}
		
    }
}
