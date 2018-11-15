using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public int jumpForce;
    private Rigidbody2D rb2D;
    private bool grounded;
    private Component groundChecker;

    // Use this for initialization
    void Start() {

        rb2D = GetComponent<Rigidbody2D>();
        groundChecker = GetComponentInChildren<Component>();
    }

    // Update is called once per frame
    void Update() {

        RaycastHit2D hit2D = Physics2D.Raycast(groundChecker.transform.position, Vector2.down, 0.1f);

        grounded = hit2D != null;

        if (grounded && Input.GetKeyDown(KeyCode.Space)) {

            rb2D.AddForce(new Vector2(0, jumpForce));
        }
	}
}
