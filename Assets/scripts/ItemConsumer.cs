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

	/// <summary>
	/// this is the player's current combo list
	/// </summary>
	public List<EnumValue> currentComboList;

	/// <summary>
	/// this is the current combo list for this level
	/// </summary>
	public List<EnumValue> comboList;
	

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

				// store the player's combo into an array
				currentComboList.Add(col.gameObject.GetComponent<ItemStats>().itemStats.itemType);


				try
				{
					// check if the currentComboList is equal to the comboList
					for(int i = 0; i < currentComboList.Count; i++)
					{
						if (currentComboList[i] == comboList[i])
						{
							// then it matches 
							Debug.Log("Combo chain, it is a match");
						}
						else // if the currentComboList haven even 1 matching that are not the same then we must reset the combo of the player
						{
							Debug.Log("Combo fail, resetting the currentComboList");
							for(int k = 0; k < currentComboList.Count; k++)
							{
								currentComboList.RemoveAt(k);
							}
						}

					}
				}catch(UnityException e)
				{
					Debug.LogError("OUT OF BOUNDDDDD");
				}
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
