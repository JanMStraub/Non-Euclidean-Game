using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortRoom : MonoBehaviour
{
    public bool[] trigger;

    Transform exit;
    Transform entrence;

    Transform playerTransform;

    Vector3 offset;

    int planeNumber = 18;

    // Start is called before the first frame update
    void Start()
    {
        trigger = new bool[18];

        playerTransform = GameObject.Find("Player").transform;

        print(playerTransform);
    }

    // Update is called once per frame
    void Update()
    {
        //print(Vector3.Angle(-GameObject.Find("Plane0").transform.up, playerTransform.forward));
        for (int i = 0; i<planeNumber-2; i++)
        {
            if(trigger[i] == true)
            {
                entrence = GameObject.Find("Plane" + i).transform;
                if(i%2 == 1)
                {
                    offset = playerTransform.position - entrence.position;

                }
                else
                {
                    offset = playerTransform.position - entrence.position - transform.up;
                }
                FindExit(i);
                trigger[i] = false;
                Teleport();
            }
        }
        for (int j=planeNumber-2; j<planeNumber; j++)
        {
            if(trigger[j] == true)
            {
                entrence = GameObject.Find("Plane" + j).transform;
                print(Vector3.Angle(playerTransform.up, entrence.position - playerTransform.position));

                if (Vector3.Angle(playerTransform.up, entrence.position-playerTransform.position) < 90)
                {
                    offset = Vector3.zero;
                }
                else
                {
                    offset = (playerTransform.position - entrence.position) * 1.5f;
                }
                string exitName = "Plane" + (((j + 1) % 2) + planeNumber - 2);
                print(exitName);
                exit = GameObject.Find(exitName).transform;

                //offset = (exit.transform.position - entrence.transform.position) * 0.25f;

                trigger[j] = false;
                Teleport();
            }
        }
    }


    void FindExit(int entrenceNumber)
    {
        string exitName = "";
        
        exitName = "Plane" + ((entrenceNumber + ((planeNumber-2) / 2)) % (planeNumber-2));

        print(entrence);
        print(exit);

        exit = GameObject.Find(exitName).transform;
    }


    void Teleport()
    {
        playerTransform.position = exit.position + offset + playerTransform.forward;
    }

    void Teleport1()
    {
        playerTransform.position = exit.position + offset + exit.up;
    }
}
