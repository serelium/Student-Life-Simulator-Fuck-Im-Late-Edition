﻿using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, lifetime);
	}
}
