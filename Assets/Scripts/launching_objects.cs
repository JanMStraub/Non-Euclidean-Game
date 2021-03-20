using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launching_objects : MonoBehaviour
{
    public GameObject projectile;
    GameObject[] projectileHandler = new GameObject[10];
    double[] projectileTTL = new double[10];

    public int pUsed = 0;
    public int pNextFree = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && (pUsed < 10))
        {
            Shoot();
        }
        PDestroyer();
    }


    void Shoot()
    {
        projectileHandler[pNextFree] = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
        projectileTTL[pNextFree] = Time.time;
        //Destroy();
        pUsed++;
        pNextFree = (pNextFree + 1) % 10;
    }

    void PDestroyer()
    {
        for (int i=0; i<10; i++)
        {
            print(projectileTTL[0]);
            if((Time.time - projectileTTL[i] > 3f) && (projectileTTL[i] != 0))
            {
                Destroy(projectileHandler[i]);
                projectileTTL[i] = 0;
                pUsed--;
            }
        }
    }
}
