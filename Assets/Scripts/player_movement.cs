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
    // private float yRotation = 0;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(Movement() + ApplyGravity());
    }


    Vector3 Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * movement_speed * Time.deltaTime;
        return move;
    }


    Vector3 ApplyGravity()
    {

        if (Input.GetButtonDown("Jump") && OnGround())
        {
            currentG = -jumpHeight;
        }

        if (OnGround())
        {
            if (currentG > 0f)
            {
                currentG = 0f;
            }
        }

        currentG += gravity * Time.deltaTime;

        return -transform.up * currentG;
    }


    bool OnGround()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity);

        if(hit.distance < 1f)
        {
            return true;
        } 
        return false;
    }

}
