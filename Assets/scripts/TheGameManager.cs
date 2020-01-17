using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Holds access to all other sub managers and stats.
/// This class serves as a public API for any class to get information
/// of the current game state.
/// </summary>
//[RequireComponent(typeof(ScoreManager), typeof(LevelManager))]
public class TheGameManager : Singleton<TheGameManager>
{
	public GameObject player;
	public GameObject itemSpawner;
	public LevelManager levelManager;
	public GameObject uiManager_go;
	public ItemConsumer itemConsumer;

	private UIManager uiManager;
	private LevelManager lvlManager;

	public GameObject background;

	//todo
	public Slider changeFormSlider;

	private bool isPaused = false;

	public void Start() {
		if (uiManager_go) {
			uiManager = uiManager_go.GetComponent<UIManager>();
		}
		if (levelManager) {
			lvlManager = levelManager.GetComponent<LevelManager>();
		}
	}

	/// <summary>
	/// Should only contain admin controls
	/// </summary>
	public void Update()
	{
		// Admin debug shortcut keys
		if (Input.GetKeyUp(KeyCode.P)) {
			isPaused = !isPaused;
			if (isPaused) {
				pauseGame();
			} else {
				unPauseGame();
			}
		}

		if (Input.GetKeyUp(KeyCode.N)) {
			lvlManager.currentLevelScore.Variable.value = 9999;	// cheat force score to bypass next level logic
			nextLevel();
		}
	}

	public void registerAndDestroyLevelItem(GameObject go) {
		levelManager.registerAndDestroyLevelItem(go);
	}

	public void gameOver() {
		pauseGame();
		if (uiManager) {
			uiManager.displayGameOverLabel();
			StartCoroutine(beginGameRestart());
		} else {
			Debug.LogError("Failed to display gameover text, uiManager is null");
		}
	}

	IEnumerator beginGameRestart() {

		yield return new WaitForSeconds(3);
		if (background) {
			background.GetComponent<BackgroundHead>().resetPosition();
		}
		uiManager.hideGameOverLabel();
		lvlManager.reset();
		unPauseGame();

	}

	public void nextLevel() {
		if (levelManager) {
			levelManager.moveToNextLevel();
		}
	}

	private void pauseGame()
	{
		if (itemSpawner) {
			itemSpawner.SetActive(false);
		}
		if (player) {
			player.GetComponent<PlayerController>().disable();
		}
	}

	private void unPauseGame()
	{
		if (itemSpawner) {
			itemSpawner.SetActive(true);
		}
		if (player) {
			player.GetComponent<PlayerController>().enable();
		}
	}

	public void decrementChangeFormSlider()
	{
		changeFormSlider.GetComponent<ChangeFromProgressBar>().setDidChangeForm(true);
	}

	public void validateCombo(ItemStats stat) {
		if (levelManager && stat) {
			levelManager.validateCombo(stat);
		} else {
			Debug.LogError("Failed to validate combo, levelManager or stat is null");
		}
	}

	public int getCurrentLevel() {
		return levelManager.GetComponent<LevelManager>().currentLevel.ConstantValue;
	}

	public List<GameObject> getListOfItems() {
		return levelManager.generateSpawnList();
	}

	public int getMaxItemSpawn() {
		return levelManager.getCurrentMaxSpawn();
	}

	public string getComboListTxt() {

		string comboListTxt = "";

		try
		{
			for(int i = 0; i < levelManager.theCurrentComboList.Count; i++)
			{
				comboListTxt += levelManager.theCurrentComboList[i];
			}

			return comboListTxt;

		}catch(UnityException e)
		{
			Debug.LogError("OUT OF BOUND in TheGameManager");
			return null;
		}
		
	}

	public void setComboList(List<EnumValue> comboList) {
		itemConsumer.comboList = comboList;
	}


}
