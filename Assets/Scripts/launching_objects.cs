using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launching_objects : MonoBehaviour
{
    public GameObject projectile;
    GameObject[] projectileHandler = new GameObject[10];
    double[] projectileTTL = new double[10];
    public int projectileUsed = 0;
    public int projectileNextFree = 0;

    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && (projectileUsed < 10))
        {
            Shoot();
        }
        projectileDestroyer();
    }


    void Shoot()
    {
        projectileHandler[projectileNextFree] = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
        projectileTTL[projectileNextFree] = Time.time;
        projectileUsed++;
        projectileNextFree = (projectileNextFree + 1) % 10;
    }

    void projectileDestroyer()
    {
        for (int i=0; i<10; i++)
        {
            if((Time.time - projectileTTL[i] > 3f) && (projectileTTL[i] != 0))
            {
                Destroy(projectileHandler[i]);
                projectileTTL[i] = 0;
                projectileUsed--;
            }
        }
    }
}
