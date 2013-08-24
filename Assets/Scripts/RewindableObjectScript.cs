using UnityEngine;
using System.Collections;

public class RewindableObjectScript : RewindUnit {
	
	public bool collection = false;
	public bool _glow = false;
	
	// Use this for initialization
	public override void Start () {
		base.Start();
		
		// if mesh renderer 
		if (renderer != null) {
			renderer.material.SetColor("_Color", new Color(0.85f,0.11f,0.11f,0));	
		} else { // am I a collection ?
			foreach (Transform to in transform) {
				to.gameObject.renderer.material.SetColor("_Color", new Color(0.85f,0.11f,0.11f,0));
			}
		}
		
	}
	
	public void SetGlow (bool glow) {
		_glow = glow;		
		
		if (renderer != null) {			
			Color originalColor = renderer.material.color;
			renderer.material.SetColor("_Color", new Color(originalColor.r,originalColor.g,originalColor.b,glow ? 0.5f : 0));
		} else {
			foreach (Transform to in transform) {
				Color originalColor = to.renderer.material.color;
				to.renderer.material.SetColor("_Color", new Color(originalColor.r,originalColor.g,originalColor.b,glow ? 0.5f : 0));	
			}
		}				
	}
}
