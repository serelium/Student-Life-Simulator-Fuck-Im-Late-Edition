using UnityEngine;
using System.Collections;

public class ElectricRails : MonoBehaviour {

    public SoundEffect soundEffect;
    private float electrocutionDuration;
    private float electrocutionCounter;
    private bool electrocuted;
    private Health playerHealth;
    private int healthAtElectrocution;
    private int timesToElectrocute;

    // Use this for initialization
    void Start () {

        if(soundEffect != null)
            electrocutionDuration = soundEffect.audioClip.length;

        electrocuted = false;
    }

    // Update is called once per frame
    void Update () {

        if (electrocuted)
        {
            int healthAtElectrocution = playerHealth.currentHealth;

            if (electrocutionCounter <= 0 && timesToElectrocute > 0)
            {
                playerHealth.TakeDamage(1);
                timesToElectrocute--;
                electrocutionCounter = electrocutionDuration / healthAtElectrocution;
            }

            electrocutionCounter -= Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            if(soundEffect != null)
                Instantiate(soundEffect, transform.position, transform.rotation);

            collider.gameObject.GetComponent<Animator>().SetBool("Electrocuted", true);
            collider.gameObject.GetComponent<Controls>().speed = 0;
            collider.gameObject.GetComponent<Player>().electrocuted = true;
            playerHealth = collider.gameObject.GetComponent<Health>();
            electrocuted = true;
            healthAtElectrocution = playerHealth.currentHealth;
            electrocutionCounter = electrocutionDuration / healthAtElectrocution;
            timesToElectrocute = healthAtElectrocution;
        }

    }
}
