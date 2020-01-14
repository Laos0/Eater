using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for item falling.
/// To disable, change speed to 0.
/// </summary>
public class PositionTranslate : MonoBehaviour
{
	public float speed;

	void Start() {

	}

	// Start is called before the first frame update
	public void activate(float speed) {
		this.speed = speed;
	}

    // Update is called once per frame
    void Update()
    {
		transform.Translate(0, -this.speed * Time.deltaTime, 0, Space.World);
    }
}
