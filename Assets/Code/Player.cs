using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Health health;
    public bool electrocuted;
    public int nbOfHomeworkPages;
    private int pagesAtStartOfLevel;

	// Use this for initialization
	void Start () {

        health = GetComponent<Health>();
        health.currentHealth = GameController.playerHealth;
        pagesAtStartOfLevel = GameController.homeworkPagesOwned;
        nbOfHomeworkPages = GameController.homeworkPagesOwned;
        electrocuted = false;
    }
	
	// Update is called once per frame
	void Update () {

        Animator animator = Camera.main.gameObject.GetComponentInChildren<Animator>();

        if(animator != null)
            animator.SetInteger("Health", health.currentHealth);

        if(health.currentHealth <= 0)
        {

            GameController.numberOfTries++;
            GameController.playerHealth = 4;
            GameController.homeworkPagesOwned = pagesAtStartOfLevel;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddHomeworkPage()
    {
        nbOfHomeworkPages++;
        GameController.homeworkPagesOwned++;
    }
}
