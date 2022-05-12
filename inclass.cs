using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;
    private Transform check;

    private float xAxis;
    private bool isJumped;
    private float jumpCoff;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        animator = transform.Find("Sprite").GetComponent<Animator>();
        check = transform.Find("Check");

        xAxis = 0;
        isJumped = false;
        jumpCoff = 20;
    }

    // Update is called once per frame
    void Update()
    {
        ActionMove();
        ActionJump();
    }

    private void ActionMove()
    {
        xAxis = Input.GetAxis("Horizontal");
        if(Mathf.Abs(xAxis) < 0.1)
        {
            xAxis = 0;
        }
    }

    private void ActionJump()
    {
        if (isJumped == true)
            return;

        if (Input.GetButtonDown("Jump") == false)
            return;

        isJumped = true;
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpCoff);
        animator.SetTrigger("Jump");
    }
}

