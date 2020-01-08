using UnityEngine;
using System.Collections;

/** Note: Not fully working yet */
public class Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("hello");
	}
	
	//one way to get destroy
	void OnMouseDown(){
		//TODO GameManager +1 point
		//GameManager.instance.updatePointsRemaining(-1);
		explode();
		destroyMe();
	}
	
	/*
	void OnCollisionEnter(Collision col){
		Debug.Log("hit no wall");
		if(col.gameObject.name == "wall"){
			Debug.Log("hit");
			//TODO Gamemanager minu 1 point
			destroyMe();
		}
	}
	*/
	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "wall"){
			//TODO Gamemanager minus 1 point
			//Debug.Log("wall hit");
			destroyMe();
		}
	}
	
	
	public void destroyMe(){

		 //add sdcore to database

		Destroy(this.gameObject);
	}
	
	//explosion effect
	private void explode(){
		Instantiate(Resources.Load("Prefabs/Explosion1"),this.transform.position, Quaternion.identity);
	}
}
