using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectile;
    GameObject[] projectileHandler = new GameObject[10];
    double[] projectileTTL = new double[10];
    public int projectileUsed = 0;
    public int projectileNextFree = 0;

    public LayerMask whatIsPlayer;

    public float attackRange = 10f;
    private float enemyCooldown = 2f;

    private bool playerInAttackRange;
    private bool canAttack = true;

    void Update()
    {   
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (playerInAttackRange && canAttack)
        {
            Shoot();
            StartCoroutine(AttackCooldown());
            Debug.Log("shooting");
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

    IEnumerator AttackCooldown() {
        canAttack = false;
        yield return new WaitForSeconds(enemyCooldown);
        canAttack = true;
    }


}
