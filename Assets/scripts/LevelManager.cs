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
	public IntReference currentLevelScore;
	public IntReference currentOverallScore;
	public IntReference currentLevelObjectScore;

	/// <summary>
	/// The current max item for the current level
	/// </summary>
	public IntReference currentLevelMaxSpawn;
	public IntReference currentLevelSpawnCount;

	public GameObject itemSpawner;
	public GameObject uiManager_go;
	public ComboValidator comboValidator;

	/// <summary>
	/// Communicates to the uiManager for UI updates.
	/// Set at runtime to properly ensure an instance is available.
	/// </summary>
	private UIManager uiManager;

	/// <summary>
	/// The minimum count each level should be able to spawn.
	/// </summary>
	public int minimumItemPerLevel;


    // Start is called before the first frame update

    void Start()
    {
		uiManager = uiManager_go.GetComponent<UIManager>();
		reset();
    }

	/// <summary>
	/// Resets all global variables.
	/// Good for start of a new game.
	/// </summary>
	public void reset() {
		currentLevel.Variable.value = 1;
		currentLevelScore.Variable.value = 0;
		currentLevelObjectScore.Variable.value = 0;
		currentOverallScore.Variable.value = 0;

		setLevelStats();
		itemCount = 0;

		removeAllExistingItems();
	}

	private void removeAllExistingItems() {
		List<GameObject> items = new List<GameObject>(GameObject.FindGameObjectsWithTag("item"));
		Debug.Log("Removing all existing items for restart, found: " + items.Count);
		items.ForEach(item => {
			item.GetComponent<DestroyPrefab>().forceDestroy();
		});
	}

	public void incrementItemCount()
    {
        itemCount++;
    }

	/// <summary>
	/// Sets the next level stats, goals, objectives, chanllenges for player.
	/// Should be called at every new level.
	/// </summary>
	public void setLevelStats() {
		currentLevelScore.Variable.value = 0;
		int level = currentLevel.Variable.value;

		// max item to spawn algorithm is level + minimum
		currentLevelMaxSpawn.Variable.value = level + minimumItemPerLevel;

		// score objective is always half of the total possible score per level - for now
		currentLevelObjectScore.Variable.value = Mathf.RoundToInt((level + currentLevelMaxSpawn.Value) / 2);

		// setup max spawn
		currentLevelSpawnCount.Variable.value = currentLevelMaxSpawn.Value;
	}

	/// <summary>
	/// Goes to the next level upon calling
	/// </summary>
	public void moveToNextLevel() {
		if (!canAdvanceToNextLevel()) {
			
			gameOver();
			return;
		}

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

	private bool canAdvanceToNextLevel() {
		return currentLevelScore.Value >= currentLevelObjectScore.Value;
	}

	private void gameOver() {
		reset();
		TheGameManager.Instance.gameOver();
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
		setLevelStats();
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
