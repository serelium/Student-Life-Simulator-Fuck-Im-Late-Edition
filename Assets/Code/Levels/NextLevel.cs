﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameController.playerHealth = collision.gameObject.GetComponent<Health>().currentHealth;
        }
    }
}
