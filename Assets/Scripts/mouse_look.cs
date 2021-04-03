using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_look : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public GameObject projectile;
    float xRotation = 0f;
    float yRotation = 0f;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale == 1) {
            playerBody.localRotation = GroundNormal() * TurnPlayer();
        }
        //TiltCamera();
    }

    
    Quaternion TurnPlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;

        return Quaternion.Euler(0f, mouseX, 0f);
    }
    
    void TiltCamera()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //transform.Rotate(Vector3.right * mouseY);
    }

    Quaternion GroundNormal()
    {
        RaycastHit hit;
        Physics.Raycast(playerBody.position, -playerBody.up, out hit, Mathf.Infinity);
        Debug.DrawRay(hit.point, hit.normal * 10, Color.red);

        Quaternion toRotation = Quaternion.FromToRotation(playerBody.up, hit.normal) * transform.rotation;
        return toRotation;
    }
}
