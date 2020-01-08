using UnityEngine;
using System.Collections;

public class AnimMoveRotateColor : MonoBehaviour {
	
	public float slideSpeed = .4f;
	public AnimationCurve slideCurve = new AnimationCurve();
	public bool canSlide = false;
	public Vector3 startPosition;
	public Vector3 endPosition;
	
	public float rotateSpeed = .4f;
	public AnimationCurve rotateCurve = new AnimationCurve();
	public bool canRotate = false;
	
	public float colorSpeed = .4f;
	public AnimationCurve colorCurve = new AnimationCurve();
	public Color startColor;
	public Color endColor;
	public bool canColor = false;
	
	// Use this for initialization
	void Start () {
		gameObject.transform.position = startPosition;
		
		gameObject.GetComponent<TextMesh>().color = startColor;
	}
	
	// Update is called once per frame
	void Update () {
		if(canSlide)
			slideTransition();
		
		if(canRotate)
			rotateTransition();
		
		if(canColor)
			colorTransition ();
		
	}
	
	void slideTransition(){
		gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPosition, slideCurve.Evaluate(slideSpeed));
	}
	
	void rotateTransition(){
		gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.AngleAxis(180, Vector3.up), rotateCurve.Evaluate(rotateSpeed));
	}
	
	void colorTransition(){
		gameObject.GetComponent<Renderer>().material.color = Color.Lerp(gameObject.GetComponent<Renderer>().material.color, endColor, colorCurve.Evaluate(colorSpeed));
	}
}