using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float rayLength = 5;
    public float detectRayLength = 5;

    public LayerMask mask;

    public Transform objectToPlace;

    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, rayLength, mask)) {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            print(hitInfo.collider.gameObject.name);
            print(hitInfo.distance);

            objectToPlace.position = hitInfo.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

        } else {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * detectRayLength, Color.green);
        }
    }

}
