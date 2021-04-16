using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReport : MonoBehaviour
{
    public int id;

    private PortRoom _portRoom;

    // Start is called before the first frame update
    void Start()
    {
        _portRoom = GameObject.Find("PortalRoomEven").GetComponent<PortRoom>();

        print(id);
        print(_portRoom.trigger[id]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        _portRoom.trigger[id] = true;
    }

}
