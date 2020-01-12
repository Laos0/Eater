using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Holds access to all other sub managers and stats.
/// This class serves as a public API for any class to get information
/// of the current game state.
/// </summary>
public class TheGameManager : Singleton<TheGameManager>
{
	public GameObject player;
	public PlayerScore playerScore;
	public GameObject itemSpawner;
	public LevelScript levelManager;
	public Slider changeFormSlider;

	private bool isPaused = false;

	/// <summary>
	/// Should only contain admin controls
	/// </summary>
	public void Update()
	{
		if (Input.GetKeyUp(KeyCode.P)) {
			isPaused = !isPaused;
			if (isPaused) {
				pauseGame();
			} else {
				unPauseGame();
			}
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

	public int getCurrentLevel()
	{
		if (levelManager) {
			return levelManager.getCurrentLvl();
		}
		return 0;
	}

	public void increasePlayerScore()
	{
		playerScore.increasePlayerScore();
	}

	public void increaseTheLevel()
	{
		levelManager.updateCurrentLvl();
	}

	public void increaseitemCount()
	{
		levelManager.incrementItemCount();

		// checking if the level should be increased after a certain amount of item drops
		// increase level every 5 level
		if (levelManager.getCurrentItemCount() % 5 == 0) {
			increaseTheLevel();
		}
	}

	public void decrementChangeFormSlider()
	{
		changeFormSlider.GetComponent<ChangeFromProgressBar>().setDidChangeForm(true);
	}


}
