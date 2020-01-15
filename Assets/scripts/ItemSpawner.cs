using System.Collections;
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

    /// this variable is based off the LevelManager where spawnCount is equal to to the 
    /// itemsToSpawn.Count(), and will be decremented over time
    public int spawnCounter;

    /// <summary>
    /// When true, the spawn will not spawn regardless of any other settings.
    /// </summary>
    public bool isDisabled = false;

    public void OnDisable()
    {
        isDisabled = true;
    }

    public void OnEnable()
    {
        isDisabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //items = TheGameManager.Instance.getListOfItems();

        if (!isDisabled && canSpawn())
        {
            if(currentLevelSpawnCount.Variable.value != TheGameManager.Instance.getMaxItemSpawn())
            {
                spawnPrefab();
            }
            else
            {
                currentLevelSpawnCount.Variable.value = 0;
            }
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
        if(spawnCounter > 0)
        {
            GameObject currentItemDrop = Instantiate(items[spawnCounter], pos, transform.rotation);
            spawnCounter--;
        }
        else
        {
            // the random number between 0 and the array size
            int rand = Random.Range(0, items.Count);
            GameObject currentItemDrop = Instantiate(items[rand], pos, transform.rotation);
        }

		currentLevelSpawnCount.Variable.value--;

		if(currentLevelSpawnCount.Value <= 0) {
			isDisabled = true;
        }


	}


	private bool canSpawn()
    {
        return Time.time >= spawnTime;
    }

}
