using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float jumpForce;

    private float moveInput;

    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    public float radius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private int extraJumps = 1;

    [SerializeField] private AudioSource jumpsfx;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);
        
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (extraJumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            extraJumps--;
        }else if (extraJumps == 0 && Input.GetKeyDown(KeyCode.Space)){Jump();}

        if (isGrounded)
        {
            extraJumps = 1;
        }


    }

    private void FixedUpdate()
    {
        
    }


    void Jump()
    {
        jumpsfx.Play();
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
