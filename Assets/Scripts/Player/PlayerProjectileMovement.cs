using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileMovement : MonoBehaviour {
    private float _speed = 1f;
    private GameObject _enemy;
    private Vector3 _target;

    void Start () {
        _enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD:Assets/Scripts/projectile_movement.cs
        transform.position += (transform.forward * projectileSpeed * Time.deltaTime);
=======
        transform.position += (transform.forward * _speed);
>>>>>>> feature_portal_ring_jan:Assets/Scripts/Player/PlayerProjectileMovement.cs
        transform.localRotation = GroundNormal();
    }

    Quaternion GroundNormal()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity);
        Debug.DrawRay(hit.point, hit.normal * 10, Color.red);

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        return toRotation;
    }


<<<<<<< HEAD:Assets/Scripts/projectile_movement.cs
    void Destroyer()
    {
        if (Time.time - startTime < ttl)
        {
            Destroy(gameObject, 2);
=======
    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Enemy")) {
            Destroy(gameObject);
>>>>>>> feature_portal_ring_jan:Assets/Scripts/Player/PlayerProjectileMovement.cs
        }
    }
}