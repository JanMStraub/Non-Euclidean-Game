/*
*   Code inspired by Brackeys
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject projectile;

    public LayerMask whatIsPlayer;

    private float _damage = 10f;

    private float _range = 100f;

    private float _fireRate = 0.5f;

    private float _nextTimeToFire = 0f;

    private float _attackRange = 20f;
    
    private bool _playerInAttackRange;


    void Update () {   

        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, whatIsPlayer);

        // Regulate fire rate with cooldown time
        if (_playerInAttackRange && Time.time >= _nextTimeToFire) {   
            _nextTimeToFire = Time.time + 1f/_fireRate;
            Shoot();
        }
    }


    void Shoot () {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, _range)) {

            PlayerHit player = hit.transform.GetComponent<PlayerHit>();
            
            // Check if hit object is player and deal damage
            if (player != null) {
                player.TakeDamage(_damage);
            }

            // Spawn projectile and shoot it
            GameObject usedProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            Destroy(usedProjectile, 10f); // Destroy projectile after 10 seconds
        } else { // Shoot even if the raycast does not hit the player
            // Spawn projectile and shoot it
            GameObject usedProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            Destroy(usedProjectile, 10f); // Destroy projectile after 10 seconds
        }
    }

    // Enemy deals damage if it touches the player
    void OnTriggerEnter (Collider other) {

        PlayerHit player = GameObject.Find("Player").GetComponent<PlayerHit>();

        if (other.CompareTag("Player")) {
            player.TakeDamage(_damage);
        }
    }
}
