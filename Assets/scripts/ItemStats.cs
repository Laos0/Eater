using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStats : MonoBehaviour
{
    public ItemStatsTemplate itemStats;

	void Start() {
		PositionTranslate pt = GetComponent<PositionTranslate>();
		if (pt) {
			pt.activate(itemStats.fallSpeed);
		} else {
			Debug.LogError("Item will not fall, translate script is null");
		}
	}

}
