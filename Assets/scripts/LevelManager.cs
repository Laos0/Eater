using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    int itemCount;

	/// <summary>
	/// The main level value. This is a scriptable instance of Int for sharability across different classes.
	/// </summary>
	public IntReference currentLevel;
	public IntReference currentOverallScore;

	public GameObject itemSpawner;
	public GameObject uiManager_go;
	public ComboValidator comboValidator;
	private UIManager uiManager;

    // Start is called before the first frame update

    void Start()
    {
		uiManager = uiManager_go.GetComponent<UIManager>();
		reset();
    }

	private void reset() {
		currentLevel.Variable.value = 1;
		currentOverallScore.Variable.value = 0;
		itemCount = 0;
	}

	public void incrementItemCount()
    {
        itemCount++;
    }

	/// <summary>
	/// Goes to the next level upon calling
	/// </summary>
	public void moveToNextLevel() {
		if (currentLevel != null) {
			if (itemSpawner) {
				if (uiManager) {
					uiManager.displayNextLevelLabel();
				}
				currentLevel.Variable.value++;      // increment level value
				itemSpawner.SetActive(false);
				StartCoroutine(beginPauseForNextLevel());
			} else {
				Debug.LogError("Failed to move to next level, itemSpawner is null");
			}
		} else {
			Debug.LogError("Failed to move to next level, currentLevel is null");
		}
	}

	/// <summary>
	/// A short break before next level begins
	/// </summary>
	/// <returns>The pause for next level.</returns>
	private IEnumerator beginPauseForNextLevel() {
		yield return new WaitForSeconds(3); // wait 3 sec
		if (uiManager) {
			uiManager.hideNextLevelLabel();
		}
		generateNewComboSet();
		itemSpawner.SetActive(true);		// enable spawner
	}


	public int getCurrentItemCount()
    {
        return itemCount;
    }

	public void validateCombo(ItemStats stats) {
		if(stats && comboValidator) {
			comboValidator.validateCombo(stats);
		} else {
			Debug.LogError("Failed to validate combo in levelManager, stats or comboValidator is null");
		}
	}

	/// <summary>
	/// Generates the new combo set and sets it on the combo validator.
	/// </summary>
	public void generateNewComboSet() {
		if (comboValidator) {
			List<EnumValue> newComboList = new List<EnumValue>();
			//todo generate the random combo array based on populated items for current level.

			// then set the new combo list
			comboValidator.setCombo(newComboList);
		}
	}
}
