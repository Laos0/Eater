using UnityEngine;
using System.Collections;

public class AnimCamColorFade : MonoBehaviour {

	public AnimationCurve colorCurve;
	public float speed = .4f;
	public Color startColor;
	public Color endColor;

	[HideInInspector]
	public Camera camera;
	
	// Use this for initialization
	void Start () {
		if(camera == null){
			camera = gameObject.GetComponent<Camera>();
		}
		camera.backgroundColor = startColor;
	}
	
	// Update is called once per frame
	void Update () {
		colorFadeAnimation();
	}
	
	void colorFadeAnimation(){
		camera.backgroundColor = Color.Lerp(camera.backgroundColor, endColor, colorCurve.Evaluate(speed));
	}
}
