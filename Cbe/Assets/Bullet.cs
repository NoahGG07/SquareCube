using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this, 2);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
