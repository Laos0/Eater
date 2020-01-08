using UnityEngine;
using System.Collections;

public class AnimCameraPan : MonoBehaviour {

	public Vector3 startPos;
	public Vector3 endPos;
	public float speed = 0.4f;
	
	public AnimationCurve animCurve;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = startPos;
		animate (endPos);
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPos, animCurve.Evaluate(speed));
		//gameObject.transform.Translate(new Vector3(0,1,0) * Time.deltaTime * .5f);
	}

	public void animate(Vector3 endPos){
		this.endPos = endPos;
		StartCoroutine("playAnimation");
	}

	IEnumerator playAnimation(){
		while(Vector3.Distance(gameObject.transform.position, endPos) > 0.01f){
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPos, animCurve.Evaluate(speed));
			yield return null;
		}

	}
}
