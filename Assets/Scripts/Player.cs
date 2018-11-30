using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Health health;
    public int nbOfHomeworkPages;

	// Use this for initialization
	void Start () {

        health = GetComponent<Health>();
        nbOfHomeworkPages = 0;

    }
	
	// Update is called once per frame
	void Update () {

        Animator animator = Camera.main.gameObject.GetComponentInChildren<Animator>();
        animator.SetInteger("Health", health.currentHealth);
	}

    public void AddHomeworkPage()
    {
        nbOfHomeworkPages++;
    }

    void OnDestroy()
    {
        SceneManager.LoadScene(0);
    }
}
