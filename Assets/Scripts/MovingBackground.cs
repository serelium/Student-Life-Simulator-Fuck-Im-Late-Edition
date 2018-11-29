using UnityEngine;
using System.Collections;

public class MovingBackground : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
	}
}
