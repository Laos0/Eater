using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private float spawnDelay = 1;
    private float spawnTime;
    public GameObject[] items;


    // Update is called once per frame
    void Update()
    {
        if (shouldSpawn())
        {
            spawnPrefab();
        }
    }

    // spawning the prefabs of each items at random
    private void spawnPrefab()
    {
        spawnTime = Time.time + spawnDelay;

        // the random number between 0 and the array size
        int rand = Random.Range(0, items.Length );

        // random number between the length of this object
        //float randomVector = Random.Range(0, this.tranform.position.x);


        Instantiate(items[rand], this.transform.position, transform.rotation);
    }

    private bool shouldSpawn()
    {
        return Time.time >= spawnTime;
    }
}
