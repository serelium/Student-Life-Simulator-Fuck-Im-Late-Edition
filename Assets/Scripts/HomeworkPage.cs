using UnityEngine;
using System.Collections;

public class HomeworkPage : MonoBehaviour {

    public ParticleSystem pickupEffect;
    public SoundEffect soundEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {

            Instantiate(soundEffect, transform.position, transform.rotation);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            collider.gameObject.GetComponent<Player>().AddHomeworkPage();
            Destroy(gameObject);
        }
    }
}
