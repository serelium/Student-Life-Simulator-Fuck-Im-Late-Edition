using UnityEngine;
using System.Collections;

public class SpawnerManager : MonoBehaviour {

    public Spawner[] spawners;
    public float spawnRateMin;
    public float spawnRateMax;
    public float maxSpawn;

    private float timeSinceLastSpawn;
    private float randomCurrentSpawnRate;
    private int spawnCounter;

    // Use this for initialization
    void Start () {

        randomCurrentSpawnRate = Random.Range(spawnRateMax, spawnRateMin);
    }
	
	// Update is called once per frame
	void Update () {

        if (spawnCounter < maxSpawn)
        {

            if (timeSinceLastSpawn >= randomCurrentSpawnRate)
            {
                int randomObjectIndex = Random.Range(0, spawners.Length);

                bool success = spawners[randomObjectIndex].SpawnObject();

                if (success)
                {

                    timeSinceLastSpawn = 0;
                    randomCurrentSpawnRate = Random.Range(spawnRateMax, spawnRateMin);
                    spawnCounter++;
                }
            }

            timeSinceLastSpawn += Time.deltaTime;
        }
    }

    public bool AreSpawnersActive()
    {
        return spawnCounter < maxSpawn;
    }
}
