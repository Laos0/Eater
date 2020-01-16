using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHead : MonoBehaviour
{
	public IntReference curentLevel;
	public Transform origin;
	public float animSpeed;

	private float rotateCount;

	private float maxTopY = -3;
	private float bottomY = -10;
	private bool moveDown = false;

    // Start is called before the first frame update
    void Start()
    {
		if(animSpeed <= 0) {
			animSpeed = .1f;
		}
	}

	public void resetPosition() {
		gameObject.transform.position = origin.position; 
		gameObject.transform.rotation = origin.rotation;
	}

	// Update is called once per frame
	void Update()
    {

		if(transform.position.y < maxTopY && !moveDown) {
			transform.Translate(0, animSpeed * Time.deltaTime, 0);
		} else if(rotateCount < 180) {
			rotateCount += animSpeed;
			if(rotateCount >= 180) {
				moveDown = true;
			}
			transform.Rotate(Vector3.up, -animSpeed);
			//transform.rotation = Quaternion.Lerp(origin.rotation, rotateTo.rotation, Time.deltaTime * animSpeed);
		} else if(transform.position.y > -24 && moveDown) {
			Debug.Log("moveing down");
			transform.Translate(0, -animSpeed * Time.deltaTime, 0);
		}
	}

	private void moveToY(float val) {
		//Vector3 up = new Vector3(0, 5, 0);
		Vector3 old = transform.position;
		//Vector3 newPos = transform.position + up;
		transform.position.Set(old.x, val, old.z);
	}
}
