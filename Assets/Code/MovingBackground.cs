using UnityEngine;
using System.Collections;

public class MovingBackground : MonoBehaviour {

    public float speed;
    public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(player.electrocuted)
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

        else
            GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
    }
}
