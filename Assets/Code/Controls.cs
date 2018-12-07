using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Controls : MonoBehaviour {

    public SoundEffect jumpSoundEffect;
    public int jumpForce;
    public int speed;
    private Rigidbody2D rb2D;
    private bool grounded;
    private GameObject[] groundCheckers;
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;
    private Animator animator;
    public bool jumpEnabled = true;

    // Use this for initialization
    void Start() {

        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundCheckers = new GameObject[3];
        groundCheckers[0] = transform.GetChild(0).gameObject;
        groundCheckers[1] = transform.GetChild(1).gameObject;
        groundCheckers[2] = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update() {

        grounded = false;
        //Debug.DrawLine(groundChecker.transform.position, groundChecker.transform.position + Vector3.down * 0.25f, Color.red, 3f);
        foreach(GameObject groundChecker in groundCheckers)
        {

            RaycastHit2D hit2D = Physics2D.Raycast(groundChecker.transform.position, Vector2.down, 0.25f);

            if (hit2D.collider != null && !hit2D.collider.isTrigger)
                grounded = true;
        }

        animator.SetBool("Grounded", grounded);

        //if (grounded && Input.GetKeyDown(KeyCode.Space))

        bool buttonDown = Application.platform != (RuntimePlatform.Android | RuntimePlatform.IPhonePlayer) ? Input.GetKeyDown(KeyCode.Space) : CrossPlatformInputManager.GetButtonDown("Jump");

        if (grounded && buttonDown)
        {
            Instantiate(jumpSoundEffect, transform.position, transform.rotation);
            rb2D.velocity = Vector2.up * jumpForce;
        }

        bool button = Application.platform != (RuntimePlatform.Android | RuntimePlatform.IPhonePlayer) ? !Input.GetKey(KeyCode.Space) : !CrossPlatformInputManager.GetButton("Jump");

        if (rb2D.velocity.y < 0)
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        //else if (rb2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        else if (rb2D.velocity.y > 0 && button)
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        animator.SetFloat("VelocityY", rb2D.velocity.y);
        rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
    }
}
