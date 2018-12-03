using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnder : MonoBehaviour {

    public EndlessBackground[] endlessBackgrounds;
    public SpawnerManager[] spawnerManagers;
    public Collider2D levelEndTrigger;
    public CameraFollow cameraFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        CheckIfLevelEnded();
	}

    private void CheckIfLevelEnded()
    {
        bool levelEnded = true;

        foreach (SpawnerManager spawnerManager in spawnerManagers)
        {
            if (spawnerManager.AreSpawnersActive())
                levelEnded = false;
        }

        if (levelEnded)
        {
            float lastPosition = 0;

            foreach (EndlessBackground endlessBackground in endlessBackgrounds)
                lastPosition = endlessBackground.Stop();

            cameraFollow.Stop(lastPosition);

            levelEndTrigger.gameObject.SetActive(true);
        }
    }
}
