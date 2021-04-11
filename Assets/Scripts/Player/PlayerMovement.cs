using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    public float movement_speed = 10f;

    public float gravity = 0.1f;

    public float jumpHeight = 0.05f;

    public LayerMask mask;

    private CharacterController _controller;

    private float _currentG = 0;

    private Vector3 _graviDir;

    private GameObject _flashlight;


    void Start() {

        _controller = gameObject.GetComponent<CharacterController>();
        _flashlight = GameObject.Find("Flashlight");
    }


    void FixedUpdate () {   

        if (Time.timeScale == 1) {
            _controller.Move(Movement() + ApplyGravity());
        }
    }


    void Update() {

        flashlightControll();
        FlipOver();
    }


    private void flashlightControll () {

        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            if (_flashlight.activeSelf) {
                _flashlight.SetActive(false);
            } else {
                _flashlight.SetActive(true);
            }
        }
    }


    Vector3 Movement () {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * movement_speed * Time.deltaTime;

        return move;
    }


    Vector3 ApplyGravity () {

        if (Input.GetButtonDown("Jump") && OnGround()) {
            _currentG = -jumpHeight;
        }

        if (OnGround()) {
            if (_currentG > 0f) {
                _currentG = 0f;
            }
        }

        _currentG += gravity * Time.deltaTime;

        return -transform.up * _currentG;
    }


    bool OnGround () {

        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity);

        if(hit.distance < 1f) {
            return true;
        } 

        return false;
    }


    void FlipOver () {

        if (Input.GetKeyDown("e")) {
            transform.position += 2 * (-transform.up);
            transform.up = -transform.up;
        }
    }
}
