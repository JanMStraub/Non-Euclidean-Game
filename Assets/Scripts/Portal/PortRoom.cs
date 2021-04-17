using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortRoom : MonoBehaviour {
    public bool[] trigger;

    private Transform _exit;

    private Transform _entrence;

    private Transform _playerTransform;

    private Vector3 _offset;

    private int _planeNumber = 18;


    void Start () {

        trigger = new bool[18];
        _playerTransform = GameObject.Find("Player").transform;
    }


    void Update () {

        for (int i = 0; i<_planeNumber-2; i++) {
            if(trigger[i] == true) {
                _entrence = GameObject.Find("Plane" + i).transform;

                if(i%2 == 1) {
                    _offset = _playerTransform.position - _entrence.position;
                } else {
                    _offset = _playerTransform.position - _entrence.position - transform.up;
                }

                FindExit(i);
                trigger[i] = false;
                Teleport();
            }
        }

        for (int j=_planeNumber-2; j<_planeNumber; j++) {
            if(trigger[j] == true) {
                _entrence = GameObject.Find("Plane" + j).transform;

                if (Vector3.Angle(_playerTransform.up, _entrence.position-_playerTransform.position) < 90) {
                    _offset = Vector3.zero;
                } else {
                    _offset = (_playerTransform.position - _entrence.position) * 1.5f;
                }

                string exitName = "Plane" + (((j + 1) % 2) + _planeNumber - 2);
                _exit = GameObject.Find(exitName).transform;

                trigger[j] = false;
                Teleport();
            }
        }
    }


    void FindExit (int entrenceNumber) {
        
        string exitName = "Plane" + ((entrenceNumber + ((_planeNumber-2) / 2)) % (_planeNumber-2));

        _exit = GameObject.Find(exitName).transform;
    }


    void Teleport () {
        _playerTransform.position = _exit.position + _offset + _playerTransform.forward;
    }
}
