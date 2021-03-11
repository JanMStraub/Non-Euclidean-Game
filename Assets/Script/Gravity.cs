using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gravity : MonoBehaviour
{
    public float rayLength = 0.5f;
    public float detectRayLength = 5;
    public float distToGround = 0.5f;
    bool isGrounded = false;

    public Text debug;

    public LayerMask mask;

    public Transform objectToPlace;

    void Update()
    {   
        
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, rayLength, mask)) {

            objectToPlace.position = hitInfo.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            
            

        }
    }

    /*
    void GroundCheck () {
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f)) {
            debug.text = "Grounded";
            isGrounded = true;
        } else {
            debug.text = "Not Grounded";
            isGrounded = false;
        }
    }
    */

}
