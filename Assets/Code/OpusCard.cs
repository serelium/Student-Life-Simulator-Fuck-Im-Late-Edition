using UnityEngine;
using System.Collections;

public class OpusCard : MonoBehaviour {

    public int speed;
    private Rigidbody2D rb; 

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector3(speed, 0, 0);
        transform.Rotate(0, 0, 1000 * Time.deltaTime, Space.Self);
    }
}
