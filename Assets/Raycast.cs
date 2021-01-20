using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Transform objectToPlace;

    // Update is called once per frame
    void Update()
    {
        Ray ray = // TODO
        RaycastHit hitInfo;

        if (Physics.Raycast (ray, out hitInfo)) {
            objectToPlace.position = hitInfo.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal)
        }

    }
}
