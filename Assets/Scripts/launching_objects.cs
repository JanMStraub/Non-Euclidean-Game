using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launching_objects : MonoBehaviour
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
