/*
*   Code inspired by Brackeys
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Camera playerCamera;

    public GameObject projectile;

    private float _range = 100f;

    private int _magazine = 5;

    private float _fireRate = 0.5f;

    private float _nextTimeToFire = 0f;

    private HUDHandler _HUDH;


    void Start () {

        _HUDH = GameObject.Find("Canvas").GetComponent<HUDHandler>();
        _HUDH.ammo = _magazine;
    }

    void Update () {

        // Shoots if mouse button is pressed, cooldown has finished and player has ammonition left
        if ((Input.GetButton("Fire1")) && Time.time >= _nextTimeToFire && _magazine > 0) {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            _magazine--;
            _HUDH.ammo--;
            Shoot();
        }
    }


    void Shoot () {

        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, _range)) {
            EnemyHit enemy = hit.transform.GetComponent<EnemyHit>();

            // Enemy movment stopps
            if (enemy != null) {
                enemy.stunned();
            }

            GameObject usedProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            Destroy(usedProjectile, 10f);
        } else {
            GameObject usedProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            Destroy(usedProjectile, 10f);
        }
    }
}
