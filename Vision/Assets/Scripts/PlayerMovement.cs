using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed, maxSpeed, jumpForce;
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private bool cancelJumpEnabled;

    private float moveDir;
    private Rigidbody2D myRB;
    private bool canJump;
    private SpriteRenderer mySprite;
    public Transform animatorTransform;
    private Animator anim;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        myRB = GetComponent<Rigidbody2D>();
        mySprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!startCutscene.isCutsceneOn)
        {
            if (moveDir > 0)
            {
                animatorTransform.localScale =
                    new Vector3(1, animatorTransform.localScale.y, animatorTransform.localScale.z);
            }

            else if (moveDir < 0)
            {
                animatorTransform.localScale =
                    new Vector3(-1, animatorTransform.localScale.y, animatorTransform.localScale.z);
            }

            var moveAxis = Vector3.right * moveDir;

            if (Mathf.Abs(myRB.velocity.x) < maxSpeed)
            {
                myRB.AddForce(moveAxis * moveSpeed, ForceMode2D.Force);
            }

            if (groundCheck.IsTouchingLayers(groundLayers))
            {
                canJump = true;
                anim.SetBool("isJumping", false);
                anim.SetBool("takeOff", false);
            }
            else
            {
                anim.SetBool("isJumping", true);
                canJump = false;
            }

            if (moveDir == 0)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("takeOff", false);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<float>();
    }

    public void Move(float moveAmt)
    {
        moveDir = moveAmt;
    }
    

    public void Jump(InputAction.CallbackContext context)
    {
        if (!startCutscene.isCutsceneOn)
        {
            if (canJump)
            {
                if (context.started)
                {
                    myRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                    canJump = false;
                    anim.SetBool("takeOff", true);
                    anim.SetBool("isJumping", false);
                }
                else
                {
                    anim.SetBool("isJumping", true);
                }
            }

            if (context.canceled && cancelJumpEnabled)
            {
                myRB.velocity = new Vector2(myRB.velocity.x, 0f);
            }
        }
    }
}