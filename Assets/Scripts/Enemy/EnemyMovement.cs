using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Transform target;
    
    private float _movmentSpeed = 10f;
    
    private float _rotationalDamp = 0.5f;

    private EnemyHit _EnemyHit;


    void Start () {

        _EnemyHit = GameObject.Find("Enemy").GetComponent<EnemyHit>();
    }


    private void Update () {

        if (!_EnemyHit.wasHit) {
            Move();
            Turn();
        } else {
            // Stay in position and turn to player
            transform.position = this.transform.position;
            Vector3 lookVector = target.transform.position - transform.position;
            Quaternion lookAtPlayer = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookAtPlayer, 1);
        }
    }


    private void Turn () {

        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationalDamp * Time.deltaTime);
    }


    private void Move () {

        transform.position += transform.forward * _movmentSpeed * Time.deltaTime;
    }
}
