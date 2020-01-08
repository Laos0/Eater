using UnityEngine;
using System.Collections;

/// <summary>
/// Animation color change but only works on GameObjects with a render material
/// </summary>
public class AnimColorSwitchOnHover : MonoBehaviour {

	public Color startColor;
	public Color endColor;
	
	public bool canChangeColor;
	private bool isColor1;
	
	public float speed;
	public AnimationCurve animationCurve;
	
	private bool mouseEnter;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = startColor;
	}
	
	// Update is called once per frame
	void Update () {
		if(canChangeColor & mouseEnter)
			gameObject.GetComponent<Renderer>().material.color = Color.Lerp(gameObject.GetComponent<Renderer>().material.color, endColor, animationCurve.Evaluate(speed));
		else if(canChangeColor & !mouseEnter)
			gameObject.GetComponent<Renderer>().material.color = Color.Lerp(gameObject.GetComponent<Renderer>().material.color, startColor, animationCurve.Evaluate(speed));
	}
	
	void OnMouseEnter(){
		mouseEnter = true;
		//Debug.Log("enter");
	}
	
	void OnMouseExit(){
		mouseEnter = false;
		//Debug.Log("exit");
	}
	
	
}
