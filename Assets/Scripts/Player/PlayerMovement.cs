﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    public LayerMask mask;

    private CharacterController _controller;

    private GameObject _groundBottle;

    private GameObject _groundDonut;

    private Transform _cameraTransform;

    private bool _noclip;

    private float _currentG = 0;

    private Vector3 _graviDir;

    private GameObject _flashlight;

    private float _movement_speed = 10f;

    private float _gravity = 0.1f;

    private float _jumpHeight = 0.05f;


    void Start() {

        _controller = gameObject.GetComponent<CharacterController>();
        _flashlight = GameObject.Find("Flashlight");
        _cameraTransform = GameObject.Find("PlayerCamera").transform;
        _groundBottle = GameObject.Find("working_klein_bottle");
        _groundDonut = GameObject.Find("default");
    }


    void FixedUpdate () {

        if (!_noclip) {
            if (Time.timeScale == 1) {
                _controller.Move(Movement() + ApplyGravity());
            }
        } else {
            _controller.Move(Movement());
        }
    }


    void Update() {

        flashlightControll();
        ControllKeys();
    }

    // Toggle flashlight on right mouse button
    private void flashlightControll () {

        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            if (_flashlight.activeSelf) {
                _flashlight.SetActive(false);
            } else {
                _flashlight.SetActive(true);
            }
        }
    }

    // Move player
    Vector3 Movement () {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move;

        if (!_noclip) {
            move = (transform.right * x + transform.forward * z) * _movement_speed * Time.deltaTime;
        } else {
            move = (transform.right * x + _cameraTransform.forward * z) * _movement_speed * Time.deltaTime;
        }

        return move;
    }


    // Move down if not on ground
    Vector3 ApplyGravity () {

        if (Input.GetButtonDown("Jump") && OnGround()) {
            _currentG = -_jumpHeight;
        }

        if (OnGround()) {
            if (_currentG > 0f) {
                _currentG = 0f;
            }
        }

        _currentG += _gravity * Time.deltaTime;

        return -transform.up * _currentG;
    }


    // Check if player is on ground
    bool OnGround () {

        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity);

        if(hit.distance < 1f) {
            return true;
        } 

        return false;
    }

    // Special movement: flip through ground and activate noclip
    void ControllKeys () {

        if (Input.GetKeyDown("e")) {
            transform.position += 2 * (-transform.up);
            transform.up = -transform.up;
        }

        if (Input.GetKeyDown("n")) {
            if (_noclip) {
                _noclip = false;
                _groundBottle.GetComponent<Collider>().enabled = true;
                GameObject.Find("Wc").GetComponent<Collider>().enabled = true;
                _groundDonut.GetComponent<Collider>().enabled = true;
            } else {
                _noclip = true;
                _groundBottle.GetComponent<Collider>().enabled = false;
                GameObject.Find("Wc").GetComponent<Collider>().enabled = false;
                _groundDonut.GetComponent<Collider>().enabled = false;
            }
        }
    }
}