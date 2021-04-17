using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReport : MonoBehaviour {
    public int id;

    private PortRoom _portRoom;


    void Start () {

        _portRoom = GameObject.Find("PortalRoomEven").GetComponent<PortRoom>();
    }


    void OnTriggerEnter () {
        
        _portRoom.trigger[id] = true;
    }
}
