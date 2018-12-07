using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public SoundEffect soundEffect;
    public int damage;
    public float lifeTime;

	// Use this for initialization
	void Start () {

        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Health health = collider.gameObject.GetComponent<Health>();

        if (health != null)
        {
            Instantiate(soundEffect, transform.position, transform.rotation);
            health.TakeDamage(damage);
            GetComponent<Collider2D>().enabled = false;
        }

    }
}
