using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour {
    private float _speed = 1f;
    private GameObject _player;
    private Vector3 _target;

    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        transform.position += (transform.forward * _speed);
        transform.localRotation = GroundNormal();
    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }

    Quaternion GroundNormal () {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity);
        Debug.DrawRay(hit.point, hit.normal * 10, Color.red);

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        return toRotation;
    }
}
