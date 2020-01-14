using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The object that contains this can consume items when it touches an item.
/// Where comboing and tracking what it eats happens here.
/// </summary>
public class ItemConsumer : MonoBehaviour
{
	public IntReference currentLevelScore;
	

	void Start() {
	
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag.Equals("item")) {
			ItemStats stat = col.gameObject.GetComponent<ItemStats>();
			if (stat) {

				// add the default item point value of whatever the item is worth
				addToScore(stat.itemStats.pointValue);

				// check combo and see if can give combo points
				TheGameManager.Instance.validateCombo(stat);

				// get rid of item prefab in scene
				TheGameManager.Instance.registerAndDestroyLevelItem(col.gameObject);
			}
		}
	}


	private void addToScore(int value) {
		if (currentLevelScore != null) {
			currentLevelScore.Variable.value += value;
		} else {
			Debug.LogError("Failed to add to score, currentOverallScore is null");
		}
	}
}
