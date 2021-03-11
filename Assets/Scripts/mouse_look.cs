using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_look : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playerBody.localRotation = GroundNormal() * FPCamera();
    }

    
    Quaternion FPCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        return Quaternion.Euler(0f, mouseX, 0f);
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
