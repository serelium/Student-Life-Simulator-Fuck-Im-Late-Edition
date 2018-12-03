using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ets : MonoBehaviour {

    public LevelEnder levelEnder;
    public SpriteRenderer door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (levelEnder.levelEnded)
        {

            GetComponent<SpriteRenderer>().enabled = true;
            door.enabled = true;
        }
	}
}
