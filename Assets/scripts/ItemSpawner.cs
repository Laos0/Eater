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

        // divide the itemSpawner by 2
        float halfItemSpawnerLength = this.gameObject.transform.localScale.x / 2;

        // random number between the length of this object
        float randomVectorX = Random.Range(-halfItemSpawnerLength, halfItemSpawnerLength);
        Vector3 pos = new Vector3(randomVectorX,this.transform.position.y, this.gameObject.transform.position.z);

        //Debug.Log(randomVectorX);

        Instantiate(items[rand], pos, transform.rotation);
    }

    private bool shouldSpawn()
    {
        return Time.time >= spawnTime;
    }
}
