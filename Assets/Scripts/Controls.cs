using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public SoundEffect jumpSoundEffect;
    public int jumpForce;
    public int speed;
    private Rigidbody2D rb2D;
    private bool grounded;
    private GameObject groundChecker;
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;
    private Animator animator;

    // Use this for initialization
    void Start() {

        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundChecker = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update() {

        Debug.DrawLine(groundChecker.transform.position, groundChecker.transform.position + Vector3.down * 0.5f, Color.red, 3f);
        RaycastHit2D hit2D = Physics2D.Raycast(groundChecker.transform.position, Vector2.down, 0.5f);

        grounded = hit2D.collider != null && !hit2D.collider.isTrigger;
        animator.SetBool("Grounded", grounded);

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(jumpSoundEffect, transform.position, transform.rotation);
            rb2D.velocity = Vector2.up * jumpForce;
        }

        if(rb2D.velocity.y < 0)
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        animator.SetFloat("VelocityY", rb2D.velocity.y);
        rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
    }
}
