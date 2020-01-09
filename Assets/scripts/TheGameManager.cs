using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGameManager : Singleton<TheGameManager>
{
    public GameObject player;
    public PlayerScore playerScore;
    public GameObject itemSpawner;
    public LevelScript levelManager;

    // Update is called once per frame
    void Update()
    {
       
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
        if(levelManager.getCurrentItemCount() % 5 == 0)
        {
            increaseTheLevel();
        }
    }

}
