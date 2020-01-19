﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private float spawnDelay = 3;
    private float spawnTime;
    public List<GameObject> items;
    public GameObject gameManager;
	public IntReference currentLevelMaxSpawn;
	public IntReference currentLevelSpawnCount;

    public List<GameObject> listOfItemsToSpawn;

    /// <summary>
    /// Do not make it public - master flag to enable and disable.
    /// </summary>
    private bool isDisabled = false;

	public void Awake() {
		// auto disable and let a manager start the spawner.
		isDisabled = true;
	}

	/// <summary>
	/// To call this, use setActive on the GameObject.
	/// </summary>
	private void OnDisable()
    {
		Debug.Log("Spawner disabled");
        isDisabled = true;
    }

	/// <summary>
	/// To call this, use setActive on the GameObject.
	/// </summary>
	private void OnEnable()
    {
        isDisabled = false;
		Debug.Log("Spawner enabled");
    }

    // Update is called once per frame
    void Update()
    {
        //items = TheGameManager.Instance.getListOfItems();

        if (!isDisabled && isCoolDownDone())
        {
            spawnPrefab();
        }
    }

    // spawning the prefabs of each items at random
    public void spawnPrefab()
    {
        spawnTime = Time.time + spawnDelay;

        // divide the itemSpawner by 2
        float halfItemSpawnerLength = this.gameObject.transform.localScale.x / 2;

        // random number between the length of this object
        float randomVectorX = Random.Range(-halfItemSpawnerLength, halfItemSpawnerLength);

        // prevent items getting stuck on the spawn bar by spawning lower than the spawn bar
        float yOffset = 5f;

        Vector3 pos = new Vector3(randomVectorX,this.transform.position.y - yOffset, this.gameObject.transform.position.z);


        // once all the require items in the items array have dropped, we then can randomly spawn any of the items
        if(currentLevelSpawnCount.Value > 0)
        {
            Instantiate(items[currentLevelSpawnCount.Value - 1], pos, transform.rotation);
            currentLevelSpawnCount.Variable.value--;
        }
        else
        {
            // the random number between 0 and the array size
            int rand = Random.Range(0, items.Count);
            Instantiate(items[rand], pos, transform.rotation);
            currentLevelSpawnCount.Variable.value--;
        }

		//currentLevelSpawnCount.Variable.value--;

		if(currentLevelSpawnCount.Value <= 0) {
			isDisabled = true;
        }


	}


	private bool isCoolDownDone()
    {
        return Time.time >= spawnTime;
    }

}
