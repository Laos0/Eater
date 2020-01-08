using UnityEngine;
using System.Collections;

/// <summary>
/// This will allow you to change the color of a game object at startup, assuming the gameobject has a proper material
/// The object will continue to use the same material except the color will change.
/// </summary>
public class AnimColorSwitchStatic : MonoBehaviour {

	public Color startColor;
	public bool canSwitchColorOnStart = false;
	
	// only turn on for runtime testing purposes
	public bool testingOn;	

	// change color at startup
	void Start () {
		if(canSwitchColorOnStart)
			switchColor(startColor);
	}
	
	// allow you to change color at runtime if needed
	public void switchColor(Color newColor){
		gameObject.GetComponent<Renderer>().material.color = newColor;
	}
	
	// for runtime testing use only
	// turn on CanTestColor in editor and change the startColor to see the changes during runtime
	void Update(){
		if(testingOn){
			switchColor(startColor);
		}
	}

}
