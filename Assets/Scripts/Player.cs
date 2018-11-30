using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Health health;
    public bool electrocuted;
    public int nbOfHomeworkPages;

	// Use this for initialization
	void Start () {

        health = GetComponent<Health>();
        nbOfHomeworkPages = 0;
        electrocuted = false;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
