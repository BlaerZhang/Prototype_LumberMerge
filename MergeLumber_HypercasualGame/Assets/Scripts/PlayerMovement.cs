using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float runSpeed = 40f;
    
    private CharacterController2D controller;
    private Animator animator;
    private Rigidbody2D rb2D;
   
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) jump = true;
        if (Input.GetButtonDown("Crouch")) crouch = !crouch;

        animator.SetBool("isCrouching", crouch);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        if (rb2D.velocity.magnitude > 0.05f) animator.SetBool("isWalking", true);
        else animator.SetBool("isWalking", false);
    }
}
