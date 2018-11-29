using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Health health;
	// Use this for initialization
	void Start () {

        health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {

        Animator animator = Camera.main.gameObject.GetComponentInChildren<Animator>();
        animator.SetInteger("Health", health.currentHealth);
	}

    void OnDestroy()
    {
        SceneManager.LoadScene(0);
    }
}
