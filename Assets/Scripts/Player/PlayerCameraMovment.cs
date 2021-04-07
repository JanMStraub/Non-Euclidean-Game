using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovment : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
<<<<<<< HEAD:Assets/Scripts/mouse_look.cs

    float xRotation = 0f;
    float yRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
=======
    private float _xRotation = 0f;
    private float _yRotation = 0f;
>>>>>>> feature_portal_ring_jan:Assets/Scripts/Player/PlayerCameraMovment.cs


    // Update is called once per frame
    void FixedUpdate()
    {
<<<<<<< HEAD:Assets/Scripts/mouse_look.cs
        playerBody.localRotation = GroundNormal() * TurnPlayer();
        TiltCamera();
=======
        if (Time.timeScale == 1) {
            Cursor.lockState = CursorLockMode.Locked;
            playerBody.localRotation = GroundNormal() * TurnPlayer();
        }
        //TiltCamera();
>>>>>>> feature_portal_ring_jan:Assets/Scripts/Player/PlayerCameraMovment.cs
    }

    
    Quaternion TurnPlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        _yRotation += mouseX;

        return Quaternion.Euler(0f, mouseX, 0f);
    }
    
    void TiltCamera()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        //transform.Rotate(Vector3.right * mouseY);
    }

    Quaternion GroundNormal()
    {
        RaycastHit hit;
        Physics.Raycast(playerBody.position, -playerBody.up, out hit, Mathf.Infinity);
        Debug.DrawRay(hit.point, hit.normal * 10, Color.red);

        Vector3 toDir = playerBody.up + (hit.normal - playerBody.up) * 0.05f;

        Quaternion toRotation = Quaternion.FromToRotation(playerBody.up, toDir) * playerBody.rotation;
        return toRotation;
    }
}
