using UnityEngine;
using System.Collections;

/// <summary>
/// <para>This script allows a game object to slide in and out at will without having to wait for a complete animation. </para>
/// <para></para>
/// <para>In other words, a reverse slide can take place at anytime overwriting the current animation without problem</para>
/// <para> </para>
/// <para>The method does not use a coroutine method like in the SlideInOut script</para>
/// </summary>
public class AnimSlideInTest : MonoBehaviour {

	public float slideSpeed = .4f;
	public AnimationCurve slideCurve = new AnimationCurve();
	public bool canSlide = false;
	public Vector3 startPosition;
	public Vector3 endPosition;

	private bool isSlideComplete = false;
	
	/*
	public float colorSpeed = .4f;
	public AnimationCurve colorCurve = new AnimationCurve();
	public Color startColor;
	public Color endColor;
	public bool canColor = false;
	*/
	
	// Use this for initialization
	void Start () {
		gameObject.transform.position = startPosition;
		
		//gameObject.renderer.material.color = startColor;
	}
	
	// Update is called once per frame
	void Update () {
		if(canSlide)
			slideTransition();

		/*	
		if(canColor)
			colorTransition ();
		*/
	}
	
	void slideTransition(){
		if( ! (Vector3.Distance( gameObject.transform.position, endPosition) <= .01f) ) {
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPosition, slideCurve.Evaluate(slideSpeed));
		}else{
			canSlide = false;
		}
		
	}
	
	
	/*
	void colorTransition(){
		gameObject.renderer.material.color = Color.Lerp(gameObject.renderer.material.color, endColor, colorCurve.Evaluate(colorSpeed));
	}
	*/
}
