using UnityEngine;
using System.Collections;

public class AnimSpin : MonoBehaviour {

	public float spinSpeed;
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(new Vector3(0,spinSpeed * Time.deltaTime, 0));
	}
}
