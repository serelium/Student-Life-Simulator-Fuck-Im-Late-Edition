using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    private bool flashActive;
    public float flashLength;
    private float flashCounter;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {

        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        if (flashActive)
        {
            if (flashCounter > flashLength * 0.66f)
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);

            else if (flashCounter > flashLength * 0.33f)
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);

            else if (flashCounter > 0)
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);

            else
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        flashActive = true;
        flashCounter = flashLength;

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
        Destroy(gameObject, 2);
    }
}
