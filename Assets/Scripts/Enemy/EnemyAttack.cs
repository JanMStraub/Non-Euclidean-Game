/*
*   Code from Brackeys
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    private float _damage = 10f;
    private float _range = 100f;
    private float _fireRate = 0.5f;
    private float _nextTimeToFire = 0f;
    private float attackRange = 10f;
    public GameObject projectile;
    public LayerMask whatIsPlayer;
    private bool playerInAttackRange;



    void Update () {   
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (playerInAttackRange && Time.time >= _nextTimeToFire) {   
            _nextTimeToFire = Time.time + 1f/_fireRate;
            Shoot();
            Debug.Log("shooting");
        }
    }


    void Shoot () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _range)) {
            Debug.Log(hit.transform.name);

            PlayerHit player = hit.transform.GetComponent<PlayerHit>();
            if (player != null) {
                player.TakeDamage(_damage);
            }

            GameObject usedProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            Destroy(usedProjectile, 10f);
        } else {
            GameObject usedProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            Destroy(usedProjectile, 10f);
        }
    }
}
