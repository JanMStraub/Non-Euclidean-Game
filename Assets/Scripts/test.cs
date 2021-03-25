using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float value = 5f;
    public Transform playeTransform;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playeTransform.transform.position - Vector3.forward * 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.up * value);
    }
}
