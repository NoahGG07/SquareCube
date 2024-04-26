using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private GameObject[] guns;

    [SerializeField] private GameObject player;

        // Start is called before the first frame update
    void Start()
    {
        guns[Random.Range(0,(guns.Length -1))].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        Vector3 difference = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);

        if (rotz < 89 && rotz > -89)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
}
