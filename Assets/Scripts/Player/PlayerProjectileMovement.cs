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


    void Update () {

        transform.position += (transform.forward * _speed);
        transform.localRotation = GroundNormal();
    }


    Quaternion GroundNormal () {

        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity);
        Debug.DrawRay(hit.point, hit.normal * 10, Color.red);

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

        return toRotation;
    }


    void OnTriggerEnter (Collider other) {

        if (other.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }
}