using UnityEngine;
using System.Collections;

public class AnimRotateSimple : MonoBehaviour {
	
	public float speed = 10f;
	public bool canRotate = false;
	public bool reverse = false;
	private int direction = 1;
	
	public bool rotateX;
	public bool rotateY;
	public bool rotateZ;
	
	void Awake(){
		if(reverse)
			direction *= -1;
	}
	
	void OnMouseDown(){
		canRotate = !canRotate;
	}
	
	// Update is called once per frame
	void Update () {
		if(canRotate){
			
			if(rotateX)
				gameObject.transform.Rotate(new Vector3(0,direction,0) * Time.deltaTime * speed);
			if(rotateY)
				gameObject.transform.Rotate(new Vector3(0,0,direction) * Time.deltaTime * speed);
			if(rotateZ)
				gameObject.transform.Rotate(new Vector3(direction,0,0) * Time.deltaTime * speed);
			
		}
	}
}
