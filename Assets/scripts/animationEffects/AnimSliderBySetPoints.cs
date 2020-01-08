using UnityEngine;
using System.Collections;

/// <summary>
/// Put this script on any gameobject to slide in and out between any two startPos and endPos vector3 points.
/// Take note that this method does not use the Update method but instead uses the Coroutine method.
/// </summary>
public class AnimSliderBySetPoints : MonoBehaviour {

	public AnimationCurve animationCurve;
	public float speed = .5f;
	public bool canAnimate = true;
	public bool canReverseOnMouseDown = false;
	[HideInInspector]
	public bool reverse = false;
	public Vector3 startPos;
	public Vector3 endPos;
	
	
	// Use this for initialization
	void Start () {
		gameObject.transform.position = startPos;	// move gameobject to position on startup
		animate();									// run the animation once at startup, if non-desire, flag off canAnimate
	}
	
	public void setStartPos(Vector3 newStartPos){
		startPos = newStartPos;
	}
	
	public void setEndPos(Vector3 newEndPos){
		endPos = newEndPos;
	}
	
	// turn on for testing purposes only
	/*void Update () {
		if(Input.GetKeyUp(KeyCode.Space)){
			animate();
		}
	}
	*/
	void OnMouseDown(){
		if(canReverseOnMouseDown){
			animate ();
		}
	}
	
	public bool animate(){
		if(canAnimate){
			canAnimate = false;
			StartCoroutine("playAnimation");
			reverse = !reverse;
			return true;
		}
		return false;
	}
	
	//when called, one of two while loop will iterate, the iteration will not stop, until the while loop is false
	IEnumerator playAnimation(){
		if(!reverse){
			while(Vector3.Distance(gameObject.transform.position, endPos) > 0.01f){
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPos, animationCurve.Evaluate(speed));
				yield return null;
			}
			// re-enable canAnimate
			// due to using the Coroutine method to animate objects
			// this helps prevent animating this gameobject multiple times
			// which if it happens, can turn into an infinite animation loop
			// thus we only turn it on, once after animation is fully complete
			canAnimate = true;
			
		}else{
		
			while(Vector3.Distance(gameObject.transform.position,startPos) > 0.01f){
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, startPos, animationCurve.Evaluate(speed));
				yield return null;
			}
			canAnimate = true;
		}
	}
}
