using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] private Transform tip;
    [SerializeField] private float rate;
    [SerializeField] private float recoil;
    private float nextTimeToFire;
    [SerializeField] private GameObject muzzle;

    [SerializeField] private Rigidbody2D rb;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            Shoot();
            nextTimeToFire = Time.time + 1f / rate;
        }
    }

    void Shoot()
    {
        Instantiate(muzzle, tip.position, tip.rotation);
        GameObject bulletObject = Instantiate(bullet, tip.position, tip.rotation);
        bulletObject.transform.Rotate(UnityEngine.Random.Range(recoil * -1, recoil), UnityEngine.Random.Range(recoil * -1, recoil), 0);
        
    }
}
