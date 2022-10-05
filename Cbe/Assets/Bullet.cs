using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Damage();
        Destroy(this.gameObject, 0.1f);
    }

    void Damage()
    {
        
    }
}
