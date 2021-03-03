using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public float rayLength = 5;
    public float detectRayLength = 3;

    float distance = 100f;

    public LayerMask mask;

    public Transform objectToPlace;

    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        Vector3 targetLocation;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance))
        {
           targetLocation = hit.point;
        }
    }
}
