using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float movement_speed = 10f;
    public float gravity = 0.1f;
    public float jumpHeight = 0.05f;
    public LayerMask mask;

    private CharacterController controller;
    private float currentG = 0;
    private Vector3 graviDir;
    // private float yRotation = 0;
    private GameObject flashlight;
    private int health = 3;
    private int damage = 1;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        flashlight = GameObject.Find("Flashlight");
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (Time.timeScale == 1) {
            controller.Move(Movement() + ApplyGravity());
        }
    }

    void Update() {
        flashlightControll();
    }

    private void flashlightControll() {
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            if (flashlight.activeSelf) {
                flashlight.SetActive(false);
            } else {
                flashlight.SetActive(true);
            }
        }
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
        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, mask);
        
        if(hit.distance < 1f)
        {
            return true;
        } 
        return false;
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            Destroy(gameObject);
        };
    }

    void OnTriggerEnter() {
        TakeDamage(damage);
    }

}
