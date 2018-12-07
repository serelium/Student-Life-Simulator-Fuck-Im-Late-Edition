using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{

    public GameObject objectToSpawn;
    //public Vector3[] positionsToSpawn;
    private List<Transform> spawnLocations;

    // Use this for initialization
    void Start()
    {
        spawnLocations = new List<Transform>();

        foreach (Transform child in transform)
            spawnLocations.Add(child);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool SpawnObject()
    {
        int randomPositionIndex = Random.Range(0, spawnLocations.Count);

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(spawnLocations[randomPositionIndex].position);
        bool onScreen = screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        if (!onScreen)
        {

            if (spawnLocations.Count > 0)
                Instantiate(objectToSpawn, spawnLocations[randomPositionIndex].position, transform.rotation);
            else
                Instantiate(objectToSpawn, transform.position, transform.rotation);
        }

        return !onScreen;
    }
}