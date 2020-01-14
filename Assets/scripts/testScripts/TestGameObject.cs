using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGameObject : MonoBehaviour
{
    public FloatReference hp;
    public FloatReference hpMax;
    public Image hpBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//transform.position.Set(hp.Value, 0, 0);
		//gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * hp.Value);
		//transform.position = new Vector3(hp.Value, 0, 0);

		if (Input.GetKey(KeyCode.A)) {
			transform.Translate(Vector3.left * Time.deltaTime * 4, Space.Self); //LEFT
		}
	
		if (Input.GetKey(KeyCode.D)) {
			transform.Translate(Vector3.right * Time.deltaTime * 4, Space.Self); //RIGHT
		}

		// hp bar reaction test
		hpBar.fillAmount = Mathf.Clamp01(hp.Value / hpMax.Value);

        if(Input.GetKeyUp(KeyCode.Space))
        {
            resetPosition();
        }

    }

	/// <summary>
	/// For trigger to work, only one gameObject needs turn on isTrigger. Both GO can be set to isTrigger as well.
	/// </summary>
	/// <param name="col">Col.</param>
	//private void OnTriggerEnter(Collider col) {
	//	Debug.LogError("Colliding trigger item");
	//	if (col.gameObject.name.Equals("item")) {
	//		Debug.LogError("Colliding with item");
	//	}
	//}

	/// <summary>
	/// For collision to work, both items should not have isTrigger enabled for their boxCollider
	/// But one or both must have a rigidBody attached.
	/// </summary>
	/// <param name="col">Col.</param>
	private void OnCollisionEnter(Collision col) {
		Debug.LogError("collision checking");
		if (col.gameObject.tag.Equals("item")) {
			Debug.LogError("Collision success with item");
		}
	}


	private void resetPosition()
    {
        gameObject.GetComponent<Rigidbody>().velocity.Set(0, 0, 0);
        gameObject.transform.position = new Vector3();
    }
}
