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

	public void forceDestroy() {
		Destroy(this.gameObject);	// don't register and destroy with this call
	}

	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "floor")
        {
			destroySelf();
        }
	}

	private void destroySelf() {
		TheGameManager.Instance.registerAndDestroyLevelItem(gameObject);
	}

}
