﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private float spawnDelay = 1;
    private float spawnTime;
    public GameObject[] items;
    public GameObject gameManager;

    /// <summary>
    /// When true, the spawn will not spawn regardless of any other settings.
    /// </summary>
    public bool disable = false;


    // Update is called once per frame
    void Update()
    {
        if (!disable && shouldSpawn())
        {
            spawnPrefab();
        }
    }

    // spawning the prefabs of each items at random
    public void spawnPrefab()
    {
        spawnTime = Time.time + spawnDelay;

        // the random number between 0 and the array size
        int rand = Random.Range(0, items.Length );

        // divide the itemSpawner by 2
        float halfItemSpawnerLength = this.gameObject.transform.localScale.x / 2;

        // random number between the length of this object
        float randomVectorX = Random.Range(-halfItemSpawnerLength, halfItemSpawnerLength);

        // prevent items getting stuck on the spawn bar by spawning lower than the spawn bar
        float yOffset = 5f;

        Vector3 pos = new Vector3(randomVectorX,this.transform.position.y - yOffset, this.gameObject.transform.position.z);

        Instantiate(items[rand], pos, transform.rotation);
        gameManager.GetComponent<TheGameManager>().increaseitemCount();
    
    }

    private bool shouldSpawn()
    {
        return Time.time >= spawnTime;
    }
}
