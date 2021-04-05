/*
*   Code from BurgZerg Arcade
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float movmentSpeed = 10f;
    [SerializeField] float rotationalDamp = 0.5f;
    [SerializeField] float rayCastOffset = 0.1f;
    [SerializeField] float detectionDistance = 10f;

    private void Update () {
        Pathfinding();
        Move();
    }

    private void Turn () {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    private void Move () {
        transform.position += transform.forward * movmentSpeed * Time.deltaTime;
    }

    private void Pathfinding() {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;
        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        Debug.DrawRay(left, transform.forward * detectionDistance, Color.red);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.red);
        Debug.DrawRay(up, transform.forward * detectionDistance, Color.red);
        Debug.DrawRay(down, transform.forward * detectionDistance, Color.red);

        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance)) {
            raycastOffset += Vector3.right;
        } else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance)) {
            raycastOffset -= Vector3.right;
        } 
        
        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance)) {
            raycastOffset -= Vector3.up;
        } else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance)) {
            raycastOffset += Vector3.up;
        }

        if (raycastOffset != Vector3.zero) {
            transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        } else {
            Turn();
        }
    }
}
