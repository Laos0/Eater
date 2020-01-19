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
	public IntReference currentLevelObjectiveScore;
	public IntReference currentLevelDestroyedItemCounter;

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


	/// <summary>
	/// the list OF available gameObejcts items to spawn
	/// </summary>
	public List<GameObject> items = new List<GameObject>();

	/// <summary>
	/// the list of gameObjects that will be spawned
	/// </summary>
	public List<GameObject> itemsToSpawn = new List<GameObject>();

	/// <summary>
	///  For visual Testing for the combo list
	/// </summary>
	public List<EnumValue> theCurrentComboList;


    // Start is called before the first frame update
    void Start()
    {
		uiManager = uiManager_go.GetComponent<UIManager>();
		reset();
		disableSpawner();
    }

	public void enableSpawner() {
		if (itemSpawner) {
			itemSpawner.SetActive(true);
		} else {
			Debug.Log("Failed to enable spawner, ItemSpawner GO is null");
		}	
	}

	public void disableSpawner() {
		if (itemSpawner) {
			itemSpawner.SetActive(true);
		} else {
			Debug.Log("Failed to disable spawner, ItemSpawner GO is null");
		}
	}

	/// <summary>
	/// Resets all global variables.
	/// Good for start of a new game.
	/// </summary>
	public void reset() {
		// these are global values for the entire game session
		currentLevel.Variable.value = 1;
		currentOverallScore.Variable.value = 0;

		// once all stats are cleared out, set the proper level stat for that level
		setLevelStats();
		itemCount = 0;

		removeAllExistingGameObjectItems();
	}

	public void registerAndDestroyLevelItem(GameObject item) {
		if(currentLevelDestroyedItemCounter != null) {
			currentLevelDestroyedItemCounter.Variable.value++;
			Destroy(item);
			if(currentLevelDestroyedItemCounter.Value >= currentLevelMaxSpawn.Value) {
				TheGameManager.Instance.nextLevel();
			}
		} else {
			Debug.LogError("Failed to destroy and register item, destroy item counter is null");
		}
	}

	/// <summary>
	/// When starting new level, cleans up existing items in the scene
	/// </summary>
	private void removeAllExistingGameObjectItems() {
		List<GameObject> items = new List<GameObject>(GameObject.FindGameObjectsWithTag("item"));
		Debug.Log("Removing all existing items for restart, found: " + items.Count);
		items.ForEach(item => {
			item.GetComponent<DestroyPrefab>().forceDestroy();
		});
	}

	/// <summary>
	/// Use for starting a new level. Not for restarting a brand new game session.
	/// Rests common level stats back to default.
	/// </summary>
	private void levelStatsReset() {
		currentLevelScore.Variable.value = 0;
		currentLevelObjectiveScore.Variable.value = 0;
		currentLevelDestroyedItemCounter.Variable.value = 0;

		itemsToSpawn = new List<GameObject>();
	}


	/// <summary>
	/// Sets the next level stats, goals, objectives, chanllenges for player.
	/// Should be called at every new level.
	/// </summary>
	public void setLevelStats() {
		levelStatsReset();
		int level = currentLevel.Variable.value;

		// max item to spawn algorithm is level + minimum
		currentLevelMaxSpawn.Variable.value = level + minimumItemPerLevel;

		// score objective is always half of the total possible score per level - for now
		currentLevelObjectiveScore.Variable.value = Mathf.RoundToInt((level + currentLevelMaxSpawn.Value) / 2);

		// setup max spawn
		currentLevelSpawnCount.Variable.value = currentLevelMaxSpawn.Value;

		// set up the items to spawn
		itemSpawner.GetComponent<ItemSpawner>().items = generateSpawnList();

		// generate the comboList of this level
		try
		{
			generateNewComboSet();

		}catch(UnityException e)
		{
			Debug.LogError("Array out ofd bound");
		}

		try
		{
			// set the comboList in ItemConsumer
			TheGameManager.Instance.setComboList(theCurrentComboList);

		}catch(UnityException e)
		{
			Debug.LogError(e);
		}
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
		return currentLevelScore.Value >= currentLevelObjectiveScore.Value;
	}

	private void gameOver() {
		reset(); // todo may not need as redundent
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

		try
		{
			generateNewComboSet();
		}catch(UnityException e)
		{
			Debug.LogError("generateNewComboSet");

		}
		itemSpawner.SetActive(true);		// enable spawner
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

		// the length of the combo list
		int r = 3;

		if (comboValidator) {
			List<EnumValue> newComboList = new List<EnumValue>();

			//todo generate the random combo array based on populated items for current level.
			// for now, we'll be grabbing the first three element of the itemsToSpawn
			for (int i = 0; i < r; i++)
			{
				//int randomSelectedItem = Random.Range(0, items.Count);
				newComboList.Add(itemsToSpawn[i].GetComponent<ItemStats>().itemStats.itemType);
			}

			comboValidator.setCombo(newComboList);
			theCurrentComboList = newComboList;
		}
	}

	public int getCurrentMaxSpawn() {
		return currentLevelMaxSpawn.ConstantValue;
	}

	public List<GameObject> generateSpawnList() {

		try
		{

			// We'll need to tweak this instead of items.Count, it'll be based on the level
			for (int i = 0; i < currentLevelMaxSpawn.Value; i++)
			{
				Debug.Log("generateSpawnList() Current Max Spawn: " + currentLevelMaxSpawn.Value);
				int randomSelectedItem = Random.Range(0, currentLevelMaxSpawn.Value - 1);
				itemsToSpawn.Add(items[randomSelectedItem]);
			}
			return itemsToSpawn;
		}catch(UnityException e)
		{
			Debug.LogError(e);
			return null;
		}

	}

	public void checkAvailableCombos() {

	}
}
