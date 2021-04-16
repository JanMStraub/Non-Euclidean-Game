using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReport : MonoBehaviour
{
    PortRoom portRoom;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        
        portRoom = GameObject.Find("PortalRoomEven").GetComponent<PortRoom>();


        print(id);
        print(portRoom.trigger[id]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        portRoom.trigger[id] = true;
    }

}
