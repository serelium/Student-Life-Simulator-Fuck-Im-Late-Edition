using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

    public SoundEffect soundEffect;
    public ParticleSystem particleEffect;
    public int healAmount;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Instantiate(soundEffect, transform.position, transform.rotation);
            Instantiate(particleEffect, transform.position, transform.rotation);
            Health health = collision.gameObject.GetComponent<Health>();

            health.RestoreHealth(healAmount);

            Destroy(gameObject);
        }
    }
}
