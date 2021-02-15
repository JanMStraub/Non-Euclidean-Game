using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet : MonoBehaviour
{
    public GameObject Magnet;
    public float forceFactor;

    void Update()
    {
        GetComponent<Rigidbody>().AddForce((Magnet.transform.position - transform.position) * forceFactor * Time.smoothDeltaTime);
    }
}