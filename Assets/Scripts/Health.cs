using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

	// Use this for initialization
	void Start () {

        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
            Die();
    }

    public void RestoreHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
