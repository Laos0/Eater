using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroy prefab when it collides with the ground.
/// </summary>
public class DestroyPrefab : MonoBehaviour
{
	void Update() {
		if(gameObject.transform.position.y <= -10) {
			destroySelf();
		}
	}

	void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "floor")
        {
			destroySelf();
        }
    }

	private void destroySelf() {
		Destroy(this.gameObject);
	}

}
