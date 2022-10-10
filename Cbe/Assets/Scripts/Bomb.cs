using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bomb : MonoBehaviour
{
     	[SerializeField] private float force;
        private Rigidbody2D rb;
    
        [SerializeField] private bool isAffectedByGravity;
		
		public float damage;
        [SerializeField] private GameObject ExplosionEffect;
        [SerializeField] private GameObject explosionSFX;
        [SerializeField] private float explotionForce;
        public float radius;



        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            Destroy(this.gameObject, 3);
            if (isAffectedByGravity)
            {
                rb.AddForce(transform.right * force, ForceMode2D.Impulse);
            }
        }
    
        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            Explode(); 
        }
    
        void Explode()
        {
            Instantiate(ExplosionEffect, transform.position, quaternion.identity);
            Instantiate(explosionSFX, transform.position, quaternion.identity);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

            foreach (Collider2D col in colliders)
            {
                Rigidbody2D rbt = col.GetComponent<Rigidbody2D>();
                if (rbt != null)
                {
                    Vector2 direction = col.transform.position - transform.position;
                    float distance = 1 + direction.magnitude;
                    float force = explotionForce / distance;
                    rbt.AddForce(direction * force);
                }
                else
                {
                }
            }

            Destroy(this.gameObject);

        }
}
