using UnityEngine;
using System.Collections;

public class AnimRotateCustom : MonoBehaviour {

	public float slideSpeed = .4f;
	
	public float rotateSpeed = .4f;
	public float rotateAngle = 180f;
	public AnimationCurve rotateCurve = new AnimationCurve();
	
	public bool canRotate = false;
	public string direction = "";
	public Vector3 customDirection;
	
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
		if(customDirection == new Vector3(0,0,0)){
			customDirection = Vector3.forward;
		}
		//gameObject.renderer.material.color = startColor;
	}
	
	// Update is called once per frame
	void Update () {

		if(canRotate)
			rotate();
		
		/*	
		if(canColor)
			colorTransition ();
		*/
	}
	
	void rotate(){
		//gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.AngleAxis(180, Vector3.up), rotateCurve.Evaluate(rotateSpeed));
		gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.AngleAxis(180, customDirection), rotateCurve.Evaluate(rotateSpeed));
	}
	
	/*
	void colorTransition(){
		gameObject.renderer.material.color = Color.Lerp(gameObject.renderer.material.color, endColor, colorCurve.Evaluate(colorSpeed));
	}
	*/
}
