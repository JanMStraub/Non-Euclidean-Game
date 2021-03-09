using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_movement : MonoBehaviour
{
    public CharacterController controller;

    public float movement_speed = 10f;
    public float gravity = 0.1f;
    public float jumpHeight = 0.05f;

    private float currentG = 0;
    private Vector3 graviDir;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        controller.Move(Movement() + ApplyGravity());
    }


    Vector3 Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * movement_speed * Time.deltaTime;
        return move;
    }


    Vector3 ApplyGravity()
    {

        if (Input.GetButtonDown("Jump") && onGround())
        {
            currentG = -jumpHeight;
        }

        if (onGround())
        {
            if (currentG > 0f)
            {
                currentG = 0f;
            }
        }

        currentG += gravity * Time.deltaTime;

        return graviDir * -currentG;
    }

    void Rotation()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity);
        Debug.DrawRay(hit.point, hit.normal * 10, Color.red);

        graviDir = Vector3.Normalize(hit.normal);

        transform.up = hit.normal;
    }

    bool onGround()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity);

        if(hit.distance < 1f)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
}
