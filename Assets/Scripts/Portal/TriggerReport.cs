using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReport : MonoBehaviour {
    public int id;

    private PortRoom _portRoom;


    //Reference to managing script
    void Start () {

        _portRoom = GameObject.Find("PortalRoomEven").GetComponent<PortRoom>();
    }

    //if another collider enters, report
    void OnTriggerEnter () {
        
        _portRoom.trigger[id] = true;
    }
}
