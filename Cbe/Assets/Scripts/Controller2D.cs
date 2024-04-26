using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    [SerializeField] private float jumpForce;
    private int extraJumps = 1;
    private bool isFacingRight = true;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    public float radius;
    public LayerMask whatIsGround;
    [SerializeField] private AudioSource jumpsfx;
    // [SerializeField] private TrailRenderer tr;
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);

        if (isDashing)
        {
            return;
        }

        if (extraJumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            extraJumps--;
        }
        else if (extraJumps <= 0)
        {
            if (isGrounded)
            {
                extraJumps = 1;
            }
        }

if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        Flip();
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private IEnumerator Dash()
    {
        BoxCollider2D hitbox = GetComponentInChildren<BoxCollider2D>();
        hitbox.enabled = false;
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
   //     tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
//tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        hitbox.enabled = true;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    void Jump()
    {
        jumpsfx.Play();
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
