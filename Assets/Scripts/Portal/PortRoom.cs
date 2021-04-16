using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortRoom : MonoBehaviour
{
    public bool[] trigger;

    private Transform _exit;

    private Transform _entrence;

    private Transform _playerTransform;

    private Vector3 _offset;

    private int _planeNumber = 18;

    // Start is called before the first frame update
    void Start()
    {
        trigger = new bool[18];
        _playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //print(Vector3.Angle(-GameObject.Find("Plane0").transform.up, playerTransform.forward));
        for (int i = 0; i<_planeNumber-2; i++)
        {
            if(trigger[i] == true)
            {
                _entrence = GameObject.Find("Plane" + i).transform;
                if(i%2 == 1)
                {
                    _offset = _playerTransform.position - _entrence.position;
                }
                else
                {
                    _offset = _playerTransform.position - _entrence.position - transform.up;
                }
                FindExit(i);
                trigger[i] = false;
                Teleport();
            }
        }
        for (int j=_planeNumber-2; j<_planeNumber; j++)
        {
            if(trigger[j] == true)
            {
                _entrence = GameObject.Find("Plane" + j).transform;

                if (Vector3.Angle(_playerTransform.up, _entrence.position-_playerTransform.position) < 90)
                {
                    _offset = Vector3.zero;
                }
                else
                {
                    _offset = (_playerTransform.position - _entrence.position) * 1.5f;
                }
                string exitName = "Plane" + (((j + 1) % 2) + _planeNumber - 2);
                _exit = GameObject.Find(exitName).transform;

                //offset = (exit.transform.position - entrence.transform.position) * 0.25f;

                trigger[j] = false;
                Teleport();
            }
        }
    }


    void FindExit(int entrenceNumber)
    {
        string exitName = "";
        
        exitName = "Plane" + ((entrenceNumber + ((_planeNumber-2) / 2)) % (_planeNumber-2));

        _exit = GameObject.Find(exitName).transform;
    }


    void Teleport()
    {
        _playerTransform.position = _exit.position + _offset + _playerTransform.forward;
    }

    void Teleport1()
    {
        _playerTransform.position = _exit.position + _offset + _exit.up;
    }
}
