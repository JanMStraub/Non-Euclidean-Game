using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour {

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float _xRotation = 0f;
    
    private float _yRotation = 0f;


    void FixedUpdate () {

        Cursor.lockState = CursorLockMode.Locked;
        playerBody.localRotation = GroundNormal() * TurnPlayer();
        TiltCamera();
    }

    
    Quaternion TurnPlayer () {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        _yRotation += mouseX;

        return Quaternion.Euler(0f, mouseX, 0f);
    }
    

    void TiltCamera () {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }


    Quaternion GroundNormal () {
        
        RaycastHit hit;
        Physics.Raycast(playerBody.position, -playerBody.up, out hit, Mathf.Infinity);
        Debug.DrawRay(hit.point, hit.normal * 10, Color.red);

        Vector3 toDir = playerBody.up + (hit.normal - playerBody.up) * 0.05f;

        Quaternion toRotation = Quaternion.FromToRotation(playerBody.up, toDir) * playerBody.rotation;
        return toRotation;
    }
}
