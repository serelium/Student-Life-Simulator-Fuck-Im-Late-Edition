using UnityEngine;
using System.Collections;

public class AutomaticDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
            GetComponent<Animator>().SetBool("Open", true);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
            GetComponent<Animator>().SetBool("Open", false);
    }
}
