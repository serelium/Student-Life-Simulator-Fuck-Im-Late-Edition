﻿using UnityEngine;
using System.Collections;

public class HomeworkPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
            Destroy(gameObject);
    }
}
