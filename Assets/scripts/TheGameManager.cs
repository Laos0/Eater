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

	//todo
	public Slider changeFormSlider;

	private bool isPaused = false;

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
			nextLevel();
		}
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
			levelManager.comboValidator.validateCombo(stat);
		} else {
			Debug.LogError("Failed to validate combo, levelManager or stat is null");
		}
	}


}
