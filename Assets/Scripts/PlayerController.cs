using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    Animator playerBlink;
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f , jumpFrequency = 1f, nextJumpTime;
    
    bool facingRight = true;
    public bool isGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    public Button jumpButton;

    public FloatingJoystick floatingJoystick;
    void Awake()
    {
        
    }
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBlink = GetComponent<Animator>();
    }

    void Update()
    {
        if (isGrounded)
        {
            HorizontalMove();
        }
       
        OnGroundCheck();

        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if(playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
    }

    public void JumpButton()
    {
        if (isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }

    }
    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(floatingJoystick.Horizontal * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(playerRB.velocity.x));
    }
    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
    void Jump()
    {
        playerRB.AddForce(new Vector2(0f,jumpSpeed)); 
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapBox(groundCheckPosition.position, new Vector2((float)(groundCheckRadius * 9), groundCheckRadius * 2), 0f, groundCheckLayer);
        playerAnimator.SetBool("IsGroundedAnim", isGrounded);
    }
}
